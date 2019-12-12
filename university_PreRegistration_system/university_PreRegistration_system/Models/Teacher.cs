using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Department Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Contranct No")]
        public int ContractNo { get; set; }
        [Required(ErrorMessage = "Please Enter Designation")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Please Enter DepartmentId")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "A non negative Credit need to be taken")]
        public decimal CreditTobeTaken { get; set; }
        public decimal RemainingCredit { get; set; }

    }
}