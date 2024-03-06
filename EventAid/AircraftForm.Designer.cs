namespace EventAidForm
{
    partial class AircraftForm
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
            labelCheckPoint = new Label();
            listBox1 = new ListBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelLat = new Label();
            labelLon = new Label();
            textBoxLat = new TextBox();
            textBoxLon = new TextBox();
            labelLowAlt = new Label();
            labelHighAlt = new Label();
            textBoxLowAlt = new TextBox();
            textBoxHighAlt = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            buttonStart = new Button();
            buttonEnd = new Button();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // labelCheckPoint
            // 
            labelCheckPoint.AutoSize = true;
            labelCheckPoint.Location = new Point(73, 61);
            labelCheckPoint.Name = "labelCheckPoint";
            labelCheckPoint.Size = new Size(84, 20);
            labelCheckPoint.TabIndex = 0;
            labelCheckPoint.Text = "检查点列表";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(51, 98);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(128, 264);
            listBox1.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(260, 100);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 20);
            labelName.TabIndex = 2;
            labelName.Text = "名称";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(312, 95);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(125, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelLat
            // 
            labelLat.AutoSize = true;
            labelLat.Location = new Point(260, 145);
            labelLat.Name = "labelLat";
            labelLat.Size = new Size(39, 20);
            labelLat.TabIndex = 4;
            labelLat.Text = "纬度";
            // 
            // labelLon
            // 
            labelLon.AutoSize = true;
            labelLon.Location = new Point(260, 190);
            labelLon.Name = "labelLon";
            labelLon.Size = new Size(39, 20);
            labelLon.TabIndex = 5;
            labelLon.Text = "经度";
            // 
            // textBoxLat
            // 
            textBoxLat.Location = new Point(312, 140);
            textBoxLat.Name = "textBoxLat";
            textBoxLat.Size = new Size(125, 27);
            textBoxLat.TabIndex = 6;
            // 
            // textBoxLon
            // 
            textBoxLon.Location = new Point(312, 185);
            textBoxLon.Name = "textBoxLon";
            textBoxLon.Size = new Size(125, 27);
            textBoxLon.TabIndex = 7;
            // 
            // labelLowAlt
            // 
            labelLowAlt.AutoSize = true;
            labelLowAlt.Location = new Point(230, 235);
            labelLowAlt.Name = "labelLowAlt";
            labelLowAlt.Size = new Size(69, 20);
            labelLowAlt.TabIndex = 8;
            labelLowAlt.Text = "最低高度";
            // 
            // labelHighAlt
            // 
            labelHighAlt.AutoSize = true;
            labelHighAlt.Location = new Point(230, 280);
            labelHighAlt.Name = "labelHighAlt";
            labelHighAlt.Size = new Size(69, 20);
            labelHighAlt.TabIndex = 9;
            labelHighAlt.Text = "最高高度";
            // 
            // textBoxLowAlt
            // 
            textBoxLowAlt.Location = new Point(312, 230);
            textBoxLowAlt.Name = "textBoxLowAlt";
            textBoxLowAlt.Size = new Size(125, 27);
            textBoxLowAlt.TabIndex = 10;
            // 
            // textBoxHighAlt
            // 
            textBoxHighAlt.Location = new Point(312, 275);
            textBoxHighAlt.Name = "textBoxHighAlt";
            textBoxHighAlt.Size = new Size(125, 27);
            textBoxHighAlt.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 325);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 12;
            label1.Text = "最高高度";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(312, 320);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 13;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(51, 421);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(106, 56);
            buttonStart.TabIndex = 14;
            buttonStart.Text = "开始检测";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonEnd
            // 
            buttonEnd.Location = new Point(230, 421);
            buttonEnd.Name = "buttonEnd";
            buttonEnd.Size = new Size(102, 56);
            buttonEnd.TabIndex = 15;
            buttonEnd.Text = "结束检测并导出";
            buttonEnd.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(465, 95);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(39, 70);
            buttonAdd.TabIndex = 16;
            buttonAdd.Text = "添加";
            buttonAdd.UseVisualStyleBackColor = true;
            // 
            // AircraftForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(600, 550);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEnd);
            Controls.Add(buttonStart);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(textBoxHighAlt);
            Controls.Add(textBoxLowAlt);
            Controls.Add(labelHighAlt);
            Controls.Add(labelLowAlt);
            Controls.Add(textBoxLon);
            Controls.Add(textBoxLat);
            Controls.Add(labelLon);
            Controls.Add(labelLat);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(listBox1);
            Controls.Add(labelCheckPoint);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AircraftForm";
            Text = "AircraftForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCheckPoint;
        private ListBox listBox1;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelLat;
        private Label labelLon;
        private TextBox textBoxLat;
        private TextBox textBoxLon;
        private Label labelLowAlt;
        private Label labelHighAlt;
        private TextBox textBoxLowAlt;
        private TextBox textBoxHighAlt;
        private Label label1;
        private TextBox textBox1;
        private Button buttonStart;
        private Button buttonEnd;
        private Button buttonAdd;
    }
}