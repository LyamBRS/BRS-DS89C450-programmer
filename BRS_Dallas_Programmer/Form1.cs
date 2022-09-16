using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using BRS;
using cls;
using BRS_Dallas_Programmer;

namespace BRS_Dallas_Programmer
{
    public partial class Form1 : Form
    {
        static string name = "";
        string FilePath = "";
        string OldFilePath = "";
        static bool AutoProgramming = true;
        bool ShowingSettings = false;
        bool DetectedDallas = false;
        ProgrammerSettings SettingWindow;
        ////////////////////////////////////////////////////////////////////////////////////// RESIZE
        clsResize _form_resize;
        public Form1()
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Initializing form's components...");
            InitializeComponent();

            BRS.Debug.Comment("Creating resizing properties");
            _form_resize = new clsResize(this);
            this.Load += _Load;
            this.Resize += _Resize;

            BRS.Debug.Success("Form1 constructed!");
            BRS.Debug.Header(false);
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }
        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Form1 is loading...");
            name = "";
            FTDI_Search_Timer_Tick(sender,e);

            BRS.Debug.Comment("Creating fileChecker");
            BRS.FileWatcher.CreateFileWatcher();

            BRS.Debug.Success("");
            BRS.Debug.Header(false);
        }
        ////////////////////////////////////////////////////////////////////////////////////// Dallas Connection Timer
        private void FTDI_Search_Timer_Tick(object sender, EventArgs e)
        {
            //Update form name.
            this.Text = "[BRS] " + BRS.ComPorts.ConnectedFTDI;
            UpdateFilePath();
            UpdateUSBButton();
            //Check if name changed
            if (name != BRS.ComPorts.ConnectedFTDI)
            {
                BRS.Debug.Header(true);
                BRS.Debug.Comment("Updating form name and USB icon with new device name");
                UpdateUSBButton();
                BRS.Debug.Success("");

                name = BRS.ComPorts.ConnectedFTDI;

                //Check if name isnt available anymore
                if (name.Equals("No Device"))
                {
                    BRS.Debug.Comment("Device is unplugged... Closing Serial Port");

                    if (BRS.ComPorts.FTDIPort.IsOpen)
                    {
                        BRS.Debug.Comment("Attempting to close FTDI port");
                        BRS.ComPorts.FTDIPort.Close();
                        BRS.Debug.Success("");
                    }
                    else
                    {
                        BRS.Debug.Aborted("FTDI com port was not opened");
                    }
                }
                else
                {
                    BRS.Debug.Comment("Setting COM parameters to Proggramming ones");
                    BRS.Debug.Comment("COM used: " + BRS.ComPorts.FTDIComName);
                    try
                    {
                        BRS.Debug.Comment("Attempting to open " + BRS.ComPorts.FTDIComName + " port...");
                        
                        if(BRS.ComPorts.FTDIPort.IsOpen)
                        {
                            BRS.Debug.Error("Could not open port, port already opened");
                        }
                        else
                        {
                            BRS.Debug.Comment("Setting FTDI port to " + BRS.ComPorts.FTDIComName);
                            BRS.ComPorts.FTDIPort.PortName = BRS.ComPorts.FTDIComName;
                            BRS.Debug.Success("Port is closed, opening...");
                            FileLoading();
                            BRS.ComPorts.FTDIPort.Open();
                            BRS.Debug.Success("");
                        }
                    }
                    catch
                    {
                        BRS.Debug.Error("Could not open " + BRS.ComPorts.FTDIComName);
                    }
                }
                BRS.Debug.Success("named changed");
                BRS.Debug.Header(false);
            }
        }
        private void AutoProgEnterCheck_Tick(object sender, EventArgs e)
        {
            if(AutoProgramming)
            {
                //BRS.Debug.Comment("AutoProgramming ON");
                if(BRS.ComPorts.FTDIPort.IsOpen)
                {
                    //BRS.Debug.Comment("PORT OPENED");
                    //BRS.Debug.Comment(Convert.ToString(BRS.FileWatcher.FileChanged));
                    if (BRS.FileWatcher.FileChanged)
                    {
                        BRS.Debug.Comment("SENDING ENTER");
                        //Read existing
                        string result = BRS.ComPorts.FTDIPort.ReadExisting();

                        //Check if we received "> "
                        if (result.Contains("> "))
                        {
                            BRS.Debug.Success("AUTOMATED PROGRAMMING O_O");
                            UploadCodeButton_Click(sender,e);
                        }

                        //Send enter to DS89C450
                        BRS.ComPorts.FTDIPort.Write("\r");
                    }
                }
            }
        }


        //////////////////////////////////////////////////////////////////////////////////////
        private void UpdateUSBButton()
        {

            //Check if device is connected
            if(BRS.ComPorts.FTDIComName.Equals("No Device"))
            {
                ConnectionStatusButton.BackgroundImage = Properties.Resources.icons8_usb_disconnected_100;
            }
            else
            {
                ConnectionStatusButton.BackgroundImage = Properties.Resources.icons8_usb_connected_100;
                this.Refresh();
            }
        }
        private void UpdateFilePath()
        {
            //BRS.Debug.Comment("Verifying file path...");

            if(FilePath.Equals(OldFilePath))
            {
                //BRS.Debug.Comment("No changes in file path");
            }
            else
            {
                BRS.Debug.Comment("File path changed!");
                BRS.FileWatcher.SetFileLocation(FilePath);
                OldFilePath = FilePath;
                BRS.Debug.Comment("Changing file checker to new path");
                BRS.FileWatcher.CreateFileWatcher();
            }

            if(File.Exists(FilePath))
            {
                if (BRS.ComPorts.FTDIPort.IsOpen)
                {
                    //Port opened, and files available
                    UploadCodeButton.BackgroundImage = Properties.Resources.icons8_file_download_100;

                    //Check watcher
                    if(BRS.FileWatcher.FileChanged)
                    {
                        //BRS.FileWatcher.FileChanged = false;
                        BRS.Debug.Comment("FILE CHANGED");
                    }
                }
                else
                {
                    //Port closed and files available
                    UploadCodeButton.BackgroundImage = Properties.Resources.icons8_delete_file_100;
                }
                UploadCodeButton.Enabled = true;
            }
            else
            {
                UploadCodeButton.BackgroundImage = Properties.Resources.icons8_error_file_100;
                UploadCodeButton.Enabled = false;
            }

        }
        private void FileLoading()
        {
            UploadCodeButton.BackgroundImage = Properties.Resources.icons8_fileLoading_100;
            this.Refresh();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        public bool GetAutoProgrammingState()
        {
            BRS.Debug.Comment("Returning prohgramming state");
            return (AutoProgramming);
        }
        public void SetAutoProgrammingState(bool state)
        {
            BRS.Debug.Comment("Setting AutoProgramming state");
            AutoProgramming = state;
        }
        public void FlipSettingShowingState()
        {
            ShowingSettings = !ShowingSettings;
        }
        ////////////////////////////////////////////////////////////////////////////////////// FOLDER BUTTON
        private void FolderButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Handling file dialog...");
            FilePath = BRS.Dialog.OpenFile("[BRS]: Open your hex file", "HEX file (*.hex)|*.hex");
            BRS.Debug.Success("");

            BRS.Debug.Header(false);
        }
        private void ProgrammerSettings_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Checking if window is already shown");
            if (!ShowingSettings)
            {
                BRS.Debug.Comment("Creating new setting window");
                SettingWindow = new ProgrammerSettings(this);
                BRS.Debug.Comment("Showing setting window...");
                SettingWindow.Show();

            }
            else
            {
                BRS.Debug.Comment("Closing setting window");
                SettingWindow.Close();
                BRS.Debug.Success("");
            }
            BRS.Debug.Comment("Flipping state of window for next click");
            ShowingSettings = !ShowingSettings;
            BRS.Debug.Header(false);
        }
        ////////////////////////////////////////////////////////////////////////////////////// MANUAL UPLOAD
        private void UploadCodeButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Manual upload starting...");
            FileLoading();
            this.Refresh();
            if (BRS.ComPorts.FTDIPort.IsOpen)
            {
                if(File.Exists(FilePath))
                {
                    BRS.Debug.Success("File validated, and FTDI opened");

                    string Text = File.ReadAllText(FilePath);

                    BRS.Debug.Comment("Programming HEX file to FTDI");
                    bool executed = BRS.ComPorts.SendHexFileDS89(Text);

                    if(executed)
                    {
                        BRS.FileWatcher.FileChanged = false;
                    }
                }
            }

            BRS.Debug.Header(false);
        }
    }
}
  