using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SecretaryLogin secretaryLogin = new SecretaryLogin();
            secretaryLogin.Owner = this;
            this.Hide();
            secretaryLogin.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DoctorLogin doctorLogin = new DoctorLogin();
            doctorLogin.Owner = this;
            this.Hide();
            doctorLogin.Show();
        }
    }
}
