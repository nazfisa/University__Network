using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Code")]
        [StringLength(50,MinimumLength =5)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string Name { get; set; }
        [Required]
        public decimal Credit { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Semester { get; set; }
        public string TeacherName { get; set; }
    }
}