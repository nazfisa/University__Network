using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class CourseGateway : Base
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO TblCourse(Code, Name,Credit,Description,DepartmentId,Semester) VALUES " +
                "(@Code,@Name,@Credit,@Description,@DepartmentId,@Semester)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", course.Code);
            command.Parameters.AddWithValue("@Name", course.Name);
            command.Parameters.AddWithValue("@Credit", course.Credit);
            command.Parameters.AddWithValue("@Description", course.Description);
            command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
            command.Parameters.AddWithValue("@Semester", course.Semester);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public int CousreEnrollSave(EnrollCourse courseEnroll)
        {
            string query = "INSERT INTO EnrollCourse(StudentRegistrationNo, Name,Department,CourseId,Date) VALUES " +
                "(@StudentRegistrationNo,@Name,@Department,@CourseId,@Date)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentRegistrationNo", courseEnroll.StudentRegistrationNo);
            command.Parameters.AddWithValue("@Name", courseEnroll.Name);
            command.Parameters.AddWithValue("@Department", courseEnroll.Department);
            command.Parameters.AddWithValue("@CourseId", courseEnroll.CourseId);
            command.Parameters.AddWithValue("@Date", courseEnroll.Date);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public bool IsCodeExists(string Code)
        {
            string query = "SELECT * FROM TblCourse WHERE Code=@Code";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", Code);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


        }
        public bool IsNameExists(string Name)
        {
            string query = "SELECT * FROM TblCourse WHERE Name=@Name";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;

        }
        public List<Course> GetAllCourse()
        {
            string query = "SELECT * FROM TblCourse";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();

            while (reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(reader["Id"]);
                course.Name = reader["Name"].ToString();
                course.Code = reader["Code"].ToString();
                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;
        }
        public Course GetOneCourseById(int id)
        {
            string query = "SELECT * FROM TblCourse where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            Course course = null;
            if (reader.HasRows)
            {
                reader.Read();
                course = new Course();
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();

            }
            return course;
        }

        public List<Course> GetCourseByDepartmentId(int id)
        {
            string query = "SELECT * FROM TblCourse where Department=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            List<Course> CourseList = new List<Course>();
            
            while (reader.HasRows)
            {
                reader.Read();
                Course course = new Course();
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                CourseList.Add(course);

            }
            return CourseList;
        }
        
        public int unassaignAllCourse()
        {
            string query = "DELETE FROM AssaignCourse";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }
    }
}