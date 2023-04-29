using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem.Models;
using HospitalSystem.Controllers;
using HospitalSystem.Views.Doctors;

namespace HospitalSystem.Views
{
    public partial class DoctorLogin : Form
    {
        public static string instance = ""; // This is for data migration.
        public static string textX = ""; // This is for data migratiopn
        #region Add Controllers
        DoctorController doctorController = new DoctorController();
        #endregion
        #region Login Config
        public bool LoginDoctor()
        {
            bool State=doctorController.DoctorLogin(textBox1.Text.ToString(), textBox2.Text.ToString());
            if (State==true)
            {
                string value = doctorController.GetDoctorBranch(textBox1.Text.ToString());
                instance = textBox1.Text; // It will migration Doctor's Id value.
                List<Doctor> doctors = doctorController.GetDoctorsById(textBox1.Text.ToString());
                foreach (var item in doctors)
                {
                    textX = item.Name +" "+ item.Surname; // It will migration Doctor's Name and Surname values. These values will be moved to Text for Forms.
                }
                MessageBox.Show("Welcome to Doctor Panel!","Information",MessageBoxButtons.OK);
                NextPage();
                return true;
            }
            else
            {
                MessageBox.Show("The username or password is incorrect. Try Again.","Information",MessageBoxButtons.OK);
                textBox1.Clear();
                textBox2.Clear();
                return false;
            }
        }
        #endregion
        #region Other Configs
        public void NextPage()
        {
            MainDoctor mainDoctor = new MainDoctor();
            mainDoctor.Owner = this;
            ClearTools();
            this.Hide();
            mainDoctor.Show();
            mainDoctor.Text = textX;
        }
        public void ClearTools()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        #endregion
       
        public DoctorLogin()
        {
            InitializeComponent();
            this.FormClosing += DoctorLogin_FormClosing;
        }

        private void DoctorLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void DoctorLogin_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            LoginDoctor();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (textBox1.Text.Length.Equals(17))
            {
                e.Handled = !char.IsControl(e.KeyChar);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (textBox2.Text.Length.Equals(17))
            {
                e.Handled = !char.IsControl(e.KeyChar);
            }
        }
    }
}
