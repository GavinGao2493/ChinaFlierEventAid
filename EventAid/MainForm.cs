using EventAidForm;

namespace EventAid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.MdiParent = this;
            menuForm.Dock = DockStyle.Left;
            menuForm.Show();

            AtcForm atcForm = new AtcForm();
            atcForm.MdiParent = this;
            atcForm.Dock = DockStyle.Right;
            atcForm.Show();
        }
    }
}
