using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalSystem.Models;
using HospitalSystem.Controllers;
using System.ComponentModel.DataAnnotations; // For validation from classes in models folder.

namespace HospitalSystem.Views
{
    public partial class SecretaryForm : Form
    {
        #region Add Controllers
        PatientController patientController= new PatientController();
        #endregion

        #region PatientRecord
        public void PatientSearch()
        {
            dataGridView1.DataSource= patientController.SearchPatient(textBox5.Text.ToString());
        }
        public void PatientAdd()
        {
            Patient patient = new Patient(textBox1.Text.ToString(), textBox2.Text.ToString(),textBox3.Text.ToString(), comboBox2.Text.ToString(), textBox4.Text.ToString());
            ValidationContext context = new ValidationContext(patient, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(patient,context,errors,true))
            // Above 3 columns are for validation.(Data Annotations.)

            {
                string xyz = "";
                foreach (ValidationResult result in errors)
                {
                    xyz += result.ErrorMessage + "\n";
                }
                MessageBox.Show(xyz,"Information",MessageBoxButtons.OK);
            }
            else
            {
                patientController.AddPatients(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), comboBox2.Text.ToString(), textBox4.Text.ToString());
                dataGridView1.DataSource = null;
                GetPatients();
            }
                ClearTools();
        }
        public void PatientDelete()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("The selected record will be deleted. Are you sure?", "Information", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    string DgwId = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                    patientController.DeletePatients(DgwId.ToString());
                    ClearTools();
                    GetPatients();
                }
            }
            
        }
        public void PatientUpdate()
        {
            Patient patient = new Patient(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), comboBox2.Text.ToString(), textBox4.Text.ToString());
            ValidationContext context = new ValidationContext(patient,null,null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            // Above 3 columns are for validation.(Data Annotations.)

            if (!Validator.TryValidateObject(patient,context,errors,true))
            {
                string xyz = "";
                foreach (var item in errors)
                {
                    xyz += item.ErrorMessage+"\n";
                }
                MessageBox.Show(xyz,"Information",MessageBoxButtons.OK);
            }
            else
            {
                patientController.UpdatePatients(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), comboBox2.Text.ToString(), textBox4.Text.ToString());
                GetPatients();
            }
                ClearTools();
        }
        public void GetPatients()
        {
            dataGridView1.DataSource = patientController.GetPatients();
            dataGridView1.Columns[dataGridView1.Columns.Count - 3].Width = 50;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        #endregion

        #region Other Configs
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
        public void GetGender()
        {
            string[] genders = { "Erkek", "Kadin" };
            comboBox2.Items.AddRange(genders);
        }
        

        public void ClearTools()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;
        }
        #endregion


        public SecretaryForm()
        {
            InitializeComponent();
            this.FormClosing += SecretaryForm_FormClosing;
        }

        private void SecretaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Owner.Show();
        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            GetGender();
            GetPatients();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientAdd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientDelete();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientUpdate();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            PatientSearch();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
