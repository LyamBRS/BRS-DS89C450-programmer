
namespace BRS_Dallas_Programmer
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Programmer = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.CheckFormsFlags = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ButtonText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.Programmer);
            this.flowLayoutPanel1.Controls.Add(this.Console);
            this.flowLayoutPanel1.Controls.Add(this.Quit);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            // 
            // Programmer
            // 
            this.Programmer.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_file_download_100;
            resources.ApplyResources(this.Programmer, "Programmer");
            this.Programmer.FlatAppearance.BorderSize = 0;
            this.Programmer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.Programmer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Programmer.Name = "Programmer";
            this.Programmer.UseVisualStyleBackColor = true;
            this.Programmer.Click += new System.EventHandler(this.Programmer_Click);
            this.Programmer.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.Programmer.MouseHover += new System.EventHandler(this.Programmer_MouseHover);
            // 
            // Console
            // 
            this.Console.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_console_100;
            resources.ApplyResources(this.Console, "Console");
            this.Console.FlatAppearance.BorderSize = 0;
            this.Console.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Console.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Console.Name = "Console";
            this.Console.UseVisualStyleBackColor = true;
            this.Console.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.Console.MouseHover += new System.EventHandler(this.Console_MouseHover);
            // 
            // Quit
            // 
            this.Quit.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_cancel_100;
            resources.ApplyResources(this.Quit, "Quit");
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Quit.Name = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            this.Quit.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.Quit.MouseHover += new System.EventHandler(this.Quit_MouseHover);
            // 
            // CheckFormsFlags
            // 
            this.CheckFormsFlags.Enabled = true;
            this.CheckFormsFlags.Tick += new System.EventHandler(this.CheckFormsFlags_Tick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.BRS_Header;
            resources.ApplyResources(this.button1, "button1");
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // ButtonText
            // 
            this.ButtonText.BackColor = System.Drawing.Color.Black;
            this.ButtonText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ButtonText.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.ButtonText, "ButtonText");
            this.ButtonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonText.Name = "ButtonText";
            // 
            // MainMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.ButtonText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Programmer;
        private System.Windows.Forms.Button Console;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Timer CheckFormsFlags;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox ButtonText;
    }
}