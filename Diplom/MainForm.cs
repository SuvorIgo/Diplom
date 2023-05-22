using Diplom.AuthorizationAndRegistration;
using Microsoft.Extensions.Logging;
using Diplom.libs.db;
using Diplom.libs.calculator;

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
            var autForm = new AuthorizationForm() { Owner = this };
            this.Opacity = 0.8;
            autForm.ShowDialog();
            this.Opacity = 1.0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var regForm = new RegistrationForm() { Owner = this };
            this.Opacity = 0.8;
            regForm.ShowDialog();
            this.Opacity = 1.0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label9.Text = string.Empty;
            label10.Text = string.Empty;

            toolTip1.SetToolTip(this.label9, "Цена рассчитана примерно на вес, равный 5 тоннам");

            using (ApplicationContextDB db = new ApplicationContextDB())
            {
                var list = db.Users;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var cityDeparture = textBox1.Text.Trim();
            var cityArrival = textBox2.Text.Trim();

            if (cityDeparture != String.Empty)
            {
                if (cityArrival != String.Empty)
                {
                    var cityDeparturePoints = libs.calculator.Point.GetPointsArrayFromCity(cityDeparture);
                    var cityArrivalPoints = libs.calculator.Point.GetPointsArrayFromCity(cityArrival);

                    var distance = Distance.GetDistanceBetweenTwoCities(cityDeparturePoints, cityArrivalPoints);

                    var sum = Rates.GetSumOfDistanceAndCargo(distance);

                    label9.BackColor = Color.GreenYellow;
                    label9.Text = $"{sum} ₽ 🛈";
                    label10.Text = "Для осуществления поставки\nнеобходимо зарегистрироваться";
                }
                else
                    MessageBox.Show("Для рассчета необходимо ввести город прибытия");
            }
            else
                MessageBox.Show("Для рассчета необходимо ввести город отправления");
        }
    }
}