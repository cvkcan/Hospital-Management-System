using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers
{
    public class PatientController
    {
        public DataTable GetPatients()
        {
            try
            {
                SqlCommand sqlCommand = Database.command("select * from Patient");
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlCommand.ExecuteReader());
                return dataTable;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
       
        public bool UpdatePatients(string name, string surname, string id, string gender, string diagnosis)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("UpdatePatientId"); // This is Stock Procedure name.
                sqlCommand.CommandType = CommandType.StoredProcedure;  // Using Stock Procedure
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Surname", surname);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Gender", gender);
                sqlCommand.Parameters.AddWithValue("@Diagnosis", diagnosis);
                
                if (sqlCommand.ExecuteNonQuery() > 0) {
                    System.Windows.Forms.MessageBox.Show("The record has been updated!","Information",System.Windows.Forms.MessageBoxButtons.OK);
                    return true; }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool DeletePatients(string id)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("delete from Patient where Id=@Id");
                sqlCommand.Parameters.AddWithValue("@Id", id);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    System.Windows.Forms.MessageBox.Show("The record has been deleted!", "Information", System.Windows.Forms.MessageBoxButtons.OK);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool AddPatients(string name, string surname, string id, string gender, string diagnosis)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("CheckPatientId"); // This is Stock Procedure name.
                sqlCommand.CommandType = CommandType.StoredProcedure; // Using stock procedure
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Surname", surname);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Gender", gender);
                sqlCommand.Parameters.AddWithValue("@Diagnosis", diagnosis);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    System.Windows.Forms.MessageBox.Show("The record has been added!", "Information", System.Windows.Forms.MessageBoxButtons.OK);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public DataTable SearchPatient(string value)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("select * from Patient where Name Like '%"+value+"%' OR Surname Like '%"+value+"%' OR Id Like '%"+value+"%' OR Gender Like '%"+value+"%' OR Diagnosis Like '%"+value+"%'");
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlCommand.ExecuteReader());
                return dataTable;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
