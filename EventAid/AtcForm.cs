using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ConsoleVersion;
using EventAid;

namespace EventAidForm
{
    public partial class AtcForm : Form
    {
        string urlAtcList = "https://map.chinaflier.com/atc_list";
        static bool IsEnglish(string input)
        {
            // 使用正则表达式匹配字符串是否只包含英文字符
            Regex regex = new Regex("^[a-zA-Z]+$");
            return regex.IsMatch(input);
        }

        public AtcForm()
        {
            InitializeComponent();
        }

        private void AtcForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void buttonDepIcao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDepIcao.Text) || !IsEnglish(textBoxDepIcao.Text))
            {
                MessageBox.Show("请输入合法的机场ICAO码");
                return;
            }
            textBoxDepIcao.Text = textBoxDepIcao.Text.ToUpper();
            if (listBox1.Items.Contains(textBoxDepIcao.Text))
            {
                MessageBox.Show("机场已存在！");
                return;
            }
            listBox1.Items.Add(textBoxDepIcao.Text);
            textBoxDepIcao.Text = string.Empty;
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // 取消选中项的选择
            listBox1.ClearSelected();
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
            }
        }

        private void buttonArrIcao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxArrIcao.Text) || !IsEnglish(textBoxArrIcao.Text))
            {
                MessageBox.Show("请输入合法的机场ICAO码");
                return;
            }
            textBoxArrIcao.Text = textBoxArrIcao.Text.ToUpper();
            if (listBox2.Items.Contains(textBoxArrIcao.Text))
            {
                MessageBox.Show("机场已存在！");
                return;
            }
            listBox2.Items.Add(textBoxArrIcao.Text);
            textBoxArrIcao.Text = string.Empty;
        }

        private void listBox2_MouseUp(object sender, MouseEventArgs e)
        {
            // 取消选中项的选择
            listBox2.ClearSelected();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 获取双击的项的索引
            int index = listBox2.IndexFromPoint(e.Location);

            // 如果双击发生在有效的项上
            if (index != ListBox.NoMatches)
            {
                // 删除双击的项
                listBox2.Items.RemoveAt(index);
            }
        }

        private async void buttonExport_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "AtcList";
            DialogResult result = saveFileDialog1.ShowDialog(this);
            if (string.IsNullOrWhiteSpace(saveFileDialog1.FileName) || result == DialogResult.Cancel)
            {
                MessageBox.Show("请选择文件位置！");
                return;
            }

            List<string> AirportDs = new List<string>();
            foreach (var item in listBox1.Items)
                if (!string.IsNullOrEmpty(item.ToString()))
                    AirportDs.Add(item.ToString());

            List<string> AirportAs = new List<string>();
            foreach (var item in listBox2.Items)
                if (!string.IsNullOrEmpty(item.ToString()))
                    AirportAs.Add(item.ToString());

            string contentAtcList = await ConsoleVersion.Program.GetWebContent(urlAtcList);
            AtcList atcList = new AtcList(contentAtcList);

            ExportToExcel.AtcListToExcel(atcList.GetAtcList(), AirportDs, AirportAs, saveFileDialog1.FileName);

            MessageBox.Show("导出完成！");
        }
    }
}
