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
using System.Net;
using System.Net.NetworkInformation;

namespace BRS_Dallas_Programmer
{
    public partial class MainMenu : Form
    {
        /// <summary>
        /// The original height of this form
        /// </summary>
        int OriginalHeight;
        int OriginalWidth;

        /// <summary>
        /// wanted drop offset
        /// </summary>
        int WantedSize = 0;

        /// <summary>
        /// Flag deciding if the form should expand or retract to display my informations below the buttons
        /// </summary>
        bool DisplayInformations = false;

        Form1 programming = new Form1();
        SerialConsole serialConsole = new SerialConsole();
        UDPNetwork udpForm;

        public MainMenu()
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Inializing components of form 2");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Setting FTDI port to new default serial port");
            BRS.FTDI.FTDIPort = serialPort1;
            Debug.Success("");

            BRS.Debug.Comment("Setting Console port to new default serial port");
            BRS.ComPort.Port = serialPort2;
            Debug.Success("");

            BRS.Debug.Comment("Getting original size of this form");
            OriginalHeight = this.Size.Height;
            OriginalWidth = this.Size.Width;
            WantedSize = OriginalHeight;
            Debug.Success("");

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
        /// Changes the form's sizes to display/hide informations located
        /// below the form's original size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void InformationButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Flipping DisplayInformation flag...");
            DisplayInformations = !DisplayInformations;
            Debug.Success("Flag is now " + DisplayInformations.ToString());

            BRS.Debug.Comment("Specifying wanted form's size");
            if (DisplayInformations)
            {
                BRS.Debug.Comment("Expanding form by 500 pixels...");
                WantedSize = OriginalHeight + 180;
            }
            else
            {
                BRS.Debug.Comment("Reverting form's to original size");
                WantedSize = OriginalHeight;
            }

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
        private void Quit_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Quit";
            ButtonText.ForeColor = Color.FromArgb(255, 100, 100);
            Quit.BackgroundImage = Properties.Resources.icons8_cancel_Selected;
        }
        private void Quit_MouseLeave(object sender, EventArgs e)
        {
            Quit.BackgroundImage = Properties.Resources.icons8_cancel_100;
        }
        //#############################################################//
        /// <summary>
        /// Displays Serial Terminal below the main menu's buttons
        /// when the user mouse hover's over Console button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Console_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Serial Terminal";
            ButtonText.ForeColor = Color.FromArgb(255, 255, 255);
            Console.BackgroundImage = Properties.Resources.icons8_console_100;
        }
        private void Console_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            Console.BackgroundImage = Properties.Resources.icons8_console_Normal;
        }
        //#############################################################//
        /// <summary>
        /// Displays Dallas Programmer below the main menu's buttons
        /// when the user mouse hover's over Programmer button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Programmer_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Dallas Programmer";
            ButtonText.ForeColor = Color.FromArgb(90, 190, 255);
            Programmer.BackgroundImage = Properties.Resources.icons8_file_download_Selected;
        }
        private void Programmer_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            Programmer.BackgroundImage = Properties.Resources.icons8_file_download_100;
        }
        //#############################################################//
        /// <summary>
        /// Displays Information below the main menu's buttons
        /// when the user mouse hover's over Informationbutton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void InformationButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Information";
            ButtonText.ForeColor = Color.FromArgb(90, 190, 255);
            InformationButton.BackgroundImage = Properties.Resources.icons8_info_Selected;
        }
        private void InformationButton_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            InformationButton.BackgroundImage = Properties.Resources.icons8_info_100;
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
        /// Empties the text below buttons when the mouse is leaving
        /// hovering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void FlowInfoIcons_MouseLeave(object sender, EventArgs e)
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
        /// Display's the name of the application for UDP Network
        /// terminal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void UDPNetworkInterface_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "UDP Network Terminal";
            ButtonText.ForeColor = Color.FromArgb(255, 255, 255);
            UDPNetworkInterface.BackgroundImage = Properties.Resources.icons8_stack_Selected;
        }
        private void UDPNetworkInterface_MouseLeave(object sender, EventArgs e)
        {
            UDPNetworkInterface.BackgroundImage = Properties.Resources.icons8_stack_100;
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
        //#############################################################//
        /// <summary>
        /// Slow appearance of the bottom portion of this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void FormExpansionTimer_Tick(object sender, EventArgs e)
        {
            //Lock info icon's flowcontrol's location
            FlowInfoIcons.Location = new Point(10, 312);
            ButtonText.Location = new Point(17, 275);

            int formHeight = this.Size.Height;

            float fWantedSize = (float)WantedSize;
            float fFormHeight = (float)formHeight;

            //Lerp form's height to the wanted value
            if (fFormHeight != fWantedSize)
            {
                fFormHeight = Lerp(fFormHeight, fWantedSize, 0.1f);

                this.Size = new Size(OriginalWidth, (int)fFormHeight);
            }
        }

        float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        //#############################################################//
        /// <summary>
        /// Hovering above the discord logo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void Discord_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Contact us through BRS's Discord";
            ButtonText.ForeColor = Color.FromArgb(190, 90, 255);
            Discord.BackgroundImage = Properties.Resources.icons8_discord_Selected;
        }
        private void Discord_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            Discord.BackgroundImage = Properties.Resources.icons8_discord_new_100;
        }
        //#############################################################//
        private void GitHub_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Lyam's GitHub";
            ButtonText.ForeColor = Color.FromArgb(190, 190, 190);
            GitHub.BackgroundImage = Properties.Resources.icons8_github_normal;
        }
        private void GitHub_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            GitHub.BackgroundImage = Properties.Resources.icons8_github_100;
        }
        //#############################################################//
        private void Steam_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "BRS's Steam page";
            ButtonText.ForeColor = Color.FromArgb(190, 190, 255);
            Steam.BackgroundImage = Properties.Resources.icons8_steam_circled_100;
        }
        private void Steam_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            Steam.BackgroundImage = Properties.Resources.icons8_steam_circled_Normal;
        }
        //#############################################################//
        private void Mail_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "Contact us via e-mail";
            ButtonText.ForeColor = Color.FromArgb(255, 100, 100);
            Mail.BackgroundImage = Properties.Resources.icons8_mail_Selected;
        }
        private void Mail_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            Mail.BackgroundImage = Properties.Resources.icons8_mail_100;
        }
        //#############################################################//
        /// <summary>
        /// Opens BRS's Discord on the default web browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void Discord_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://discord.gg/HCYFEt2FUB");
            }
            catch
            {
                ButtonText.Text = "Can't Open Lyam[BRS]'s Github";
                ButtonText.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        //#############################################################//
        /// <summary>
        /// Opens BRS's GitHub on the default web browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void GitHub_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/LyamBRS");
            }
            catch
            {
                ButtonText.Text = "Can't Open Lyam[BRS]'s Github";
                ButtonText.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        //#############################################################//
        /// <summary>
        /// Opens BRS's Steam page on the default web browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void Steam_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://steamcommunity.com/id/gothilawn");
            }
            catch
            {
                ButtonText.Text = "Can't Open Lyam's Steam Page";
                ButtonText.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        //#############################################################//
        /// <summary>
        /// Opens BRS's Email on the default web browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void Mail_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText("lyam.BRS@gmail.com");
                ButtonText.Text = "Copied email to clipboard!";
                ButtonText.ForeColor = Color.FromArgb(0, 255, 0);
            }
            catch
            {
                ButtonText.Text = "Can't Open Lyam[BRS]'s gmail";
                ButtonText.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        //#############################################################//
        /// <summary>
        /// Opens icon 8. Source for icons used in this project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void Icons8_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://icons8.com/icons");
            }
            catch
            {
                ButtonText.Text = "Can't Open icons8 website";
                ButtonText.ForeColor = Color.FromArgb(255, 0, 0);
            }
        }
        private void Icons8_MouseEnter(object sender, EventArgs e)
        {
            ButtonText.Text = "icons8.com Source for the icons used.";
            ButtonText.ForeColor = Color.FromArgb(0, 255, 0);
            Icons8.BackgroundImage = Properties.Resources.icons8_icons8_Selected;
        }
        private void Icons8_MouseLeave(object sender, EventArgs e)
        {
            Icons8.BackgroundImage = Properties.Resources.icons8_icons8_default;
        }
        //#############################################################//
        /// <summary>
        /// Opens the UDP network terminal form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################// 
        private void UDPNetworkInterface_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            string hostName = Dns.GetHostName();
            BRS.Debug.Comment("HOST: \t" + hostName);

            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            foreach (IPAddress address in addresses)
            {
                string addressName = address.ToString();
                string header = "\t";

                BRS.Debug.Comment(addressName + "\t" + address.AddressFamily.ToString());
            }

            BRS.Debug.Comment(System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable().ToString());
            System.Net.NetworkInformation.NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in interfaces)
            {
                string addressName = Interface.Name;
                string header = "\t";

                BRS.Debug.Comment(addressName + "\t" + Interface.Description);
            }

            udpForm = new UDPNetwork();
            udpForm.ShowDialog();

            BRS.Debug.Header(false);
        }
    }
}
