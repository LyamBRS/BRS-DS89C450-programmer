using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRS_Dallas_Programmer
{
    public partial class ProgrammerSettings : Form
    {
        Form1 programmerForm;

        public ProgrammerSettings(Form1 form)
        {
            InitializeComponent();
            programmerForm = form;
            AutoProgramming.CheckState = programmerForm.GetAutoProgrammingState() ? CheckState.Checked : CheckState.Unchecked;
        }

        private void AutoProgramming_CheckedChanged(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Flipping autoprogramming flag");
            programmerForm.SetAutoProgrammingState(AutoProgramming.CheckState == CheckState.Checked);
            BRS.Debug.Success("");
            BRS.Debug.Header(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Closing settings...");
            BRS.Debug.Header(false);
            programmerForm.FlipSettingShowingState();
            this.Close();
        }
    }
}
