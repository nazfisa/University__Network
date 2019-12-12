using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class TeacherAssaignManager
    {
        public TeacherAssaignGateway teacherAssaignGateway { get; private set; }
        public TeacherAssaignManager()
        {
            teacherAssaignGateway = new TeacherAssaignGateway();
        }
        public string Save(AssaignCourse assaignCourse)
        {
            if (teacherAssaignGateway.IsCourseExists(assaignCourse.CourseId))
            {
                return "Course Already Exists";
            }
            else {
                if (teacherAssaignGateway.Save(assaignCourse) > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

            
            
        }
        public string UpdateRemainingCredit(AssaignCourse assaignCourse)
        {

            if (teacherAssaignGateway.UpdateRemainingCredit(assaignCourse) > 0)
            {
                return "Save successful";
            }
            else
            {
                return "Save Failed";
            }

        }
        public string UpdateTeacherNameInCourse(AssaignCourse assaignCourse)
        {

            if (teacherAssaignGateway.UpdateTeacherNameInCourse(assaignCourse) > 0)
            {
                return "Save successful";
            }
            else
            {
                return "Save Failed";
            }

        }
        public List<Department> GetAllDepartment()
        {
            return teacherAssaignGateway.GetAllDepartment();
        }
        public List<Teacher> GetTeacherByDepartmentId(int id)
        {
            return teacherAssaignGateway.GetTeacherByDepartmentId(id);
        }
        public Teacher GetOneTeacherById(int id)
        {
            return teacherAssaignGateway.GetOneTeacherById(id);
        }
        public List<Course> GetAllCourseByDepartmentId(int DepartmentId)
        {
            return teacherAssaignGateway.GetAllCourseByDepartmentId(DepartmentId);
        }
        public List<Course> GetCourseByDepartmentId(int id)
        {
            return teacherAssaignGateway.GetCourseByDepartmentId(id);
        }
        public Course GetOneCourseById(int id)
        {
            return teacherAssaignGateway.GetOneCourseById(id);
        }
    }

}