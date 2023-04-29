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
    public class AppointmentController
    { 
        public DataTable GetAppointment()
        {
            try
            {
                SqlCommand sqlCommand = Database.command("select * from Appointment");
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
        public DataTable SearchAppointment(string value)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Select * from Appointment Where AppointmentId Like '%" + value + "%' OR PatientId Like '%" + value + "%' OR DoctorId Like '%" + value + "%' Or BranchName Like '%" + value + "%' Or DateTime Like '%" + value + "%' OR Diagnosis Like '%" + value + "%'");
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
        public bool UpdateAppointment(string pId, string dId, string bName, long aId, DateTime date, string pdiag)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("UpdateAppointmentId"); // This is stock procedure name.
                sqlCommand.CommandType = CommandType.StoredProcedure; // Using stock procedure.
                sqlCommand.Parameters.AddWithValue("@PatientId", pId);
                sqlCommand.Parameters.AddWithValue("@DoctorId", dId);
                sqlCommand.Parameters.AddWithValue("@BranchName", bName);
                sqlCommand.Parameters.AddWithValue("@AppointmentId", aId);
                sqlCommand.Parameters.AddWithValue("@DateTime", date);
                sqlCommand.Parameters.AddWithValue("@Diagnosis", pdiag);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    System.Windows.Forms.MessageBox.Show("The record has been updated!", "Information", System.Windows.Forms.MessageBoxButtons.OK);
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
        public bool DeleteAppointment(int aId)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("delete from Appointment where AppointmentId=@AppointmentId");
                sqlCommand.Parameters.AddWithValue("@AppointmentId", aId);
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
        public bool AddAppointment(string pId, string dId, string bName, string aId, DateTime date, string pdiag)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("AddAppointment"); // This is Stock Procedure name.
                sqlCommand.CommandType = CommandType.StoredProcedure; // Using stock procedure
                sqlCommand.Parameters.AddWithValue("@PatientId", pId);
                sqlCommand.Parameters.AddWithValue("@DoctorId", dId);
                sqlCommand.Parameters.AddWithValue("@BranchName", bName);
                sqlCommand.Parameters.AddWithValue("@AppointmentId", aId);
                sqlCommand.Parameters.AddWithValue("@DateTime", date);
                sqlCommand.Parameters.AddWithValue("@Diagnosis", pdiag);
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
        public DataTable SearchAppointmentById(string value, string val)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("SELECT DateTime, AppointmentId, PatientId, Diagnosis FROM Appointment WHERE DoctorId = @DoctorId AND (AppointmentId Like '%" + value + "%' OR PatientId Like '%" + value + "%' OR Diagnosis Like '%" + value + "%')");
                sqlCommand.Parameters.AddWithValue("@DoctorId", val);
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
        public DataTable GetAppointmentById(string dId)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Select DateTime,AppointmentId,PatientId,Diagnosis From Appointment WHERE DoctorId=@DoctorId");
                sqlCommand.Parameters.AddWithValue("@DoctorId", dId);
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
        public bool UpdateForMainDoctor(DateTime dt,int aId,int pId,string dia)
        {
            try
            {
                SqlCommand sqlCommand = Database.command("Update Appointment Set DateTime=@DateTime, AppointmentId=@AppointmentId,PatientId=@PatientId,Diagnosis=@Diagnosis WHERE AppointmentId=@AppointmentId");
                sqlCommand.Parameters.AddWithValue("@AppointmentId",aId);
                sqlCommand.Parameters.AddWithValue("@DateTime",dt);
                sqlCommand.Parameters.AddWithValue("@PatientId",pId);
                sqlCommand.Parameters.AddWithValue("@Diagnosis",dia);
                if (sqlCommand.ExecuteNonQuery()>0)
                {
                    System.Windows.Forms.MessageBox.Show("The record has been updated!","Information",System.Windows.Forms.MessageBoxButtons.OK);
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
    }
}
