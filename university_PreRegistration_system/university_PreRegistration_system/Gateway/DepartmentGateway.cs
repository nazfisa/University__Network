using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class DepartmentGateway:Base
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO TblDepartment(Code, Name) VALUES (@Code,@Name)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Code", department.Code);
            command.Parameters.AddWithValue("@Name", department.Name);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public bool IsCodeExists(string Code)
        {
            string query = "SELECT * FROM TblDepartment WHERE Code=@Code";
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
            string query = "SELECT * FROM TblDepartment WHERE Name=@Name";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;


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
                department.Code = reader["Code"].ToString();
                departmentList.Add(department);
            }
            reader.Close();
            connection.Close();
            return departmentList;
        }
        public Department DepartmenentNameById(int id)
        {
            string query = "SELECT * FROM TblDepartment where Id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();
            Department department = null;
            if (reader.HasRows)
            {
                reader.Read();
                department = new Department();
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();

            }
            return department;
        }
    }
}