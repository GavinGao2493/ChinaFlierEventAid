using EventAidForm;

namespace EventAid
{
    public partial class MainForm : Form
    {
        MenuForm menuForm;
        public MainForm()
        {
            InitializeComponent();
            menuForm = new MenuForm(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            menuForm.MdiParent = this;
            menuForm.Dock = DockStyle.Left;
            menuForm.Show();
        }
    }
}
