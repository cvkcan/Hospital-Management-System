using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    static public  class Database
    {
        static string Servers = @"Server=Can\SQLEXPRESS";
        static string Databases = "Database=HospitalSystem";
        static string Auth = "Trusted_Connection=True";
        static public SqlConnection connection()
        {
            string con = $"{Servers};{Databases};{Auth};";
            SqlConnection _connection = new SqlConnection(con);
            if (_connection.State!=System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
        static public SqlCommand command(string query)
        {
            SqlCommand _command = new SqlCommand(query,connection());
            return _command;
        }
    }
}
