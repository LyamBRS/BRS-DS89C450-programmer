
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
            this.CheckFormsFlags = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ButtonText = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.FormExpansionTimer = new System.Windows.Forms.Timer(this.components);
            this.FlowInfoIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.Discord = new System.Windows.Forms.Button();
            this.GitHub = new System.Windows.Forms.Button();
            this.Steam = new System.Windows.Forms.Button();
            this.Mail = new System.Windows.Forms.Button();
            this.Icons8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Programmer = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.Button();
            this.InformationButton = new System.Windows.Forms.Button();
            this.UDPNetworkInterface = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.FlowInfoIcons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.Programmer);
            this.flowLayoutPanel1.Controls.Add(this.Console);
            this.flowLayoutPanel1.Controls.Add(this.InformationButton);
            this.flowLayoutPanel1.Controls.Add(this.UDPNetworkInterface);
            this.flowLayoutPanel1.Controls.Add(this.Quit);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            // 
            // CheckFormsFlags
            // 
            this.CheckFormsFlags.Enabled = true;
            this.CheckFormsFlags.Tick += new System.EventHandler(this.CheckFormsFlags_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.WriteTimeout = 500;
            // 
            // ButtonText
            // 
            resources.ApplyResources(this.ButtonText, "ButtonText");
            this.ButtonText.BackColor = System.Drawing.Color.Black;
            this.ButtonText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ButtonText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ButtonText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ButtonText.Name = "ButtonText";
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM2";
            this.serialPort2.ReadTimeout = 500;
            this.serialPort2.WriteTimeout = 500;
            // 
            // FormExpansionTimer
            // 
            this.FormExpansionTimer.Enabled = true;
            this.FormExpansionTimer.Interval = 10;
            this.FormExpansionTimer.Tick += new System.EventHandler(this.FormExpansionTimer_Tick);
            // 
            // FlowInfoIcons
            // 
            resources.ApplyResources(this.FlowInfoIcons, "FlowInfoIcons");
            this.FlowInfoIcons.Controls.Add(this.Discord);
            this.FlowInfoIcons.Controls.Add(this.GitHub);
            this.FlowInfoIcons.Controls.Add(this.Steam);
            this.FlowInfoIcons.Controls.Add(this.Mail);
            this.FlowInfoIcons.Controls.Add(this.Icons8);
            this.FlowInfoIcons.Name = "FlowInfoIcons";
            this.FlowInfoIcons.MouseLeave += new System.EventHandler(this.FlowInfoIcons_MouseLeave);
            // 
            // Discord
            // 
            this.Discord.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_discord_new_100;
            resources.ApplyResources(this.Discord, "Discord");
            this.Discord.FlatAppearance.BorderSize = 0;
            this.Discord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(96)))), ((int)(((byte)(255)))));
            this.Discord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Discord.Name = "Discord";
            this.Discord.UseVisualStyleBackColor = true;
            this.Discord.Click += new System.EventHandler(this.Discord_Click);
            this.Discord.MouseEnter += new System.EventHandler(this.Discord_MouseEnter);
            this.Discord.MouseLeave += new System.EventHandler(this.Discord_MouseLeave);
            // 
            // GitHub
            // 
            this.GitHub.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_github_100;
            resources.ApplyResources(this.GitHub, "GitHub");
            this.GitHub.FlatAppearance.BorderSize = 0;
            this.GitHub.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.GitHub.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GitHub.Name = "GitHub";
            this.GitHub.UseVisualStyleBackColor = true;
            this.GitHub.Click += new System.EventHandler(this.GitHub_Click);
            this.GitHub.MouseEnter += new System.EventHandler(this.GitHub_MouseEnter);
            this.GitHub.MouseLeave += new System.EventHandler(this.GitHub_MouseLeave);
            // 
            // Steam
            // 
            this.Steam.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_steam_circled_Normal;
            resources.ApplyResources(this.Steam, "Steam");
            this.Steam.FlatAppearance.BorderSize = 0;
            this.Steam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.Steam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Steam.Name = "Steam";
            this.Steam.UseVisualStyleBackColor = true;
            this.Steam.Click += new System.EventHandler(this.Steam_Click);
            this.Steam.MouseEnter += new System.EventHandler(this.Steam_MouseEnter);
            this.Steam.MouseLeave += new System.EventHandler(this.Steam_MouseLeave);
            // 
            // Mail
            // 
            this.Mail.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_mail_100;
            resources.ApplyResources(this.Mail, "Mail");
            this.Mail.FlatAppearance.BorderSize = 0;
            this.Mail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Mail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Mail.Name = "Mail";
            this.Mail.UseVisualStyleBackColor = true;
            this.Mail.Click += new System.EventHandler(this.Mail_Click);
            this.Mail.MouseEnter += new System.EventHandler(this.Mail_MouseEnter);
            this.Mail.MouseLeave += new System.EventHandler(this.Mail_MouseLeave);
            // 
            // Icons8
            // 
            this.Icons8.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_icons8_default;
            resources.ApplyResources(this.Icons8, "Icons8");
            this.Icons8.FlatAppearance.BorderSize = 0;
            this.Icons8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Icons8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Icons8.Name = "Icons8";
            this.Icons8.UseVisualStyleBackColor = true;
            this.Icons8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Icons8_MouseClick);
            this.Icons8.MouseEnter += new System.EventHandler(this.Icons8_MouseEnter);
            this.Icons8.MouseLeave += new System.EventHandler(this.Icons8_MouseLeave);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.BRS_Header;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // Programmer
            // 
            this.Programmer.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_file_download_100;
            resources.ApplyResources(this.Programmer, "Programmer");
            this.Programmer.FlatAppearance.BorderSize = 0;
            this.Programmer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.Programmer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Programmer.Name = "Programmer";
            this.Programmer.UseVisualStyleBackColor = true;
            this.Programmer.Click += new System.EventHandler(this.Programmer_Click);
            this.Programmer.MouseEnter += new System.EventHandler(this.Programmer_MouseEnter);
            this.Programmer.MouseLeave += new System.EventHandler(this.Programmer_MouseLeave);
            // 
            // Console
            // 
            this.Console.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_console_Normal;
            resources.ApplyResources(this.Console, "Console");
            this.Console.FlatAppearance.BorderSize = 0;
            this.Console.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Console.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Console.Name = "Console";
            this.Console.UseVisualStyleBackColor = true;
            this.Console.Click += new System.EventHandler(this.Console_Click);
            this.Console.MouseEnter += new System.EventHandler(this.Console_MouseEnter);
            this.Console.MouseLeave += new System.EventHandler(this.Console_MouseLeave);
            // 
            // InformationButton
            // 
            this.InformationButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_info_100;
            resources.ApplyResources(this.InformationButton, "InformationButton");
            this.InformationButton.FlatAppearance.BorderSize = 0;
            this.InformationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.InformationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.InformationButton.Name = "InformationButton";
            this.InformationButton.UseVisualStyleBackColor = true;
            this.InformationButton.Click += new System.EventHandler(this.InformationButton_Click);
            this.InformationButton.MouseEnter += new System.EventHandler(this.InformationButton_MouseEnter);
            this.InformationButton.MouseLeave += new System.EventHandler(this.InformationButton_MouseLeave);
            // 
            // UDPNetworkInterface
            // 
            this.UDPNetworkInterface.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_stack_100;
            resources.ApplyResources(this.UDPNetworkInterface, "UDPNetworkInterface");
            this.UDPNetworkInterface.FlatAppearance.BorderSize = 0;
            this.UDPNetworkInterface.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.UDPNetworkInterface.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UDPNetworkInterface.Name = "UDPNetworkInterface";
            this.UDPNetworkInterface.UseVisualStyleBackColor = true;
            this.UDPNetworkInterface.Click += new System.EventHandler(this.UDPNetworkInterface_Click);
            this.UDPNetworkInterface.MouseEnter += new System.EventHandler(this.UDPNetworkInterface_MouseEnter);
            this.UDPNetworkInterface.MouseLeave += new System.EventHandler(this.UDPNetworkInterface_MouseLeave);
            // 
            // Quit
            // 
            this.Quit.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_cancel_100;
            resources.ApplyResources(this.Quit, "Quit");
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Quit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Quit.Name = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            this.Quit.MouseEnter += new System.EventHandler(this.Quit_MouseEnter);
            this.Quit.MouseLeave += new System.EventHandler(this.Quit_MouseLeave);
            // 
            // MainMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.FlowInfoIcons);
            this.Controls.Add(this.ButtonText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.FlowInfoIcons.ResumeLayout(false);
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
        public System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button InformationButton;
        private System.Windows.Forms.Timer FormExpansionTimer;
        private System.Windows.Forms.FlowLayoutPanel FlowInfoIcons;
        private System.Windows.Forms.Button Discord;
        private System.Windows.Forms.Button GitHub;
        private System.Windows.Forms.Button Steam;
        private System.Windows.Forms.Button Mail;
        private System.Windows.Forms.Button UDPNetworkInterface;
        private System.Windows.Forms.Button Icons8;
    }
}