using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class Secretary
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public  string Password { get; set; }
      
        
        public Secretary(string name,string surname, int id, string password)
        {
            this.Name = name;
            this.Surname = surname;
            this.Id = id;
            this.Password = password;
        }
    }
}
