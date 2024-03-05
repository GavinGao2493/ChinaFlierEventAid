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
    public partial class MenuForm : Form
    {
        // 记录label是否被选中
        bool[] isLabelSelected = new bool[2];

        public MenuForm()
        {
            InitializeComponent();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (isLabelSelected[0]) return;
            labelAtcForm.ForeColor = Color.White;
            pictureBoxAtcForm.BackColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (isLabelSelected[0]) return;
            labelAtcForm.ForeColor = Color.Gray;
            pictureBoxAtcForm.BackColor = Color.FromArgb(38, 50, 56);
        }

        private void labelAtcForm_Click(object sender, EventArgs e)
        {
            labelAtcForm.ForeColor = Color.White;
            if (isLabelSelected[1])
            {
                labelAircraft.ForeColor = Color.Gray;
                pictureBoxAircraft.BackColor = Color.FromArgb(38, 50, 56);
            }
            isLabelSelected = new bool[2];
            isLabelSelected[0] = true;
            pictureBoxAtcForm.BackColor = Color.Red;
        }

        private void labelAircraft_MouseEnter(object sender, EventArgs e)
        {
            if (isLabelSelected[1]) return;
            labelAircraft.ForeColor = Color.White;
            pictureBoxAircraft.BackColor = Color.White;
        }

        private void labelAircraft_MouseLeave(object sender, EventArgs e)
        {
            if (isLabelSelected[1]) return;
            labelAircraft.ForeColor = Color.Gray;
            pictureBoxAircraft.BackColor = Color.FromArgb(38, 50, 56);
        }

        private void labelAircraft_Click(object sender, EventArgs e)
        {
            labelAircraft.ForeColor = Color.White;
            if (isLabelSelected[0])
            {
                labelAtcForm.ForeColor = Color.Gray;
                pictureBoxAtcForm.BackColor = Color.FromArgb(38, 50, 56);
            }
            isLabelSelected = new bool[2];
            isLabelSelected[1] = true;
            pictureBoxAircraft.BackColor= Color.Red;
        }
    }
}
