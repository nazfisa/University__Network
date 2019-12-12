using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class CourseManager
    {
        public CourseGateway courseGateway { get; private set; }
        public TeacherAssaignGateway teacherAssaignGateway { get; private set; }

        public CourseManager()
        {
            courseGateway = new CourseGateway();
            teacherAssaignGateway = new TeacherAssaignGateway();
        }
        public string Save(Course course)
        {

            if ((courseGateway.IsNameExists(course.Name) && courseGateway.IsCodeExists(course.Code)))
            {
                return "Course Name and Code Already Exists";
            }
            else if (courseGateway.IsNameExists(course.Name))
            {
                return "Course Name Already Exists";
            }
            else if (courseGateway.IsCodeExists(course.Code))
            {
                return "Course Code Already Exists";
            }
            else if (course.Credit < 0.5M || course.Credit > 5.0M)
            {
                return "Craddit can not be less then 0.5 and greater then 5.0";
            }
            else
            {
                if (courseGateway.Save(course) > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }
        public string EnrollCourseSave(EnrollCourse EnrollCourse)
        {
            if (courseGateway.CousreEnrollSave(EnrollCourse) > 0)
            {
                return "Save successful";
            }
            else
            {
                return "Save Failed";
            }
        }
        public string unassaignAllCourse()
        {
            if (teacherAssaignGateway.DeleteCreditToBeTaken()>0)
            {
                return "Delete successful";
            }
            else
            {
                return "Delete Failed";
            }
        }
        public List<Course> GetAllCourse()
        {
            return courseGateway.GetAllCourse();
        }
        public Course GetOneCourseById(int id)
        {
            return courseGateway.GetOneCourseById(id);
        }
        public List<Course> GetCourseByDepartmentId(int id)
        {
            return courseGateway.GetCourseByDepartmentId(id);
        }

    }
}