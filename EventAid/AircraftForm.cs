using ConsoleVersion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventAidForm
{
    public partial class AircraftForm : Form
    {
        List<CheckPoint> checkPoints = new List<CheckPoint>();
        string logFileName = "";
        public AircraftForm()
        {
            InitializeComponent();
        }

        private void AircraftForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonAddOrFix_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("请输入名称");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxLat.Text))
            {
                MessageBox.Show("请输入纬度");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxLon.Text))
            {
                MessageBox.Show("请输入经度");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxRange.Text))
            {
                MessageBox.Show("请输入水平范围");
                return;
            }

            // 名称与已有的相同（修改）
            if (listBox1.Items.Contains(textBoxName.Text))
            {
                int index = listBox1.Items.IndexOf(textBoxName.Text);
                checkPoints[index].LAT = Convert.ToDouble(textBoxLat.Text);
                checkPoints[index].LNG = Convert.ToDouble(textBoxLon.Text);
                if (string.IsNullOrEmpty(textBoxLowAlt.Text))
                    checkPoints[index].lowAlt = 0;
                else
                    checkPoints[index].lowAlt = Convert.ToInt32(textBoxLowAlt.Text);
                if (string.IsNullOrEmpty(textBoxHighAlt.Text))
                    checkPoints[index].highAlt = 48900;
                else
                    checkPoints[index].highAlt = Convert.ToInt32(textBoxHighAlt.Text);
                checkPoints[index].range = Convert.ToInt32(textBoxRange.Text);
            }
            else  // 目前没有该项目（新增）
            {
                int lowAlt, highAlt;
                if (string.IsNullOrEmpty(textBoxLowAlt.Text))
                    lowAlt = 0;
                else
                    lowAlt = Convert.ToInt32(textBoxLowAlt.Text);
                if (string.IsNullOrEmpty(textBoxHighAlt.Text))
                    highAlt = 48900;
                else
                    highAlt = Convert.ToInt32(textBoxHighAlt.Text);
                checkPoints.Add(new CheckPoint(textBoxName.Text, Convert.ToDouble(textBoxLat.Text),
                    Convert.ToDouble(textBoxLon.Text), Convert.ToInt32(textBoxRange.Text), lowAlt, highAlt));
                listBox1.Items.Add(textBoxName.Text);
            }
        }

        private void textBoxLowAlt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 使用正则表达式检查输入是否为数字或控制键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // 如果输入不是数字或控制键，取消KeyPress事件
                e.Handled = true;
            }
        }

        private void textBoxHighAlt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 使用正则表达式检查输入是否为数字或控制键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // 如果输入不是数字或控制键，取消KeyPress事件
                e.Handled = true;
            }
        }

        private void textBoxRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 使用正则表达式检查输入是否为数字或控制键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // 如果输入不是数字或控制键，取消KeyPress事件
                e.Handled = true;
            }
        }

        private void textBoxLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 使用正则表达式检查输入是否为数字或控制键或小数点
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // 如果输入不是数字或控制键，取消KeyPress事件
                e.Handled = true;
            }
        }

        private void textBoxLon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 使用正则表达式检查输入是否为数字或控制键或小数点
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // 如果输入不是数字或控制键，取消KeyPress事件
                e.Handled = true;
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 获取双击的项的索引
            int index = listBox1.IndexFromPoint(e.Location);

            // 如果双击发生在有效的项上
            if (index != ListBox.NoMatches)
            {
                // 删除双击的项
                listBox1.Items.RemoveAt(index);
                checkPoints.RemoveAt(index);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem?.ToString() == null)
                return;
            int index = listBox1.SelectedIndex;
            textBoxName.Text = checkPoints[index].checkPointName;
            textBoxLat.Text = Convert.ToString(checkPoints[index].LAT);
            textBoxLon.Text = Convert.ToString(checkPoints[index].LNG);
            textBoxLowAlt.Text = Convert.ToString(checkPoints[index].lowAlt);
            textBoxHighAlt.Text = Convert.ToString(checkPoints[index].highAlt);
            textBoxRange.Text = Convert.ToString(checkPoints[index].range);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("请设置至少一个检查点");
                return;
            }
            DialogResult result = MessageBox.Show("此操作将会覆盖原有记录，是否继续", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;

            timer1.Start();
            buttonStart.Enabled = false;
            buttonExport.Enabled = false;
            listBox1.Enabled = false;
            textBoxName.Enabled = false;
            textBoxLat.Enabled = false;
            textBoxLon.Enabled = false;
            textBoxLowAlt.Enabled = false;
            textBoxHighAlt.Enabled = false;
            textBoxRange.Enabled = false;
            buttonEnd.Enabled = true;
            buttonStart.Text = "检测中...";
            DateTimeOffset currentTime = DateTimeOffset.Now;
            logFileName = currentTime.ToUnixTimeSeconds().ToString();
            timer1_Tick(sender, EventArgs.Empty);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            string urlAircraftList = "https://map.chinaflier.com/airline_list";
            string contentAircraftList = await ConsoleVersion.Program.GetWebContent(urlAircraftList);
            WriteLog(@".\logs\" + logFileName + ".log"
                , DateTime.Now.ToLongTimeString() + "\n" + contentAircraftList);
            AircraftList aircraftList = new AircraftList(contentAircraftList);
            foreach (var checkPoint in checkPoints)
            {
                List<Aircraft>? selectedAircrafts = aircraftList.GetInGivenAreaAircrafts(checkPoint.LAT,
                    checkPoint.LNG, checkPoint.range, checkPoint.lowAlt, checkPoint.highAlt);
                checkPoint.UpdateCheckedAircrafts(selectedAircrafts);
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要结束吗", "确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            timer1.Stop();
            buttonStart.Enabled = true;
            buttonEnd.Enabled = true;
            buttonExport.Enabled = true;
            listBox1.Enabled = true;
            textBoxName.Enabled = true;
            textBoxLat.Enabled = true;
            textBoxLon.Enabled = true;
            textBoxLowAlt.Enabled = true;
            textBoxHighAlt.Enabled = true;
            textBoxRange.Enabled = true;
            buttonEnd.Enabled = false;
            buttonStart.Text = "开始检测";
        }
        private static void WriteLog(string filePath, string message)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    // 在新文件中写入Log信息
                    sw.WriteLine(message);
                }
            }
            else
            {
                // 使用StreamWriter将信息追加到现有文件
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(message);
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "AircraftList.xls";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("请选择输出文件！");
                return;
            }
            ExportToExcel.CheckPointsToExcel(checkPoints, saveFileDialog1.FileName);
            MessageBox.Show("导出成功！");
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("请设置至少一个检查点");
                return;
            }
            openFileDialogLog.FileName = "";
            DialogResult pathResult = openFileDialogLog.ShowDialog();
            if (pathResult == DialogResult.Cancel)
            {
                MessageBox.Show("请选择文件位置");
                return;
            }

            string[] logContentLines;
            try
            {
                // 使用StreamReader打开文件并读取内容
                using (StreamReader reader = new StreamReader(openFileDialogLog.FileName))
                {
                    // 读取整个文件内容
                    logContentLines = reader.ReadToEnd().Split('\n');
                }
            }
            catch
            {
                MessageBox.Show("读取文件时出错！");
                return;
            }

            DateTime dateTime = DateTime.Now;
            foreach (string line in logContentLines)
                if (!string.IsNullOrWhiteSpace(line))
                    if (line[0]  == '[')
                    {
                        AircraftList aircraftList = new AircraftList(line);
                        foreach (var checkPoint in checkPoints)
                        {
                            List<Aircraft>? selectedAircrafts = aircraftList.GetInGivenAreaAircrafts(checkPoint.LAT,
                                checkPoint.LNG, checkPoint.range, checkPoint.lowAlt, checkPoint.highAlt);
                            checkPoint.UpdateCheckedAircrafts(selectedAircrafts, dateTime);
                        }
                    }
                    else
                    {
                        long unixTimestamp = long.Parse(Path.GetFileNameWithoutExtension(openFileDialogLog.FileName));
                        DateTime dateTimeStart = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).DateTime;
                        string[] splitedTime = line.Split(':');
                        dateTime = new DateTime(dateTimeStart.Year, dateTimeStart.Month, dateTimeStart.Day,
                            int.Parse(splitedTime[0]), int.Parse(splitedTime[1]), int.Parse(splitedTime[2]));
                    }

            saveFileDialog1.FileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                + DateTime.Now.Day.ToString() + "AircraftList.xls";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("请选择输出文件！");
                return;
            }
            ExportToExcel.CheckPointsToExcel(checkPoints, saveFileDialog1.FileName);
            MessageBox.Show("导出成功！");
        }
    }
}
