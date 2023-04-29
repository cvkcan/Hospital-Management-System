using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem.Views.Secretary;

namespace HospitalSystem.Views
{
    public partial class MainSecretary : Form
    {
        public void SecretaryPage()
        {
            SecretaryForm secretaryForm = new SecretaryForm();
            secretaryForm.Owner = this;
            secretaryForm.Text = SecretaryLogin.instance;
            this.Hide();
            secretaryForm.Show();
        }
        public void AppointmentPage()
        {
            AppointmentPage appointmentPage = new AppointmentPage();
            appointmentPage.Owner = this;
            appointmentPage.Text = SecretaryLogin.instance;
            this.Hide();
            appointmentPage.Show();
        }
        public MainSecretary()
        {
            InitializeComponent();
            this.FormClosing += MainSecretary_FormClosing; // Configuration for form clossing.
        }

        private void MainSecretary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void MainSecretary_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecretaryPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppointmentPage();
        }
    }
}
