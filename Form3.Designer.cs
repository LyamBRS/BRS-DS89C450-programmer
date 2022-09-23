
namespace BRS_Dallas_Programmer
{
    partial class ProgrammerSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgrammerSettings));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AutoProgrammingCheckBox = new System.Windows.Forms.Button();
            this.AutoProgrammingLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DeviceDetectionCheckBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_ok_100__1_;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(510, 442);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 87);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_settings_100;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(477, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 98);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.BRS_Header;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(457, 88);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AutoProgrammingCheckBox
            // 
            this.AutoProgrammingCheckBox.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_checked_checkbox_100;
            this.AutoProgrammingCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AutoProgrammingCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoProgrammingCheckBox.FlatAppearance.BorderSize = 0;
            this.AutoProgrammingCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AutoProgrammingCheckBox.Location = new System.Drawing.Point(13, 156);
            this.AutoProgrammingCheckBox.Name = "AutoProgrammingCheckBox";
            this.AutoProgrammingCheckBox.Size = new System.Drawing.Size(70, 70);
            this.AutoProgrammingCheckBox.TabIndex = 4;
            this.AutoProgrammingCheckBox.UseVisualStyleBackColor = true;
            this.AutoProgrammingCheckBox.Click += new System.EventHandler(this.AutoProgrammingCheckBox_Click);
            // 
            // AutoProgrammingLabel
            // 
            this.AutoProgrammingLabel.AutoSize = true;
            this.AutoProgrammingLabel.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoProgrammingLabel.Location = new System.Drawing.Point(84, 175);
            this.AutoProgrammingLabel.Name = "AutoProgrammingLabel";
            this.AutoProgrammingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoProgrammingLabel.Size = new System.Drawing.Size(414, 36);
            this.AutoProgrammingLabel.TabIndex = 5;
            this.AutoProgrammingLabel.Text = "Automatic Programming";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 255);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(528, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Automatic Device Connection";
            // 
            // DeviceDetectionCheckBox
            // 
            this.DeviceDetectionCheckBox.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_checked_checkbox_100;
            this.DeviceDetectionCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DeviceDetectionCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeviceDetectionCheckBox.FlatAppearance.BorderSize = 0;
            this.DeviceDetectionCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeviceDetectionCheckBox.Location = new System.Drawing.Point(13, 235);
            this.DeviceDetectionCheckBox.Name = "DeviceDetectionCheckBox";
            this.DeviceDetectionCheckBox.Size = new System.Drawing.Size(70, 70);
            this.DeviceDetectionCheckBox.TabIndex = 6;
            this.DeviceDetectionCheckBox.UseVisualStyleBackColor = true;
            this.DeviceDetectionCheckBox.Click += new System.EventHandler(this.DeviceDetectionCheckBox_Click);
            // 
            // ProgrammerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(614, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeviceDetectionCheckBox);
            this.Controls.Add(this.AutoProgrammingLabel);
            this.Controls.Add(this.AutoProgrammingCheckBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProgrammerSettings";
            this.ShowIcon = false;
            this.Text = "Programmer Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AutoProgrammingCheckBox;
        private System.Windows.Forms.Label AutoProgrammingLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeviceDetectionCheckBox;
    }
}