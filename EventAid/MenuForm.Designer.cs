namespace EventAidForm
{
    partial class MenuForm
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
            labelAtcForm = new Label();
            labelAircraft = new Label();
            pictureBoxAtcForm = new PictureBox();
            pictureBoxAircraft = new PictureBox();
            labelCopyright = new Label();
            labelEvent = new Label();
            pictureBoxEvent = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAtcForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAircraft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEvent).BeginInit();
            SuspendLayout();
            // 
            // labelAtcForm
            // 
            labelAtcForm.ForeColor = Color.Gray;
            labelAtcForm.Location = new Point(12, 44);
            labelAtcForm.Name = "labelAtcForm";
            labelAtcForm.Size = new Size(172, 20);
            labelAtcForm.TabIndex = 1;
            labelAtcForm.Text = "ATC Online";
            labelAtcForm.Click += labelAtcForm_Click;
            labelAtcForm.MouseEnter += labelAtcForm_MouseEnter;
            labelAtcForm.MouseLeave += labelAtcForm_MouseLeave;
            // 
            // labelAircraft
            // 
            labelAircraft.ForeColor = Color.Gray;
            labelAircraft.Location = new Point(12, 88);
            labelAircraft.Name = "labelAircraft";
            labelAircraft.Size = new Size(172, 20);
            labelAircraft.TabIndex = 2;
            labelAircraft.Text = "Aircraft Detect";
            labelAircraft.Click += labelAircraft_Click;
            labelAircraft.MouseEnter += labelAircraft_MouseEnter;
            labelAircraft.MouseLeave += labelAircraft_MouseLeave;
            // 
            // pictureBoxAtcForm
            // 
            pictureBoxAtcForm.Location = new Point(190, 40);
            pictureBoxAtcForm.Name = "pictureBoxAtcForm";
            pictureBoxAtcForm.Size = new Size(10, 28);
            pictureBoxAtcForm.TabIndex = 3;
            pictureBoxAtcForm.TabStop = false;
            // 
            // pictureBoxAircraft
            // 
            pictureBoxAircraft.Location = new Point(190, 82);
            pictureBoxAircraft.Name = "pictureBoxAircraft";
            pictureBoxAircraft.Size = new Size(10, 28);
            pictureBoxAircraft.TabIndex = 4;
            pictureBoxAircraft.TabStop = false;
            // 
            // labelCopyright
            // 
            labelCopyright.AutoSize = true;
            labelCopyright.ForeColor = Color.Gray;
            labelCopyright.Location = new Point(12, 431);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(107, 40);
            labelCopyright.TabIndex = 5;
            labelCopyright.Text = "版本 V1.1\r\n作者 CFR2493";
            // 
            // labelEvent
            // 
            labelEvent.ForeColor = Color.Gray;
            labelEvent.Location = new Point(12, 131);
            labelEvent.Name = "labelEvent";
            labelEvent.Size = new Size(172, 20);
            labelEvent.TabIndex = 6;
            labelEvent.Text = "Event Publish";
            labelEvent.Click += labelEvent_Click;
            labelEvent.MouseEnter += labelEvent_MouseEnter;
            labelEvent.MouseLeave += labelEvent_MouseLeave;
            // 
            // pictureBoxEvent
            // 
            pictureBoxEvent.Location = new Point(190, 125);
            pictureBoxEvent.Name = "pictureBoxEvent";
            pictureBoxEvent.Size = new Size(10, 28);
            pictureBoxEvent.TabIndex = 7;
            pictureBoxEvent.TabStop = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 50, 56);
            ClientSize = new Size(200, 550);
            Controls.Add(pictureBoxEvent);
            Controls.Add(labelEvent);
            Controls.Add(labelCopyright);
            Controls.Add(pictureBoxAircraft);
            Controls.Add(pictureBoxAtcForm);
            Controls.Add(labelAircraft);
            Controls.Add(labelAtcForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAtcForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAircraft).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEvent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelAtcForm;
        private Label labelAircraft;
        private PictureBox pictureBoxAtcForm;
        private PictureBox pictureBoxAircraft;
        private Label labelCopyright;
        private Label labelEvent;
        private PictureBox pictureBoxEvent;
    }
}