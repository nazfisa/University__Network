using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class StudentManager
    {
        public StudentGateway studentGateway { get; private set; }
        public DepartmentGateway departmentGateway { get; private set; }
        public StudentManager()
        {
            studentGateway = new StudentGateway();
            departmentGateway = new DepartmentGateway();
        }
        public string Save(Student student)
        {
            
            
                if (studentGateway.Save(student) > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            
        }
        public List<Student> GetAllStudents()
        {
            return studentGateway.GetAllStudents();
        }
        public Student GetStudentByRegistraionId(string RgId)
        {
            return studentGateway.GetStudentByRegistraionId(RgId);
        }
        public string StudentResultSave(StudentResult studentResult)
        {
            if (studentGateway.StudentResultSave(studentResult) > 0)
            {
                return "Save successful";
            }
            else
            {
                return "Save Failed";
            }
        }

    }
}