using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class AssaignCourse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int Status { get; set; }
        public decimal RemainingCredit { get; set; }
        public string TeacherName { get; set; }
    }
}