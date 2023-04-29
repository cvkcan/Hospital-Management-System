using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Controllers
{
    public class DoctorController
    {    
        public bool AddDoctors(string name, string surname, int id, string password, string branch) //Ready to use. Only configuration is needed. 
        {
            try
            {

                SqlCommand sqlCommand = Database.command("Insert Into Doctor (Name,Surname,Id,Password,Branch) values (@name,@surname,@id,@password,@branch)");
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@surname", surname);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@branch", branch);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }
            }
            catch (SqlException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool UpdateDoctors(string name, string surname, int id, string password, string branch)//Ready to use. Only configuration is needed.
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Update Doctor Set Name=@Name,Surname=@Surname,Id=@Id,Password=@Password,Branch=@Branch");
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Surname", surname);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                sqlCommand.Parameters.AddWithValue("@Branch", branch);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        public bool DeleteDoctors(int id)//Ready to use. Only configuration is needed.
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Delete from Doctor Where Id=@Id");
                sqlCommand.Parameters.AddWithValue("@Id", id);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }

            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }
        //
        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            SqlCommand sqlCommand = Database.command("select * from Doctor");
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Doctor doctor = new Doctor(dataReader[0].ToString(), dataReader[1].ToString(), Convert.ToInt32(dataReader[2]), dataReader[3].ToString(), dataReader[4].ToString());
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }
        public bool DoctorLogin(string Id, string Pass)
        {
            SqlCommand sqlCommand = Database.command("Select count (*) from Doctor WHERE Id=@Id AND Password=@Password");
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@Password", Pass);
            bool result = (bool)Convert.ToBoolean(sqlCommand.ExecuteScalar());
            return result;
        }
        public List<Doctor> GetDoctorsById(string value)
        {
            List<Doctor> doctors = new List<Doctor>();
            SqlCommand sqlCommand = Database.command("select * from Doctor Where Id=@Id");
            sqlCommand.Parameters.AddWithValue("@Id", value);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Doctor doctor = new Doctor(dataReader[0].ToString(), dataReader[1].ToString(), Convert.ToInt32(dataReader[2]), dataReader[3].ToString(), dataReader[4].ToString());
                doctors.Add(doctor);
            }
            dataReader.Close();
            return doctors;
        }
        public string GetDoctorBranch(string Id)
        {
            string xyz = "";
            try
            {
                SqlCommand sqlCommand = Database.command("Select Branch From Doctor Where Id=@Id");
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    xyz = dataReader.GetString(0);
                }
            }
            catch (SqlException ex)
            {
                string error = ex.Message;
            }
            return xyz;
        }

    }
}
