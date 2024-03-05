using EventAidForm;

namespace EventAid
{
    public partial class MainForm : Form
    {
        MenuForm menuForm = new MenuForm();
        AtcForm atcForm = new AtcForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            atcForm.MdiParent = this;
            atcForm.Dock = DockStyle.Right;
            atcForm.Show();

            menuForm.MdiParent = this;
            menuForm.Dock = DockStyle.Left;
            menuForm.Show();
        }
    }
}
