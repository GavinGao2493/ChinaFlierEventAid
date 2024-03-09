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
            components = new System.ComponentModel.Container();
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
            labelRange = new Label();
            textBoxRange = new TextBox();
            buttonStart = new Button();
            buttonEnd = new Button();
            buttonAddOrFix = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            labelAltDes1 = new Label();
            labelAltDes2 = new Label();
            labelManual = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonExport = new Button();
            SuspendLayout();
            // 
            // labelCheckPoint
            // 
            labelCheckPoint.AutoSize = true;
            labelCheckPoint.Location = new Point(102, 26);
            labelCheckPoint.Name = "labelCheckPoint";
            labelCheckPoint.Size = new Size(84, 20);
            labelCheckPoint.TabIndex = 0;
            labelCheckPoint.Text = "检查点列表";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(80, 58);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(128, 264);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(289, 60);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 20);
            labelName.TabIndex = 2;
            labelName.Text = "名称";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(341, 55);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(125, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelLat
            // 
            labelLat.AutoSize = true;
            labelLat.Location = new Point(289, 105);
            labelLat.Name = "labelLat";
            labelLat.Size = new Size(39, 20);
            labelLat.TabIndex = 4;
            labelLat.Text = "纬度";
            // 
            // labelLon
            // 
            labelLon.AutoSize = true;
            labelLon.Location = new Point(289, 150);
            labelLon.Name = "labelLon";
            labelLon.Size = new Size(39, 20);
            labelLon.TabIndex = 5;
            labelLon.Text = "经度";
            // 
            // textBoxLat
            // 
            textBoxLat.Location = new Point(341, 100);
            textBoxLat.Name = "textBoxLat";
            textBoxLat.Size = new Size(125, 27);
            textBoxLat.TabIndex = 6;
            textBoxLat.KeyPress += textBoxLat_KeyPress;
            // 
            // textBoxLon
            // 
            textBoxLon.Location = new Point(341, 145);
            textBoxLon.Name = "textBoxLon";
            textBoxLon.Size = new Size(125, 27);
            textBoxLon.TabIndex = 7;
            textBoxLon.KeyPress += textBoxLon_KeyPress;
            // 
            // labelLowAlt
            // 
            labelLowAlt.AutoSize = true;
            labelLowAlt.Location = new Point(259, 195);
            labelLowAlt.Name = "labelLowAlt";
            labelLowAlt.Size = new Size(69, 20);
            labelLowAlt.TabIndex = 8;
            labelLowAlt.Text = "最低高度";
            // 
            // labelHighAlt
            // 
            labelHighAlt.AutoSize = true;
            labelHighAlt.Location = new Point(259, 240);
            labelHighAlt.Name = "labelHighAlt";
            labelHighAlt.Size = new Size(69, 20);
            labelHighAlt.TabIndex = 9;
            labelHighAlt.Text = "最高高度";
            // 
            // textBoxLowAlt
            // 
            textBoxLowAlt.Location = new Point(341, 190);
            textBoxLowAlt.MaxLength = 5;
            textBoxLowAlt.Name = "textBoxLowAlt";
            textBoxLowAlt.Size = new Size(125, 27);
            textBoxLowAlt.TabIndex = 10;
            textBoxLowAlt.KeyPress += textBoxLowAlt_KeyPress;
            // 
            // textBoxHighAlt
            // 
            textBoxHighAlt.Location = new Point(341, 235);
            textBoxHighAlt.MaxLength = 5;
            textBoxHighAlt.Name = "textBoxHighAlt";
            textBoxHighAlt.Size = new Size(125, 27);
            textBoxHighAlt.TabIndex = 11;
            textBoxHighAlt.KeyPress += textBoxHighAlt_KeyPress;
            // 
            // labelRange
            // 
            labelRange.AutoSize = true;
            labelRange.Location = new Point(259, 285);
            labelRange.Name = "labelRange";
            labelRange.Size = new Size(69, 20);
            labelRange.TabIndex = 12;
            labelRange.Text = "水平范围";
            // 
            // textBoxRange
            // 
            textBoxRange.Location = new Point(341, 280);
            textBoxRange.MaxLength = 4;
            textBoxRange.Name = "textBoxRange";
            textBoxRange.Size = new Size(125, 27);
            textBoxRange.TabIndex = 13;
            textBoxRange.KeyPress += textBoxRange_KeyPress;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(80, 442);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(131, 41);
            buttonStart.TabIndex = 14;
            buttonStart.Text = "开始检测";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonEnd
            // 
            buttonEnd.Enabled = false;
            buttonEnd.Location = new Point(245, 442);
            buttonEnd.Name = "buttonEnd";
            buttonEnd.Size = new Size(127, 41);
            buttonEnd.TabIndex = 15;
            buttonEnd.Text = "结束检测";
            buttonEnd.UseVisualStyleBackColor = true;
            buttonEnd.Click += buttonEnd_Click;
            // 
            // buttonAddOrFix
            // 
            buttonAddOrFix.Location = new Point(487, 53);
            buttonAddOrFix.Name = "buttonAddOrFix";
            buttonAddOrFix.Size = new Size(30, 117);
            buttonAddOrFix.TabIndex = 16;
            buttonAddOrFix.Text = "添加/修改";
            buttonAddOrFix.UseVisualStyleBackColor = true;
            buttonAddOrFix.Click += buttonAddOrFix_Click;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick;
            // 
            // labelAltDes1
            // 
            labelAltDes1.AutoSize = true;
            labelAltDes1.Location = new Point(472, 195);
            labelAltDes1.Name = "labelAltDes1";
            labelAltDes1.Size = new Size(93, 20);
            labelAltDes1.TabIndex = 17;
            labelAltDes1.Text = "留空默认为0";
            // 
            // labelAltDes2
            // 
            labelAltDes2.AutoSize = true;
            labelAltDes2.Location = new Point(472, 240);
            labelAltDes2.Name = "labelAltDes2";
            labelAltDes2.Size = new Size(129, 20);
            labelAltDes2.TabIndex = 18;
            labelAltDes2.Text = "留空默认为48900";
            // 
            // labelManual
            // 
            labelManual.AutoSize = true;
            labelManual.Location = new Point(80, 328);
            labelManual.Name = "labelManual";
            labelManual.Size = new Size(359, 100);
            labelManual.TabIndex = 19;
            labelManual.Text = "说明：\r\n1、检查点名称可自定义，如CheckPoint1、ZBAA等\r\n2、双击列表项可删除选中的检查点\r\n3、经纬度统一以度为单位，如30.06666\r\n4、最低/最高高度单位为英尺、水平范围单位为千米\r\n";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "请选择输出文件夹";
            folderBrowserDialog1.InitialDirectory = "Desktop";
            // 
            // buttonExport
            // 
            buttonExport.Enabled = false;
            buttonExport.Location = new Point(411, 442);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(127, 41);
            buttonExport.TabIndex = 20;
            buttonExport.Text = "导出数据";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // AircraftForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(600, 550);
            Controls.Add(buttonExport);
            Controls.Add(labelManual);
            Controls.Add(labelAltDes2);
            Controls.Add(labelAltDes1);
            Controls.Add(buttonAddOrFix);
            Controls.Add(buttonEnd);
            Controls.Add(buttonStart);
            Controls.Add(textBoxRange);
            Controls.Add(labelRange);
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
            Load += AircraftForm_Load;
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
        private Label labelRange;
        private TextBox textBoxRange;
        private Button buttonStart;
        private Button buttonEnd;
        private Button buttonAddOrFix;
        private System.Windows.Forms.Timer timer1;
        private Label labelAltDes1;
        private Label labelAltDes2;
        private Label labelManual;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonExport;
    }
}