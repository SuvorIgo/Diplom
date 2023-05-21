using Diplom.AuthorizationAndRegistration;
using Microsoft.Extensions.Logging;
using Diplom.libs.db;

namespace Diplom
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var autForm = new AuthorizationForm();
            this.Opacity = 0.8;
            autForm.ShowDialog();
            this.Opacity = 1.0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm();
            this.Opacity = 0.8;
            regForm.ShowDialog();
            this.Opacity = 1.0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                var list = db.Users;
            }
        }
    }
}