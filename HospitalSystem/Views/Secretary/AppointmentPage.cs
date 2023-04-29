using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem.Controllers;
using HospitalSystem.Models;
using System.ComponentModel.DataAnnotations; // For validation from classes in models folder.

namespace HospitalSystem.Views.Secretary
{
    public partial class AppointmentPage : Form
    {
        #region Add Controllers
        AppointmentController appointmentController = new AppointmentController();
        DoctorController doctorController = new DoctorController();

        #endregion
        #region Appointment Record
        public void ReturnAppointment()
        {
            dataGridView1.DataSource = appointmentController.GetAppointment();
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Width = 200;
            dataGridView1.Columns[dataGridView1.Columns.Count - 2].DefaultCellStyle.Format = "yyyy-MM-dd";

        }
        public void AppointmentSearch()
        {
            dataGridView1.DataSource = appointmentController.SearchAppointment(textBox5.Text.ToString());
        }
        public void AppointmentUpdate()
        {
            Appointment appointment = new Appointment(textBox1.Text, comboBox2.Text, comboBox1.Text.ToString(), textBox4.Text, dateTimePicker1.Value.ToString(), textBox3.Text.ToString());
            ValidationContext context = new ValidationContext(appointment, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            // Above 3 columns are for validation.(Data Annotations.)

            if (!Validator.TryValidateObject(appointment, context, errors, true))
            {
                string xxx = "";
                foreach (ValidationResult result in errors)
                {
                    xxx += result.ErrorMessage + "\n"; // Carries validation error messages.
                }
                MessageBox.Show(xxx,"Information",MessageBoxButtons.OK);
            }
            else
            {
                appointmentController.UpdateAppointment(textBox1.Text.ToString(), comboBox2.Text.ToString(), comboBox1.Text.ToString(), Convert.ToInt32(textBox4.Text), Convert.ToDateTime(dateTimePicker1.Value), textBox3.Text.ToString());
            }
            ReturnAppointment();
            ClearTools();
        }
        public void AppointmentAdd()
        {
            Appointment appointment = new Appointment(textBox1.Text, comboBox2.Text.ToString(), comboBox1.Text.ToString(), textBox4.Text, dateTimePicker1.Value.ToString(), textBox3.Text.ToString());
            ValidationContext context = new ValidationContext(appointment, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            //Above 3 Columns are for validations (Data Annotations.)

            if (!Validator.TryValidateObject(appointment, context, errors, true))
            {
                string xxx = "";
                foreach (ValidationResult result in errors)
                {
                    xxx += result.ErrorMessage + "\n";
                }
                MessageBox.Show(xxx, "Information", MessageBoxButtons.OK);
            }
            else
            {
                appointmentController.AddAppointment(textBox1.Text.ToString(), comboBox2.Text.ToString(), comboBox1.Text.ToString(), textBox4.Text.ToString(), Convert.ToDateTime(dateTimePicker1.Value), textBox3.Text.ToString());
            }
            ReturnAppointment();
            ClearTools();
        }
        public void AppointmentDelete()
        {

            if (dataGridView1.Rows.Count>0) // Checks if there is a column in the DataGridView
            {
                DialogResult dialog = MessageBox.Show("The selected record will be deleted. Are you sure?", "Information", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    string DwgId = dataGridView1.SelectedRows[0].Cells["AppointmentId"].Value.ToString();
                    appointmentController.DeleteAppointment(Convert.ToInt32(DwgId));
                    ReturnAppointment();
                    ClearTools();
                }
            }
            
        }
        #endregion
        #region Other Configs
        public void CustomTimePicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        public void GetId()
        {
            List<HospitalSystem.Models.Doctor> doctors = doctorController.GetDoctors();
            foreach (var item in doctors)
            {
                comboBox2.Items.Add(item.Id);
            }
        }
        public void GetBranchById()
        {
            comboBox1.Items.Clear();
            List<HospitalSystem.Models.Doctor> doctors = doctorController.GetDoctorsById(comboBox2.Text);
            foreach (var item in doctors)
            {
                comboBox1.Items.Add(item.Branch); // Get branch from ComboBox2.Text
            }
        }
        private void InitializeDataGridView() // Configuration for DGW
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
        public void ClearTools()
        {
            dateTimePicker1.Value = DateTime.Now;
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }
        #endregion
        public AppointmentPage()
        {
            InitializeComponent();
            this.FormClosing += AppointmentPage_FormClosing; // Configuration for form clossing.
        }

        private void AppointmentPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void AppointmentPage_Load(object sender, EventArgs e)
        {
            GetId();
            InitializeDataGridView();
            CustomTimePicker();
            ReturnAppointment();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AppointmentDelete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentAdd();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppointmentUpdate();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            AppointmentSearch();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBranchById();
        }
    }
}
