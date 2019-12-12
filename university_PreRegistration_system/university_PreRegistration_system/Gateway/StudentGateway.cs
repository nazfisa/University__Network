using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class StudentGateway:Base
    {
        string registrationId;
        bool isExist;

        public int Save(Student student)
        {
            //string priviousRegistrationId;
            //priviousRegistrationId = GetLastRegistrationId(student);
            //int da = DateTime.Now.Year;
            //string deptCode = DepartmentCodeById(student.DepartmentId);
            /*string aa = "CSE-2015-009";


            var lastThreeDegitOfRegistrationId = aa.Substring(aa.Length - 3);
            
            int newNumber = Convert.ToInt32(lastThreeDegitOfRegistrationId) + 1;
            lastThreeDegitOfRegistrationId = newNumber.ToString("000");*/

           // string departmentIdAndDateAndCode = deptCode+"-"+da+"-"+deptCode;
            //string departmentIdAndDate = deptCode+"-"+da+"-001";
            if (!GetLastRegistrationId(student))
            {
                int da = DateTime.Now.Year;
                string deptCode = DepartmentCodeById(student.DepartmentId);
                string departmentIdAndDate = deptCode + "-" + da + "-001";
                string query = "INSERT INTO TblStudent(RegistrationId,Name,ContractNo,Date,Address,DepartmentId,DepartmentName) VALUES " +
                   "(@RegistrationId,@Name,@ContractNo,@Date,@Address,@DepartmentId,@DepartmentName)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegistrationId", departmentIdAndDate);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@ContractNo", student.contractNo);
                command.Parameters.AddWithValue("@Date", student.Date);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                command.Parameters.AddWithValue("@DepartmentName", student.DepartmentName);

            }
            else
            {
                int da = DateTime.Now.Year;
                string deptCode = DepartmentCodeById(student.DepartmentId);

                var lastThreeDegitOfRegistrationId = registrationId.Substring(registrationId.Length - 3);

                int newNumber = Convert.ToInt32(lastThreeDegitOfRegistrationId) + 1;
                lastThreeDegitOfRegistrationId = newNumber.ToString("000"); 

                 string departmentIdAndDateAndCode = deptCode+"-"+da+"-"+ lastThreeDegitOfRegistrationId;

                string query = "INSERT INTO TblStudent(RegistrationId,Name,ContractNo,Date,Address,DepartmentId,DepartmentName) VALUES " +
                   "(@RegistrationId,@Name,@ContractNo,@Date,@Address,@DepartmentId,@DepartmentName)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegistrationId", departmentIdAndDateAndCode);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@ContractNo", student.contractNo);
                command.Parameters.AddWithValue("@Date", student.Date);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
                command.Parameters.AddWithValue("@DepartmentName", student.DepartmentName);
            }



            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public List<Student> GetAllStudents()
        {
            string query = "SELECT * FROM TblStudent";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Student> StudentList = new List<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                student.RegistrationId = reader["RegistrationId"].ToString();
                student.Name = reader["Name"].ToString();
                student.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                StudentList.Add(student);
            }
            reader.Close();
            connection.Close();
            return StudentList;
        }
        public string DepartmentCodeById(int id)
        {
            string deptCode;

            string query = "SELECT Code FROM TblDepartment WHERE Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();

            deptCode = reader["Code"].ToString();
            
            connection.Close();
            return deptCode;
        }
        public bool GetLastRegistrationId(Student student)
        {
            string query = "SELECT TOP 1 * FROM TblStudent where DepartmentId=@DepartmentId ORDER BY RegistrationId DESC";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            isExist = reader.HasRows;
            if (isExist)
            {
                registrationId = reader["RegistrationId"].ToString();
            }

            connection.Close();
            return isExist;
        }
        public Student GetStudentByRegistraionId(string RgId)
        {
            string query = "SELECT * FROM TblStudent where RegistrationId=@RgId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RgId", RgId);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            Student student = null;
            if (reader.HasRows)
            {
                reader.Read();
                student = new Student();
                student.Name = reader["Name"].ToString();
                student.DepartmentName = reader["DepartmentName"].ToString();

            }
            return student;
        }

        public int StudentResultSave(StudentResult studentResult)
        {
            string query = "INSERT INTO StudentResult (StudentRegistrationNo, Name,Department,CourseId,Grade) VALUES " +
                "(@StudentRegistrationNo,@Name,@Department,@CourseId,@Grade)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentRegistrationNo", studentResult.StudentRegistrationNo);
            command.Parameters.AddWithValue("@Name", studentResult.Name);
            command.Parameters.AddWithValue("@Department", studentResult.Department);
            command.Parameters.AddWithValue("@CourseId", studentResult.CourseId);
            command.Parameters.AddWithValue("@Grade", studentResult.Grade);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}