using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Models
{
    public class Patient
    {
        [Required(ErrorMessage = "PatientId is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Id is required!")]
        [RegularExpression("^[0-9]+$")]
        [MaxLength(9)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        public Patient(string name,string surname,string id,string gender, string diagnosis)
        {
            this.Name = name;
            this.Surname = surname;
            this.Id = id;
            this.Gender = gender;
            this.Diagnosis = diagnosis;
        }
    }
}
