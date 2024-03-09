using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EventAid;

namespace EventAidForm
{
    public partial class MenuForm : Form
    {
        // 记录label是否被选中
        bool[] isLabelSelected = new bool[3];

        AtcForm atcForm = new AtcForm();
        AircraftForm aircraftForm = new AircraftForm();
        EventPublishForm eventPublishForm = new EventPublishForm();

        public MenuForm(MainForm mainForm)
        {
            InitializeComponent();

            // 初始化窗口
            labelAtcForm.ForeColor = Color.White;
            isLabelSelected[0] = true;
            pictureBoxAtcForm.BackColor = Color.Red;

            aircraftForm.MdiParent = mainForm;
            aircraftForm.Dock = DockStyle.Right;
            aircraftForm.Show();
            aircraftForm.Hide();

            eventPublishForm.MdiParent = mainForm;
            eventPublishForm.Dock = DockStyle.Right;
            eventPublishForm.Show();
            eventPublishForm.Hide();

            atcForm.MdiParent = mainForm;
            atcForm.Dock = DockStyle.Right;
            atcForm.Show();
        }

        private void labelAtcForm_MouseEnter(object sender, EventArgs e)
        {
            if (isLabelSelected[0]) return;
            labelAtcForm.ForeColor = Color.White;
            pictureBoxAtcForm.BackColor = Color.White;
        }

        private void labelAtcForm_MouseLeave(object sender, EventArgs e)
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
            else if (isLabelSelected[2])
            {
                labelEvent.ForeColor = Color.Gray;
                pictureBoxEvent.BackColor = Color.FromArgb(38, 50, 56);
            }
            isLabelSelected = new bool[3];
            isLabelSelected[0] = true;
            pictureBoxAtcForm.BackColor = Color.Red;

            aircraftForm.Hide();
            eventPublishForm.Hide();
            atcForm.Show();
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
            else if (isLabelSelected[2])
            {
                labelEvent.ForeColor = Color.Gray;
                pictureBoxEvent.BackColor = Color.FromArgb(38, 50, 56);
            }
            isLabelSelected = new bool[3];
            isLabelSelected[1] = true;
            pictureBoxAircraft.BackColor = Color.Red;

            atcForm.Hide();
            eventPublishForm.Hide();
            aircraftForm.Show();
        }

        private void labelEvent_Click(object sender, EventArgs e)
        {
            labelEvent.ForeColor = Color.White;
            if (isLabelSelected[0])
            {
                labelAtcForm.ForeColor = Color.Gray;
                pictureBoxAtcForm.BackColor = Color.FromArgb(38, 50, 56);
            }
            else if (isLabelSelected[1])
            {
                labelAircraft.ForeColor = Color.Gray;
                pictureBoxAircraft.BackColor = Color.FromArgb(38, 50, 56);
            }
            isLabelSelected = new bool[3];
            isLabelSelected[2] = true;
            pictureBoxEvent.BackColor = Color.Red;

            atcForm.Hide();
            aircraftForm.Hide();
            eventPublishForm.Show();
        }

        private void labelEvent_MouseEnter(object sender, EventArgs e)
        {
            if (isLabelSelected[2]) return;
            labelEvent.ForeColor = Color.White;
            pictureBoxEvent.BackColor = Color.White;
        }

        private void labelEvent_MouseLeave(object sender, EventArgs e)
        {
            if (isLabelSelected[2]) return;
            labelEvent.ForeColor = Color.Gray;
            pictureBoxEvent.BackColor = Color.FromArgb(38, 50, 56);
        }
    }
}
