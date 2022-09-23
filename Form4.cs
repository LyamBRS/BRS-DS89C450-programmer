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
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace BRS_Dallas_Programmer
{
    public partial class ConsoleSetting : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// SerialConsole's form reference. Used to call functions declared in it.
        /// </summary>
        SerialConsole console;

        public static string SelectedComFullName = "No Device";
        public static string SelectedComName = "No Device";

        /// <summary>
        /// Flag raised when combo boxes need to be cleared and re-initialised
        /// </summary>
        public static bool UpdateDropDown = false;

        /// <summary>
        /// Flag set to a value preventing the parsing of combo boxes until
        /// DeviceChangedEvent stops occuring.
        /// </summary>
        public static int TimeUntilDropDownUpdate = 0;

        /// <summary>
        /// Flag given by SerialConsole deciding if KeyPress are to be shown in the console
        /// </summary>
        public static bool UserTX = false;

        /// <summary>
        /// Flag given by SerialConsole deciding if \r are to be parsed as carriage returns or new line feed.
        /// </summary>
        public static bool ParseReturn = false;

        SerialPort OldSettings;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// Constructor of SerialConsole's Setting form. Creates
        /// ListChanged event for ListOfPortChanged of ComPort.
        /// Initialises ComboBoxe's values.
        /// </summary>
        /// <param name="refConsole"></param>
        //#############################################################//
        public ConsoleSetting(SerialConsole refConsole)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initializing setting's components");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Creating list changes handler");
            BRS.ComPort.ListOfPortChanged.CollectionChanged += ListChanged;
            BRS.ComPort.StoreAllAvailableComs();

            BRS.Debug.Comment("Refering console form:");
            console = refConsole;
            Debug.Success("");

            BRS.Debug.Comment("Creating setting variables...");
            OldSettings = BRS.ComPort.Port;
            Debug.Success("");

            BRS.Debug.Comment("Changing setting boxes variables.");
            InnitComDropDown();
            InnitBaudRateBox();
            InnitStopBit();
            InnitParity();
            InnitFlowControl();
            InnitDataBit();
            InnitCheckBox();
            Debug.Success("");

            BRS.Debug.Header(false);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// Automatically sets custom checkboxes to the state of their
        /// associated flags given from SerialConsole's form.
        /// </summary>
        //#############################################################//
        private void InnitCheckBox()
        {
            UserTX = console.GetUSerTX();
            ParseReturn = console.GetReturnParsing();

            if(UserTX)
            {
                UserTXCheckBox.BackgroundImage = Properties.Resources.icons8_checked_checkbox_100;
            }
            else
            {
                UserTXCheckBox.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_100;
            }

            if (ParseReturn)
            {
                ParseReturnCheckBox.BackgroundImage = Properties.Resources.icons8_checked_checkbox_100;
            }
            else
            {
                ParseReturnCheckBox.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_100;
            }
        }
        //#############################################################//
        /// <summary>
        /// Automatically fill PortBox1 with all the available
        /// ports given by ComPort.AvailableComsFullName. 
        /// Sets the currently selected
        /// port to ComPort.Port's setting.
        /// </summary>
        //#############################################################//
        private void InnitComDropDown()
        {
            BRS.Debug.Comment("Clearing items...");
            PortBox1.Items.Clear();
            BRS.Debug.Comment("Adding names back...");
            foreach (string name in BRS.ComPort.AvailableComsFullName)
            {
                PortBox1.Items.Add(name);
            }

            if(!PortBox1.Items.Contains(BRS.ComPort.Port.PortName))
            {
                PortBox1.Items.Add("(" + BRS.ComPort.Port.PortName + ")");
                PortBox1.SelectedItem = "(" + BRS.ComPort.Port.PortName + ")";
            }
        }
        //#############################################################//
        /// <summary>
        /// Sets the currently selected
        /// BaudRate to ComPort.Port's setting.
        /// </summary>
        //#############################################################//        
        private void InnitBaudRateBox()
        {
            BaudRateBox.Text = OldSettings.BaudRate.ToString();
        }
        //#############################################################//
        /// <summary>
        /// Automatically fill StopBitBox with all the available
        /// SerialPort.StopBits. Sets the currently selected
        /// StopBits to ComPort.Port's setting.
        /// </summary>
        //#############################################################//
        private void InnitStopBit()
        {
            foreach (string name in Enum.GetNames(typeof(StopBits)))
                if (!name.Equals("None"))
                {
                    StopBitBox.Items.Add(name);
                    StopBitBox.Text = OldSettings.StopBits.ToString();
                }
        }
        //#############################################################//
        /// <summary>
        /// Automatically fill ParityBox with all the available
        /// SerialPort.Parity. Sets the currently selected
        /// parity to ComPort.Port's setting.
        /// </summary>
        //#############################################################//
        private void InnitParity()
        {
            foreach (string name in Enum.GetNames(typeof(Parity)))
            ParityBox.Items.Add(name);
            ParityBox.Text = OldSettings.Parity.ToString();
        }
        //#############################################################//
        /// <summary>
        /// Automatically fill FlowControlBox with all the available
        /// SerialPort.Handshake. Sets the currently selected
        /// handshake to ComPort.Port's setting.
        /// </summary>
        //#############################################################//
        private void InnitFlowControl()
        {
            foreach (string name in Enum.GetNames(typeof(Handshake)))
            FlowControlBox.Items.Add(name);
            FlowControlBox.Text = OldSettings.Handshake.ToString();
        }
        //#############################################################//
        /// <summary>
        /// Set's DataBit combo box with the current ComPort.Databits
        /// values.
        /// </summary>
        //#############################################################//
        private void InnitDataBit()
        {
            DataBitBox.Text = OldSettings.DataBits.ToString();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// Closes the form with no changes to ComPort.Port's settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void CancelButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Canceling changes");
            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Click event changing settings of ComPort.Port to the
        /// specified ones in this form's comboBoxes before closing
        /// the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Porting changes to ComPort...");
            BRS.ComPort.Port.BaudRate = Convert.ToInt32(BaudRateBox.Text);
            BRS.ComPort.Port.Parity = (Parity)ParityBox.SelectedIndex;
            BRS.ComPort.Port.Handshake = (Handshake)FlowControlBox.SelectedIndex;
            BRS.ComPort.Port.DataBits = Convert.ToInt32(DataBitBox.Text);

            BRS.ComPort.Port.StopBits = (StopBits)StopBitBox.SelectedIndex+1;

            try
            {
                BRS.ComPort.Port.PortName = PortBox1.Text.Split('(', ')')[1];
            }
            catch
            {
                BRS.ComPort.Port.PortName = "No Device";
            }

            BRS.Debug.Comment("Port name: " + PortBox1.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.PortName.ToString());
            BRS.Debug.Comment("BaudRate:  " + BaudRateBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.BaudRate.ToString());
            BRS.Debug.Comment("DataBits:  " + DataBitBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.DataBits.ToString());
            BRS.Debug.Comment("StopBits:  " + StopBitBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.StopBits.ToString());
            BRS.Debug.Comment("Parity:    " + ParityBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.Parity.ToString());
            BRS.Debug.Comment("HandShake: " + FlowControlBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.Handshake.ToString());

            console.SetUSerTX(UserTX);
            console.SetReturnParsing(ParseReturn);

            Debug.Success("Closing setting form");
            BRS.Debug.Header(false);

            this.Close();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// Event called when the PortBox list should be changed.
        /// Sets a "debounce" to 2 to avoid crashing when updating PortBox
        /// as if a thread updates the list while ittering through it,
        /// the form will crash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        public void ListChanged(object sender, EventArgs e)
        {
            BRS.Debug.Comment("Increasing <debounce> timer.");
            TimeUntilDropDownUpdate = 2;
            UpdateDropDown = true;
        }
        //#############################################################//
        /// <summary>
        /// Checks if PortBox needs updating, and that no more changes
        /// are occuring.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void UpdatePortList_Tick(object sender, EventArgs e)
        {
            if (UpdateDropDown && TimeUntilDropDownUpdate == 0)
            {
                BRS.Debug.Success("Innitialising com port drop down");
                InnitComDropDown();
                UpdateDropDown = false;
            }
            else if (TimeUntilDropDownUpdate > 0)
            {
                TimeUntilDropDownUpdate--;
            }

            // FORCE CLOSE FORM IF LINKED
            if(BRS.ComPort.Port.IsOpen)
            {
                BRS.Debug.Error("PORT OPENED, FORCE CLOSING CONSOLE SETTING FORM!");
                this.Close();
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        /// <summary>
        /// Flip the state of UserTXCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void UserTXCheckBox_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Flipping ShowUserTX state...");
            UserTX = !UserTX;
            Debug.Success("ShowUserTX is now " + UserTX.ToString());

            BRS.Debug.Comment("Updating checkbox icon");
            UpdateCheckState(UserTXCheckBox, UserTX);
            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Flip the state of ParseReturnCheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void ParseReturnCheckBox_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Flipping parsing return state...");
            ParseReturn = !ParseReturn;
            Debug.Success("ParseReturn is now " + ParseReturn.ToString());

            BRS.Debug.Comment("Updating checkbox icon");
            UpdateCheckState(ParseReturnCheckBox,ParseReturn);
            BRS.Debug.Header(false);
        }
        //#############################################################// 
        /// <summary>
        /// Changes the image of a custom button depending on specified
        /// state. If false, the button will have an unchecked grey image
        /// if true, the button will have a checked green image.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="state"></param>
        //#############################################################// 
        private void UpdateCheckState(Button button, bool state)
        {
            BRS.Debug.LocalStart(true);

            if (state)
            {
                BRS.Debug.Comment("Setting " + button.Name + " image to checked state.");
                button.BackgroundImage = Properties.Resources.icons8_checked_checkbox_100;
                BRS.Debug.Success("");
            }
            else
            {
                BRS.Debug.Comment("Setting " + button.Name + " image to unchecked state.");
                button.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_100;
                BRS.Debug.Success("");
            }

            BRS.Debug.LocalEnd();
        }
    }
}
