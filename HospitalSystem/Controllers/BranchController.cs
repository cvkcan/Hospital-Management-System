using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystem.Models;


namespace HospitalSystem.Controllers
{
    public class BranchController
    {
        public List<Branch> GetBranches()
        {
            List<Branch> branches = new List<Branch>();
            SqlCommand sqlCommand = Database.command("select * from Branch");
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Branch branch = new Branch(Convert.ToInt32(dataReader[0]), dataReader[1].ToString());
                branches.Add(branch);   
            }
            dataReader.Close();
            return branches;
        }
    }
}
