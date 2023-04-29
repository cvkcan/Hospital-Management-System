using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers
{
    public class SecretaryController
    {
        public bool SecretaryLogin(string Id, string Pass)
        {
            SqlCommand sqlCommand = Database.command("Select Count(*) From Secretary Where Id=@Id AND Password=@Password");
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@Password", Pass);
            bool result = (bool)Convert.ToBoolean(sqlCommand.ExecuteScalar());
            return result;
        }
        public List<Secretary> GetSecretaries()
        {
            List<Secretary> secretaries = new List<Secretary>();
            SqlCommand sqlCommand = Database.command("select * from Secretary");
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Secretary secretary = new Secretary(dataReader[0].ToString(),dataReader[1].ToString(),Convert.ToInt32(dataReader[2]),dataReader[3].ToString());
                secretaries.Add(secretary);
            }
            dataReader.Close();
            return secretaries;
        }
        public bool AddSecretaries(string name, string surname, int id, string password)//Ready to use. Only configuration is needed.
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Insert into Secretary (Name,Surname,Id,Password) values (@Name,@Surname,@Id,@Password)");
                sqlCommand.Parameters.AddWithValue("@Name",name);
                sqlCommand.Parameters.AddWithValue("@Surname",surname);
                sqlCommand.Parameters.AddWithValue("@Id",id);
                sqlCommand.Parameters.AddWithValue("@Password",password);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }
                return true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool UpdateSecretaries(string name, string surname, int id, string password)//Ready to use. Only configuration is needed.
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Update Secretary Set Name=@Name, Surname=@Surname, Id=@Id, Password=@Password");
                sqlCommand.Parameters.AddWithValue("@Name",name);
                sqlCommand.Parameters.AddWithValue("@Surname",surname);
                sqlCommand.Parameters.AddWithValue("@Id",id);
                sqlCommand.Parameters.AddWithValue("@Password",password);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }return false;
        }
        public bool DeleteSecretaries(int id)//Ready to use. Only configuration is needed.
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Delete from Secretary Where Id=@Id");
                sqlCommand.Parameters.AddWithValue("@Id",id);
                if (sqlCommand.ExecuteNonQuery() > 0) { return true; }
                return true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
