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

namespace BRS_Dallas_Programmer
{
    public partial class MainMenu : Form
    {
        Form1 programming = new Form1();
        SerialConsole serialConsole = new SerialConsole();
        public MainMenu()
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Inializing components of form 2");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Setting FTDI port to new default serial port");
            BRS.FTDI.FTDIPort = serialPort1;
            BRS.Debug.Success("");

            BRS.Debug.Comment("Setting Console port to new default serial port");
            BRS.ComPort.Port = serialPort2;
            BRS.Debug.Success("");

            BRS.Debug.Header(false);
        }

        //#############################################################//
        /// <summary>
        /// Closes all opened form associated with BRS Dallas Programmer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Quit_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Closing the application...");
            programming.Close();
            this.Close();
            BRS.Debug.Header(false);
        }

        //#############################################################//
        /// <summary>
        /// Opens the DS89C450's programmer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Programmer_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Calling Programmer form...");
            programming = new Form1();
            programming.Show();

            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Handling changes in FTDI state, as other forms cannot
        /// handle serial ports. This is Derelect attempt at referencing
        /// ports over forms. However, it is kept here in case it's
        /// function was crucial, as I do not remember
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void CheckFormsFlags_Tick(object sender, EventArgs e)
        {
            //Update FTDI specs
            if (!BRS.FTDI.FTDIComName.Equals("No Device"))
            {
                //Check if serialport is opened
                if (!BRS.FTDI.FTDIPort.IsOpen)
                {
                    if (!BRS.FTDI.FTDIPort.PortName.Equals(BRS.FTDI.FTDIComName) && !BRS.FTDI.FTDIComName.Equals("No Device"))
                    {
                        BRS.Debug.Comment("SETTING NEW FTDI PORT NAME");
                        BRS.FTDI.FTDIPort.PortName = BRS.FTDI.FTDIComName;
                    }
                }
            }
        }
        //#############################################################//
        /// <summary>
        /// Loading event starting the FTDI updater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void MainMenu_Load(object sender, EventArgs e)
        {
            BRS.FTDI.startFTDIUpdater();
            BRS.FTDI.LookForFTDI();
        }

        //#############################################################//
        /// <summary>
        /// Displays Quit below the main menu's buttons
        /// when the user mouse hover's over Quit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Quit_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Quit";
            ButtonText.ForeColor = Color.FromArgb(255, 100, 100);
        }
        //#############################################################//
        /// <summary>
        /// Displays Serial Terminal below the main menu's buttons
        /// when the user mouse hover's over Console button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Console_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Serial Terminal";
            ButtonText.ForeColor = Color.FromArgb(255,255,255);
        }
        //#############################################################//
        /// <summary>
        /// Displays Dallas Programmer below the main menu's buttons
        /// when the user mouse hover's over Programmer button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Programmer_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Dallas Programmer";
            ButtonText.ForeColor = Color.FromArgb(90, 190, 255);
        }
        //#############################################################//
        /// <summary>
        /// Empties the text below buttons when the mouse is leaving
        /// hovering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            ButtonText.ForeColor = Color.FromArgb(100, 100, 100);
        }
        //#############################################################//
        /// <summary>
        /// Display's what this application is all about when hovering
        /// over my BRS logo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void button1_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "[BRS] Auto Dallas Prog & Better Terminal";
            ButtonText.ForeColor = Color.FromArgb(100, 100, 100);
        }
        //#############################################################//
        /// <summary>
        /// Open's SerialConsole form when clicking on the Console button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Console_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Opening console viewer...");
            serialConsole = new SerialConsole();
            serialConsole.Show();

            BRS.Debug.Header(false);
        }
    }
}
