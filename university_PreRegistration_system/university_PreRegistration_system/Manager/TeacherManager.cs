using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class TeacherManager
    {
        public TeacherGateway teacherGateway { get; private set; }
        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }
        public string Save(Teacher teacher)
        {
            if (teacherGateway.IsEmailExists(teacher.Email))
            {
                return "Email Already Exists";
            }
            else if(teacher.CreditTobeTaken<0)
            {
                return "Credit must be Can not be negative";
            }
            else
            {
                if (teacherGateway.Save(teacher) > 0)
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
}