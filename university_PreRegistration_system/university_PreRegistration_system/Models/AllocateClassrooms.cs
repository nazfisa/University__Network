using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace university_PreRegistration_system.Models
{
    public class AllocateClassrooms
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Select Room No")]
        [Display(Name = "Room No")]
        public string RoomNo { get; set; }
        [Required(ErrorMessage = "Please Select Day")]
        public string Day { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:H:mm}")]
        public DateTime FromTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime ToTime { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

    }
}