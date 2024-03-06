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
        public AircraftForm()
        {
            InitializeComponent();
        }

        private void AircraftForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
