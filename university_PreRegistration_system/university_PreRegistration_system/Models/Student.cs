using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class Student
    {
        public string RegistrationId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Contract No")]
        [Display(Name = "Contract No")]
        public int contractNo { get; set; }
        [Required(ErrorMessage = "Please fill the Date field")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Enter your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}