using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class TeacherAssaignGateway:Base
    {
        public int Save(AssaignCourse assaignCourse)
        {
            string query = "INSERT INTO AssaignCourse(DepartmentId,CourseId,Status,TeacherId,RemainingCredit,TeacherName) VALUES " +
                   "(@DepartmentId,@CourseId,@Status,@TeacherId,@RemainingCredit,@TeacherName)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentId", assaignCourse.CourseId);
            command.Parameters.AddWithValue("@CourseId", assaignCourse.CourseId);
            command.Parameters.AddWithValue("@Status", 1);
            command.Parameters.AddWithValue("@TeacherId", assaignCourse.TeacherId);
            command.Parameters.AddWithValue("@RemainingCredit", assaignCourse.RemainingCredit);
            command.Parameters.AddWithValue("@TeacherName", assaignCourse.TeacherName);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public int UpdateRemainingCredit(AssaignCourse assaignCourse)
        {
            string query = "Update TblTeacher SET RemainingCredit=@RemainingCredit where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RemainingCredit", assaignCourse.RemainingCredit);
            command.Parameters.AddWithValue("@id", assaignCourse.TeacherId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public int UpdateTeacherNameInCourse(AssaignCourse assaignCourse)
        {
            string query = "Update TblCourse SET TeacherName=@TeacherName where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherName", assaignCourse.TeacherName);
            command.Parameters.AddWithValue("@id", assaignCourse.CourseId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCourseExists(int cousre)
        {
            string query = "SELECT * FROM AssaignCourse WHERE CourseId=@cousre";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@cousre", cousre);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


        }
        public List<Course> GetCourseByDepartmentId(int id)
        {
            string query = "SELECT * FROM TblCourse where DepartmentId=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            //teacherList.Add(new Teacher() { Id = 0, Name = "----Select----" });

            while (reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(reader["Id"]);
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Semester = reader["Semester"].ToString();
                course.TeacherName = reader["TeacherName"].ToString();
                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;
        }
        public List<Department> GetAllDepartment()
        {
            string query = "SELECT * FROM TblDepartment";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Department> departmentList = new List<Department>();

            while (reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(reader["Id"]);
                department.Name = reader["Name"].ToString();
                departmentList.Add(department);
            }
            reader.Close();
            connection.Close();
            return departmentList;
        }
        public List<Teacher> GetTeacherByDepartmentId(int id)
        {
            string query = "SELECT * FROM TblTeacher where DepartmentId=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            List<Teacher> teacherList = new List<Teacher>();
            teacherList.Add(new Teacher() { Id = 0, Name = "----Select----" });

            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(reader["Id"]);
                teacher.Name = reader["Name"].ToString();
                teacher.CreditTobeTaken = Convert.ToInt32(reader["CreditTobeTaken"]);
                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teacherList;
        }
        public Teacher GetOneTeacherById(int id)
        {
            string query = "SELECT * FROM TblTeacher where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            Teacher teacher = null;
            if (reader.HasRows)
            {
                reader.Read();
                teacher = new Teacher();
                teacher.Id = Convert.ToInt32(reader["Id"]);
                teacher.Name = reader["Name"].ToString();
                teacher.CreditTobeTaken = Convert.ToDecimal(reader["CreditTobeTaken"]);
                teacher.RemainingCredit = Convert.ToDecimal(reader["RemainingCredit"]);
               
            }
           
            reader.Close();
            connection.Close();
            return teacher;
        }
        public List<Course> GetAllCourseByDepartmentId(int DepartmentId)
        {
            string query = "SELECT * FROM TblCourse where DepartmentId=@DepartmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentId", DepartmentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            courseList.Add(new Course() { Id = 0, Code = "----Select----" });

            while (reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(reader["Id"]);
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(reader["Credit"]);
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
            Course course = null;
            if (reader.HasRows)
            {
                reader.Read();
                course = new Course();
                course.Id = Convert.ToInt32(reader["Id"]);
                course.Name = reader["Name"].ToString();
                course.Code = reader["Code"].ToString();
                course.Credit = Convert.ToDecimal(reader["Credit"]);

            }

            reader.Close();
            connection.Close();
            return course;
        }
        public int DeleteCreditToBeTaken()
        {
            double zerro = 0.0;
            string query = "UPDATE TblTeacher SET RemainingCredit = @zerro";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@zerro", zerro);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }

    }
   
}