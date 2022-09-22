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

        public static bool ParseReturnCheckBox = true;
        public static bool ShowUserTX = false;

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

        public SerialConsole serialConsoleRef;
        public delegate void dlgThread(String Result);
        public dlgThread Delegate;

        public static bool oldPortState = false;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        public SerialConsole()
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initializing console's components...");
            InitializeComponent();
            serialConsoleRef = this;
            Delegate = new dlgThread(RXConsoleText);
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
        //#############################################################//
        //#############################################################//
        public void DataReceiverHandling()
        {
            //tell text changed event that a reception made it change
            TextChangedOnRX = true;

            //Gather stored data in the buffer
            string result = BRS.ComPort.Port.ReadExisting();

            try
            {
                serialConsoleRef.Invoke(serialConsoleRef.Delegate, result);
            }
            catch
            {
                BRS.ComPort.DataReceivedAction = EmptyReceivingHandler;
            }
        }
        //#############################################################//
        /// <summary>
        /// Function to replace ComPort.DataReceivedAction so an empty
        /// function is called rather than putting text in an
        /// inexisting console rich text box.
        /// </summary>
        //#############################################################//
        public void EmptyReceivingHandler()
        {

        }
        //#############################################################//
        /// <summary>
        /// Parses the received text from ComPort.Port in the console
        /// rich text box.
        /// Raises the receiving flag so the textchanged event does not
        /// occur.
        /// </summary>
        /// <param name="received">serial buffer</param>
        //#############################################################//
        private void RXConsoleText(string received)
        {
           //Raise flag so textchanged does not parse latest input as user input
           TextChangedOnRX = true;
           ConsoleArea.SelectionStart = ConsoleArea.Text.Length;
           //ConsoleArea.SelectionLength = received.Length;
           ConsoleArea.SelectionColor = Color.LightGreen;

            if (received.StartsWith("\r") && ParseReturnCheckBox)
            {
                int LineIndex = ConsoleArea.GetLineFromCharIndex(ConsoleArea.SelectionStart);
                int firstFromLine = ConsoleArea.GetFirstCharIndexFromLine(LineIndex);

                ConsoleArea.SelectionStart = firstFromLine;
                ConsoleArea.SelectionLength = ConsoleArea.Text.Length - firstFromLine;
                ConsoleArea.SelectedText = "";

                received = received.Replace('\r',' ');
                received = received.Replace('\n',' ');
            }

            ConsoleArea.SelectedText = received;
            ConsoleArea.SelectionStart = ConsoleArea.Text.Length;
            ConsoleArea.SelectionColor = Color.Aqua;

            //Lowering transmission flag for user inputs to show in console
            TextChangedOnRX = false;
        }
        //#############################################################//
        //#############################################################//
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
        public bool GetReturnParsing()
        {
            return (ParseReturnCheckBox);
        }
        public bool GetUSerTX()
        {
            return (ShowUserTX);
        }
        public void SetReturnParsing(bool state)
        {
            ParseReturnCheckBox = state;
        }
        public void SetUSerTX(bool state)
        {
            ShowUserTX = state;
        }
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
                    FileButton.Image = Properties.Resources.icons8_file_download_100;
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
        //#############################################################//
        //#############################################################//
        public void UpdateAllIcons()
        {
            BRS.Debug.Comment("Updating all the buttons");
            UpdateConsole();
            UpdateSettingButton();
            UpdateLinkButton();
            UpdateLinkButton();
            UpdateFileButton();
            Debug.Success("All icons were updated!");
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
        //#############################################################//
        /// <summary>
        /// Constantly check if comport is still opened, if not, update
        /// all the buttons plus the console
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void Periodic100msTimer_Tick(object sender, EventArgs e)
        {
            if(BRS.ComPort.Port.IsOpen != oldPortState)
            {
                oldPortState = BRS.ComPort.Port.IsOpen;
                UpdateAllIcons();
                NewUserTextInfo(oldPortState ? "Port opened" : "Link closed unexpectedly", 3);
            }
        }
        //#############################################################//
        /// <summary>
        /// Function slowly fading out UserInfoText until it is not
        /// showing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void TextColorFading_Tick(object sender, EventArgs e)
        {
            int R = UserInfo.ForeColor.R;
            int G = UserInfo.ForeColor.G;
            int B = UserInfo.ForeColor.B;

            if (R > 2) { R-=2; }
            if (G > 2) { G-=2; }
            if (B > 2) { B-=2; }

            UserInfo.SelectionStart = 0;
            UserInfo.SelectionLength = 0;
            UserInfo.ForeColor = Color.FromArgb(R, G, B);
            ConsoleArea.Focus();
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
        //#############################################################//
        //#############################################################//
        private void SerialLinkButon_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Checking if port is opened or closed.");
            if (!BRS.ComPort.Port.IsOpen)
            {
                BRS.Debug.Comment("Attempting linking with specified COM port...");
                BRS.Debug.Comment("Port name: " + BRS.ComPort.Port.PortName.ToString());
                BRS.Debug.Comment("BaudRate:  " + BRS.ComPort.Port.BaudRate.ToString());
                BRS.Debug.Comment("DataBits:  " + BRS.ComPort.Port.DataBits.ToString());
                BRS.Debug.Comment("StopBits:  " + BRS.ComPort.Port.StopBits.ToString());
                BRS.Debug.Comment("Parity:    " + BRS.ComPort.Port.Parity.ToString());
                BRS.Debug.Comment("HandShake: " + BRS.ComPort.Port.Handshake.ToString());
                try
                {
                    BRS.ComPort.Port.Open();
                    oldPortState = true;
                    Debug.Success("Port opened!");
                    NewUserTextInfo("Linked!", 1);
                }
                catch
                {
                    Debug.Error("FAILED TO OPEN COM PORT WITH SPECIFIED INFO");
                    NewUserTextInfo("LINKING ERROR", 2);
                }
            }
            else
            {
                BRS.Debug.Comment("Closing COM...");
                try
                {
                    BRS.ComPort.Port.Close();
                    oldPortState = false;
                    Debug.Success("Port closed!");
                    NewUserTextInfo("Port closed", 1);
                }
                catch
                {
                    Debug.Error("FAILED TO OPEN COM PORT WITH SPECIFIED INFO");
                    NewUserTextInfo("LINKING ERROR", 2);
                }
            }
            BRS.Debug.Comment("Updating icons...");
            UpdateAllIcons();

            BRS.Debug.Header(false);
        }
        //#############################################################//
        //#############################################################//
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Handling file dialog...");
            FilePath = BRS.Dialog.OpenFile("[BRS]: Open your hex file", "HEX file (*.hex)|*.hex| txt files (*.txt)|*.txt");

            if (File.Exists(FilePath))
            {
                NewUserTextInfo("File good for download.", 1);
            }
            else
            {
                NewUserTextInfo("Invalid file", 2);
            }
            BRS.Debug.Success("");
            UpdateAllIcons();
            BRS.Debug.Header(false);
        }
        //#############################################################//
        //#############################################################//
        private void ClearConsoleButton_Click(object sender, EventArgs e)
        {
            NewUserTextInfo("Cleared!", 2);
            SystemSounds.Asterisk.Play();
            ConsoleArea.Text = "";
        }
        //#############################################################//
        //#############################################################//
        private void FileButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Trying to send file...");

            if(File.Exists(FilePath))
            {
                if(BRS.ComPort.Port.IsOpen)
                {
                    NewUserTextInfo("Sending file...", 3);
                    BRS.Debug.Comment("Sending file on comport...");
                    this.Refresh();

                    string Text = File.ReadAllText(FilePath);
                    BRS.Debug.Comment("Writing on port...");
                    try
                    {
                        BRS.ComPort.SendFile(Text);
                        Debug.Success("File sent!");
                        NewUserTextInfo("Success!", 1);
                    }
                    catch
                    {
                        NewUserTextInfo("Sending Error!", 2);
                        Debug.Error("ERROR sending file could no be done");
                    }
                }
                else
                {
                    Debug.Error("Could not send file, port closed");
                    NewUserTextInfo("Port closed!", 2);
                }
            }
            else
            {
                Debug.Error("Could not send file, file cant be reached");
                NewUserTextInfo("File does not exist!",2);
            }
            BRS.Debug.Header(false);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        private void SerialConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            BRS.Debug.Comment("Key press");
            if (ConsoleArea.Enabled)
            {
                ConsoleArea.SelectionStart = ConsoleArea.Text.Length;
                ConsoleArea.SelectionColor = Color.Aqua;

                if (ShowUserTX)
                {
                    ConsoleArea.SelectedText = e.KeyChar.ToString();
                }

                // Send text
                BRS.ComPort.Port.Write(e.KeyChar.ToString());

                ConsoleArea.SelectionStart = ConsoleArea.Text.Length;
                ConsoleArea.SelectionColor = Color.Aqua;

                //Lowering transmission flag for user inputs to show in console
                TextChangedOnRX = false;
            }
        }

        private void SerialConsole_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void SerialConsole_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
