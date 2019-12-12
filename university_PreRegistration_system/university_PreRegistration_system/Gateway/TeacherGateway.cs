using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class TeacherGateway:Base
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO TblTeacher(Name,Address,Email,ContractNo,Designation,DepartmentId,CreditTobeTaken,RemainingCredit) VALUES " +
                   "(@Name,@Address,@Email,@ContractNo,@Designation,@DepartmentId,@CreditTobeTaken,@CreditTobeTaken)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", teacher.Name);
            command.Parameters.AddWithValue("@Address", teacher.Address);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@ContractNo", teacher.ContractNo);
            command.Parameters.AddWithValue("@Designation", teacher.Designation);
            command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            command.Parameters.AddWithValue("@CreditTobeTaken", teacher.CreditTobeTaken);
            command.Parameters.AddWithValue("@RemainingCredit", teacher.CreditTobeTaken);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public bool IsEmailExists(string Email)
        {
            string query = "SELECT * FROM TblTeacher WHERE Email=@Email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


        }

    }
    
}