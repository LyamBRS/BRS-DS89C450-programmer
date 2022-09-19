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
        Form1 programmerForm;

        bool AutoProgrammingState = false;
        bool AutoConnecting = false;

        public ProgrammerSettings(Form1 form)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initialising programmer form's settings...");
            InitializeComponent();
            BRS.Debug.Success("");

            programmerForm = form;

            BRS.Debug.Comment("Setting initial checkbox states...");
            AutoProgrammingState = programmerForm.GetAutoProgrammingState();
            AutoConnecting = programmerForm.GetAutoConnectingState();

            UpdateCheckState(AutoProgrammingCheckBox, AutoProgrammingState);
            UpdateCheckState(DeviceDetectionCheckBox, AutoConnecting);
            BRS.Debug.Success("");

            BRS.Debug.Header(false);
        }

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
