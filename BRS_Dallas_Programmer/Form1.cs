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
using System.Media;
using BRS;
using cls;
using BRS_Dallas_Programmer;
using System.Runtime.InteropServices;
using System.Threading;

namespace BRS_Dallas_Programmer
{
    public partial class Form1 : Form
    {
        static int amountOfGs = 0;
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

            BRS.Debug.Comment("Looking for FTDIs");
            BRS.ComPorts.UpdateFTDIInfo();

            BRS.Debug.Comment(BRS.ComPorts.FTDIComName);
            try
            {
                BRS.Debug.Comment("Opening port.");
                BRS.Debug.Success("");
                name = "sus";
            }
            catch
            {
                BRS.ComPorts.FTDIComName = "No Device";
            }

            BRS.ComPorts.startFTDIUpdater();

            BRS.Debug.Comment("Creating fileChecker");
            BRS.FileWatcher.CreateFileWatcher();

            FTDI_Search_Timer_Tick(sender, e);

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
                NewUserTextInfo("COM changed...", 0);
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
                    NewUserTextInfo("Device lost", 2);
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
                            NewUserTextInfo("COM already opened somewhere!", 2);
                            BRS.Debug.Error("Could not open port, port already opened");
                        }
                        else
                        {
                            NewUserTextInfo("Connecting dallas...", 0);
                            BRS.Debug.Comment("Setting FTDI port to " + BRS.ComPorts.FTDIComName);
                            BRS.ComPorts.FTDIPort.PortName = BRS.ComPorts.FTDIComName;
                            BRS.Debug.Success("Port is closed, opening...");
                            FileLoading();
                            BRS.ComPorts.FTDIPort.BaudRate = 57600;
                            BRS.ComPorts.FTDIPort.Open();
                            BRS.Debug.Success("");

                            //check if file path exists, if not, warning message to user.
                            if (File.Exists(FilePath))
                            {
                                NewUserTextInfo("Ready!", 1);
                            }
                            else
                            {
                                NewUserTextInfo("No hex file selected", 3);
                            }
                        }
                    }
                    catch
                    {
                        NewUserTextInfo("Port failed to open!", 2);
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
                    //check if file path changed!

                    //BRS.Debug.Comment("PORT OPENED");
                    //BRS.Debug.Comment(Convert.ToString(BRS.FileWatcher.FileChanged));
                    if (BRS.FileWatcher.FileChanged)
                    {
                        NewUserTextInfo("Attempting auto programming...", 3);
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

            if(File.Exists(FilePath))
            {
                NewUserTextInfo("File good for download.", 1);
                BRS.Debug.Comment("Valid new file, attempting autoprogramming!");
                BRS.FileWatcher.FileChanged = true;
            }
            else
            {
                NewUserTextInfo("Selected file is invalid.", 2);
            }
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
                    BRS.Debug.Success("Parsing as text");
                    string Text = File.ReadAllText(FilePath);

                    BRS.Debug.Success("Printing Amount of expected Gs:");
                    int Gs = 0;
                    Gs = BRS.ComPorts.GetHexFileSize(Text);

                    amountOfGs = 0;
                    ProgrammingProgress.Maximum = Gs+1;
                    ProgrammingProgress.Value = 0;

                    BRS.Debug.Comment("Programming HEX file to FTDI");
                    NewUserTextInfo("Programming...",0);
                    bool executed = BRS.ComPorts.SendHexFileDS89(Text, QReceived);

                    if(executed)
                    {
                        NewUserTextInfo("Programmed!", 1);
                        BRS.Debug.Success("Programmed !");
                        BRS.Debug.Comment(BRS.ComPorts.FTDIPort.ReadExisting());
                        BRS.FileWatcher.FileChanged = false;
                        SystemSounds.Asterisk.Play();
                    }
                    else
                    {
                        SystemSounds.Hand.Play();
                        //SystemSounds.Beep.Play();
                        //SystemSounds.Beep.Play();
                        BRS.Debug.Error("Programming failed!");
                        NewUserTextInfo("No replies from Dallas",2);
                    }
                }
            }

            BRS.Debug.Header(false);
        }
        /// <summary>
        /// Handler function called each time a G is received when transmitting a file
        /// </summary>
        private void QReceived()
        {
            amountOfGs = amountOfGs + 1;
            BRS.Debug.Comment(amountOfGs.ToString());
            ProgrammingProgress.Value = amountOfGs;
            this.Refresh();
        }

        /// <summary>
        /// changes the programmer's global text with the specified one
        /// 0: normal, 1: Green, 2: red, 3: warning orange
        /// </summary>
        /// <param name="info"></param>
        /// <param name="style"></param>
        private void NewUserTextInfo(string info, int style)
        {
            switch(style)
            {
                case 0: UserTextInfo.ForeColor = Color.FromArgb(100,100,100); break; // Neutral
                case 1: UserTextInfo.ForeColor = Color.FromArgb(60, 255, 60); break; // Good!
                case 2: UserTextInfo.ForeColor = Color.FromArgb(255, 60, 60); break; // Bad
                case 3: UserTextInfo.ForeColor = Color.FromArgb(255, 125, 60); break; // Attempting
            }

            UserTextInfo.Text = info;

        }
        /// <summary>
        /// Indicate the closure of the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Closing programmer...");

            BRS.Debug.Comment("Closing FTDI port");
            if(BRS.ComPorts.FTDIPort.IsOpen)
            {
                BRS.ComPorts.FTDIPort.Close();
                BRS.Debug.Success("");
            }
            else
            {
                BRS.Debug.Aborted("Already closed");
            }

            BRS.Debug.Comment("Closing timer");
            FTDI_Search_Timer.Stop();

            BRS.Debug.Header(false);
        }
    }
}

