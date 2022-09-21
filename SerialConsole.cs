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
    public partial class SerialConsole : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool ConsoleEnabled = false;
        public static bool ShowPCConsoleOutput = true;

        public static bool TextChangedOnRX = false;

        public static bool LinkedToPort = false;
        public static bool ReadingSerialPort = false;
        public static bool WritingOnSerialPort = false;

        public static string SelectedComFullName = "No Device";
        public static string SelectedComName = "No Device";

        public static int ComBaudRate = 9600;
        public static int ComDataBits = 8;
        public static Parity ComParity = Parity.None;
        public static Handshake ComHandshake = Handshake.None;
        public static StopBits ComStopBits = StopBits.One;

        public static string FilePath = "";

        clsResize _form_resize;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        public SerialConsole()
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initializing console's components...");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Creating resizing properties");
            _form_resize = new clsResize(this);
            this.Load += _Load;
            this.Resize += _Resize;

            BRS.Debug.Comment("Specifying function to call when data is received");
            BRS.ComPort.createInfoReceivedEvent();
            BRS.ComPort.DataReceivedAction = DataReceiverHandling;
            BRS.ComPort.startPortUpdater();
            Debug.Success("");

            BRS.Debug.Comment("Updating buttons and user header...");
            NewUserTextInfo("Serial Console",0);
            UpdateFileButton();
            UpdateLinkButton();
            UpdateSettingButton();
            UpdateConsole();
            Debug.Success("Updating finished");

            BRS.Debug.Header(false);
        }
        public void DataReceiverHandling()
        {
            //tell text changed event that a reception made it change
            TextChangedOnRX = true;

            //Gather stored data in the buffer
            string result = BRS.ComPort.Port.ReadExisting();

            ConsoleArea.SelectionColor = Color.GreenYellow;
            ConsoleArea.AppendText(result);
            ConsoleArea.SelectionColor = Color.Aqua;
        }
        private void _Load(object sender, EventArgs e)
        {
            _form_resize._get_initial_size();
        }
        private void _Resize(object sender, EventArgs e)
        {
            _form_resize._resize();
        }
        //#############################################################//
        //#############################################################//

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        public void UpdateFileButton()
        {
            BRS.Debug.Comment("Updating file button...");

            if(BRS.ComPort.Port.IsOpen)
            {
                BRS.Debug.Comment("port opened, verifying file path...");
                if(File.Exists(FilePath))
                {
                    Debug.Success("File available, ready for download.");
                    FileButton.Enabled = true;
                    FileButton.ToolTipText = "Send your file in the opened port";
                    FileButton.Image = Properties.Resources.icons8_error_file_100;
                    Debug.Success("");
                }
                else
                {
                    Debug.Error("File selected does not exist, presenting error file.");
                    FileButton.Enabled = false;
                    FileButton.ToolTipText = "Selected file cannot be reached";
                    FileButton.Image = Properties.Resources.icons8_error_file_100;
                    Debug.Success("");
                }
            }
            else
            {
                BRS.Debug.Comment("Port is closed, disabling file button...");
                FileButton.Enabled = false;
                FileButton.ToolTipText = "Port must be opened to use this function";
                FileButton.Image = Properties.Resources.icons8_file_100;
                Debug.Success("");
            }
        }
        //#############################################################//
        //#############################################################//
        public void UpdateLinkButton()
        {
            BRS.Debug.Comment("Updating Link button... checking for serial port");

            if(BRS.ComPort.Port.IsOpen)
            {
                Debug.Success("Link established");
                SerialLinkButon.ToolTipText = "Close opened serial port.";
                SerialLinkButon.Image = Properties.Resources.icons8_link_100__1_;
            }
            else
            {
                Debug.Error("No links!");
                SerialLinkButon.ToolTipText = "Attempt to open serial port";
                SerialLinkButon.Image = Properties.Resources.icons8_broken_link_100__2_;
            }
        }
        //#############################################################//
        //#############################################################//
        public void UpdateSettingButton()
        {
            BRS.Debug.Comment("Update settings icon... Checking for serial port");

            if(BRS.ComPort.Port.IsOpen)
            {
                Debug.Success("Port opened, settings cannot be changed");
                SettingsButton.ToolTipText = "Close port to change settings";
                SettingsButton.Enabled = false;
                SettingsButton.Image = Properties.Resources.icons8_settings_disabled_100__1_;
            }
            else
            {
                Debug.Success("Port closed, settings can be changed");
                SettingsButton.ToolTipText = "Change port settings";
                SettingsButton.Enabled = true;
                SettingsButton.Image = Properties.Resources.icons8_settings_100;
            }
        }
        //#############################################################//
        //#############################################################//
        public void UpdateConsole()
        {
            BRS.Debug.Comment("Updating Console environnement... Checking for serial port");

            if (BRS.ComPort.Port.IsOpen)
            {
                Debug.Success("Port opened, Console can be edited");
                ConsoleArea.Enabled = true;
            }
            else
            {
                Debug.Success("Port closed, console cannot be edited.");
                ConsoleArea.Enabled = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// changes the programmer's global text with the specified one
        /// 0: normal, 1: Green, 2: red, 3: warning orange
        /// </summary>
        /// <param name="info"></param>
        /// <param name="style"></param>
        //#############################################################// 
        private void NewUserTextInfo(string info, int style)
        {
            BRS.Debug.Comment("Changing user header info...");
            switch (style)
            {
                case 0: UserInfo.ForeColor = Color.FromArgb(100, 100, 100); break; // Neutral
                case 1: UserInfo.ForeColor = Color.FromArgb(60, 255, 60); break; // Good!
                case 2: UserInfo.ForeColor = Color.FromArgb(255, 60, 60); break; // Bad
                case 3: UserInfo.ForeColor = Color.FromArgb(255, 125, 60); break; // Attempting
            }

            UserInfo.Text = info;
            Debug.Success("");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Periodic100msTimer_Tick(object sender, EventArgs e)
        {

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Opening setting's dialog...");
            ConsoleSetting settings = new ConsoleSetting(this);
            settings.ShowDialog();

            BRS.Debug.Header(false);
        }
    }
}
