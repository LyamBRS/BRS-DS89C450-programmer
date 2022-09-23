using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace BRS_Dallas_Programmer
{
    public partial class ProgrammerSettings : Form
    {
        /// <summary>
        /// Reference to the programmer's form
        /// </summary>
        Form1 programmerForm;

        /// <summary>
        /// Reference flag given by programmerForm deciding if it should attempt automatic programming depending on certain events
        /// </summary>
        bool AutoProgrammingState = false;

        /// <summary>
        /// Reference flag given by programmerForm deciding if it should attempt automatic connection depending on certain events
        /// </summary>
        bool AutoConnecting = false;

        //#############################################################//
        /// <summary>
        /// Programmer's setting form constructor
        /// </summary>
        /// <param name="form">Reference to the programmer's form</param>
        //#############################################################//
        public ProgrammerSettings(Form1 form)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initialising programmer form's settings...");
            InitializeComponent();
            BRS.Debug.Success("");

            BRS.Debug.Comment("Referencing programmer's form.");
            programmerForm = form;

            BRS.Debug.Comment("Setting initial checkbox states...");
            AutoProgrammingState = programmerForm.GetAutoProgrammingState();
            AutoConnecting = programmerForm.GetAutoConnectingState();

            UpdateCheckState(AutoProgrammingCheckBox, AutoProgrammingState);
            UpdateCheckState(DeviceDetectionCheckBox, AutoConnecting);
            BRS.Debug.Success("");

            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Quit event, closing the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void button3_Click(object sender, EventArgs e)
        {
            BRS.Debug.LocalStart(true);
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Closing settings...");
            programmerForm.FlipSettingShowingState();

            BRS.Debug.Header(false);
            BRS.Debug.LocalEnd();
            this.Close();
        }









        //#############################################################//
        /// <summary>
        /// Flip the autoProgramming flag, and update's the form's
        /// checkbox image to the new state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void AutoProgrammingCheckBox_Click(object sender, EventArgs e)
        {
            BRS.Debug.LocalStart(true);
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Flipping AutoProgramming setting state...");
            AutoProgrammingState = !AutoProgrammingState;

            BRS.Debug.Comment("Updating form's settings...");
            programmerForm.SetAutoProgrammingState(AutoProgrammingState);

            BRS.Debug.Comment("Updating setting's form button...");
            UpdateCheckState(AutoProgrammingCheckBox, AutoProgrammingState);

            BRS.Debug.Header(true);
            BRS.Debug.LocalEnd();
        }
        //#############################################################//
        /// <summary>
        /// Flip the Automatic device detection flag, and update's 
        /// the form's checkbox image to the new state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void DeviceDetectionCheckBox_Click(object sender, EventArgs e)
        {
            BRS.Debug.LocalStart(true);
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Flipping AutoConnecting setting state...");
            AutoConnecting = !AutoConnecting;

            BRS.Debug.Comment("Updating form's settings...");
            programmerForm.SetAutoConnectingState(AutoConnecting);

            BRS.Debug.Comment("Updating setting's form button...");
            UpdateCheckState(DeviceDetectionCheckBox, AutoConnecting);

            BRS.Debug.Header(true);
            BRS.Debug.LocalEnd();
        }
        //#############################################################//
        /// <summary>
        /// Update a specified button with a checked or unchecked
        /// checkbox image depending on the wanted state.
        /// </summary>
        /// <param name="button">Form's button to change</param>
        /// <param name="state">true: Checked. false: unchecked</param>
        //#############################################################//
        private void UpdateCheckState(Button button, bool state)
        {
            BRS.Debug.LocalStart(true);
            
            if(state)
            {
                BRS.Debug.Comment("Setting " + button.Name + " to TRUE state.");
                button.BackgroundImage = Properties.Resources.icons8_checked_checkbox_100;
                this.Refresh();
                BRS.Debug.Success("");
            }
            else
            {
                BRS.Debug.Comment("Setting " + button.Name + " to FALSE state.");
                button.BackgroundImage = Properties.Resources.icons8_unchecked_checkbox_100;
                this.Refresh();
                BRS.Debug.Success("");
            }

            BRS.Debug.LocalEnd();
        }
    }
}
