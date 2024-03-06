namespace EventAidForm
{
    partial class AtcForm
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
            labelDep = new Label();
            listBox1 = new ListBox();
            labelDepIcao = new Label();
            textBoxDepIcao = new TextBox();
            buttonDepIcao = new Button();
            labelHelper1 = new Label();
            labelArr = new Label();
            labelHelper2 = new Label();
            labelArrIcao = new Label();
            textBoxArrIcao = new TextBox();
            buttonArrIcao = new Button();
            listBox2 = new ListBox();
            buttonExport = new Button();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // labelDep
            // 
            labelDep.AutoSize = true;
            labelDep.Location = new Point(44, 55);
            labelDep.Name = "labelDep";
            labelDep.Size = new Size(69, 20);
            labelDep.TabIndex = 0;
            labelDep.Text = "起飞机场";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(142, 55);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(119, 304);
            listBox1.TabIndex = 1;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            listBox1.MouseUp += listBox1_MouseUp;
            // 
            // labelDepIcao
            // 
            labelDepIcao.AutoSize = true;
            labelDepIcao.Location = new Point(44, 253);
            labelDepIcao.Name = "labelDepIcao";
            labelDepIcao.Size = new Size(76, 20);
            labelDepIcao.TabIndex = 2;
            labelDepIcao.Text = "机场ICAO";
            // 
            // textBoxDepIcao
            // 
            textBoxDepIcao.Location = new Point(41, 287);
            textBoxDepIcao.MaxLength = 4;
            textBoxDepIcao.Name = "textBoxDepIcao";
            textBoxDepIcao.Size = new Size(82, 27);
            textBoxDepIcao.TabIndex = 3;
            // 
            // buttonDepIcao
            // 
            buttonDepIcao.Location = new Point(41, 330);
            buttonDepIcao.Name = "buttonDepIcao";
            buttonDepIcao.Size = new Size(82, 29);
            buttonDepIcao.TabIndex = 4;
            buttonDepIcao.Text = "添加机场";
            buttonDepIcao.UseVisualStyleBackColor = true;
            buttonDepIcao.Click += buttonDepIcao_Click;
            // 
            // labelHelper1
            // 
            labelHelper1.AutoSize = true;
            labelHelper1.Location = new Point(37, 148);
            labelHelper1.Name = "labelHelper1";
            labelHelper1.Size = new Size(99, 40);
            labelHelper1.TabIndex = 5;
            labelHelper1.Text = "双击机场名称\r\n即可删除项目";
            // 
            // labelArr
            // 
            labelArr.AutoSize = true;
            labelArr.Location = new Point(349, 55);
            labelArr.Name = "labelArr";
            labelArr.Size = new Size(69, 20);
            labelArr.TabIndex = 6;
            labelArr.Text = "落地机场";
            // 
            // labelHelper2
            // 
            labelHelper2.AutoSize = true;
            labelHelper2.Location = new Point(332, 148);
            labelHelper2.Name = "labelHelper2";
            labelHelper2.Size = new Size(99, 40);
            labelHelper2.TabIndex = 7;
            labelHelper2.Text = "双击机场名称\r\n即可删除项目";
            // 
            // labelArrIcao
            // 
            labelArrIcao.AutoSize = true;
            labelArrIcao.Location = new Point(340, 253);
            labelArrIcao.Name = "labelArrIcao";
            labelArrIcao.Size = new Size(76, 20);
            labelArrIcao.TabIndex = 8;
            labelArrIcao.Text = "机场ICAO";
            // 
            // textBoxArrIcao
            // 
            textBoxArrIcao.Location = new Point(336, 287);
            textBoxArrIcao.MaxLength = 4;
            textBoxArrIcao.Name = "textBoxArrIcao";
            textBoxArrIcao.Size = new Size(82, 27);
            textBoxArrIcao.TabIndex = 9;
            // 
            // buttonArrIcao
            // 
            buttonArrIcao.Location = new Point(336, 330);
            buttonArrIcao.Name = "buttonArrIcao";
            buttonArrIcao.Size = new Size(82, 29);
            buttonArrIcao.TabIndex = 10;
            buttonArrIcao.Text = "添加机场";
            buttonArrIcao.UseVisualStyleBackColor = true;
            buttonArrIcao.Click += buttonArrIcao_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(441, 55);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(119, 304);
            listBox2.TabIndex = 11;
            listBox2.MouseDoubleClick += listBox2_MouseDoubleClick;
            listBox2.MouseUp += listBox2_MouseUp;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(232, 413);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(129, 53);
            buttonExport.TabIndex = 12;
            buttonExport.Text = "导出当前时刻的管制列表";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "xls";
            saveFileDialog1.FileName = "AtcList";
            saveFileDialog1.Filter = "Excel 97-2003 工作簿|*.xls";
            // 
            // AtcForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(600, 550);
            ControlBox = false;
            Controls.Add(buttonExport);
            Controls.Add(listBox2);
            Controls.Add(buttonArrIcao);
            Controls.Add(textBoxArrIcao);
            Controls.Add(labelArrIcao);
            Controls.Add(labelHelper2);
            Controls.Add(labelArr);
            Controls.Add(labelHelper1);
            Controls.Add(buttonDepIcao);
            Controls.Add(textBoxDepIcao);
            Controls.Add(labelDepIcao);
            Controls.Add(listBox1);
            Controls.Add(labelDep);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "AtcForm";
            ShowIcon = false;
            Text = "Form1";
            Load += AtcForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDep;
        private ListBox listBox1;
        private Label labelDepIcao;
        private TextBox textBoxDepIcao;
        private Button buttonDepIcao;
        private Label labelHelper1;
        private Label labelArr;
        private Label labelHelper2;
        private Label labelArrIcao;
        private TextBox textBoxArrIcao;
        private Button buttonArrIcao;
        private ListBox listBox2;
        private Button buttonExport;
        private SaveFileDialog saveFileDialog1;
    }
}