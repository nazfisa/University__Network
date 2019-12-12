using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        public string StudentRegistrationNo { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }

    }
}