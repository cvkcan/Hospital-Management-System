using HospitalSystem.Controllers;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem.Views.Doctors
{
    public partial class MainDoctor : Form
    {
        #region Add Controllers
        AppointmentController appointmentController = new AppointmentController();
        #endregion
        #region Appointment Record
        public void AppointmentSearch()
        {
            dataGridView1.DataSource= appointmentController.SearchAppointmentById(textBox4.Text.ToString(),DoctorLogin.instance.ToString());
        }
        public void AppointmentGetById()
        {
            dataGridView1.DataSource= appointmentController.GetAppointmentById(DoctorLogin.instance);
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void AppointmentUpdate()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                appointmentController.UpdateForMainDoctor(Convert.ToDateTime(dateTimePicker1.Value), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text.ToString());
                AppointmentGetById();
            }
            else
            {
                MessageBox.Show("If you want to update the data, select the row in table.","Information",MessageBoxButtons.OK);
            }
        }
        #endregion
        #region Other Configs
        public void PullInfoByDgw() // Data will be carried via DataGridView
        {
            if (dataGridView1.Rows.Count>0)
            {
                var shortcut = dataGridView1.CurrentRow.Cells;
                textBox1.Text = shortcut["AppointmentId"].Value.ToString();
                textBox2.Text = shortcut["PatientId"].Value.ToString();
                textBox3.Text = shortcut["Diagnosis"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(shortcut["DateTime"].Value.ToString());
            }
        }
        public void CustomTimePicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        private void InitializeDataGridView() // Configuration for DataGridView
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }
        #endregion
        public MainDoctor()
        {
            InitializeComponent();
            this.FormClosing += MainDoctor_FormClosing;
        }

        private void MainDoctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void MainDoctor_Load(object sender, EventArgs e)
        {
            CustomTimePicker();
            InitializeDataGridView();
            AppointmentGetById();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Carries data from DataGridView to TextBox when column is pressed.
        {
            PullInfoByDgw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentUpdate();
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e) // Searches when key is pressed.
        {
            AppointmentSearch();
        }
    }
}
