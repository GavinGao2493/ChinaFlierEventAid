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
            timer1.Start();
            buttonStart.Enabled = false;
            listBox1.Enabled = false;
            textBoxName.Enabled = false;
            textBoxLat.Enabled = false;
            textBoxLon.Enabled = false;
            textBoxLowAlt.Enabled = false;
            textBoxHighAlt.Enabled = false;
            textBoxRange.Enabled = false;
            buttonEnd.Enabled = true;
            buttonStart.Text = "检测中...";
            timer1_Tick(sender, EventArgs.Empty);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            string urlAircraftList = "https://map.chinaflier.com/airline_list";
            string contentAircraftList = await ConsoleVersion.Program.GetWebContent(urlAircraftList);
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
            folderBrowserDialog1.SelectedPath = "";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("请选择输出文件夹！");
                return;
            }
            timer1.Stop();
            ExportToExcel.CheckPointsToExcel(checkPoints, folderBrowserDialog1.SelectedPath);
            buttonStart.Enabled = true;
            listBox1.Enabled = true;
            textBoxName.Enabled = true;
            textBoxLat.Enabled = true;
            textBoxLon.Enabled = true;
            textBoxLowAlt.Enabled = true;
            textBoxHighAlt.Enabled = true;
            textBoxRange.Enabled = true;
            buttonEnd.Enabled = false;
            buttonStart.Text = "开始检测";
            MessageBox.Show("导出成功！");
        }
    }
}
