using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Code")]
        [StringLength(7,MinimumLength =2)]
        public string Code { get; set; }
        [Required(ErrorMessage ="Please Enter Department Name")]
        public string Name { get; set; }
    }
}