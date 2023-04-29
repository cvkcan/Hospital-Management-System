using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalSystem.Models
{
    public class Appointment
    {
        [Required(ErrorMessage = "PatientId is required!")]
        [RegularExpression("^[0-9]+$")]
        [MaxLength(9)]
        public string PateintId { get; set; }
        [Required(ErrorMessage = "PatientId is required!")]
        [RegularExpression("^[0-9]+$")]
        [MaxLength(9)]
        public string DoctorId { get; set; }      
        [Required(ErrorMessage ="BranchName is required!")]
        public string BranchName { get; set; }
        [Required(ErrorMessage = "PatientId is required!")]
        [RegularExpression("^[0-9]+$")]
        [MaxLength(17)]
        public string AppointmentId { get; set; }
        public string DateTime { get; set; }
        public string Pdiag { get; set; }
        public Appointment(/*int pId,int dId,string bName,int aId,DateTime date,string pdiag*/string pId, string dId, string bName, string aId, string date, string pdiag)
        {
            this.PateintId = pId;
            this.DoctorId = dId;
            this.BranchName = bName;
            this.AppointmentId= aId;
            this.DateTime = date;
            this.Pdiag = pdiag;
        }
    }
}
