using HospitalSystem.Controllers;
using HospitalSystem.Models;
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

namespace HospitalSystem.Views
{
    public partial class SecretaryLogin : Form
    {
        public static string instance = "";
        #region Add Controllers
        SecretaryController secretaryController = new SecretaryController();
        #endregion
        #region Records
        public void LoginButton()
        {
            bool State = secretaryController.SecretaryLogin(textBox1.Text.ToString(), textBox2.Text.ToString());
            if (State == true)
            {
                MessageBox.Show("Welcome To Secretary Panel!","Information",MessageBoxButtons.OK);
                List<HospitalSystem.Models.Secretary> secretaries = secretaryController.GetSecretaries();
                foreach (var item in secretaries)
                {
                    instance = item.Name + " " + item.Surname; // It will migration Doctor's Name and Surname values. These values will be moved to Text for Forms.
                }
                NextPage();
            }
            else
            {
                MessageBox.Show("The username or password is incorrect. Try Again.","Information",MessageBoxButtons.OK);
                ClearTools();
            }
        }
        #endregion
        #region Other Configs
        public void ClearTools()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        public void NextPage()
        {
            MainSecretary mainSecretary = new MainSecretary();
            mainSecretary.Owner = this;
            mainSecretary.Text = instance;
            ClearTools();
            this.Hide();
            mainSecretary.Show();
        }
        #endregion
        public SecretaryLogin()
        {
            InitializeComponent();
            this.FormClosing += SecretaryLogin_FormClosing; // Configuration for form clossing.
        }

        private void SecretaryLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void SecretaryLogin_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginButton();
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

