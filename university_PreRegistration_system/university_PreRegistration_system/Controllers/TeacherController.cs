using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class TeacherController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        TeacherManager teacherManager = new TeacherManager();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public List<string> GetAllDesignations()
        {
            
           List<string> designations = new List<string>();
            designations.Add("Professor");
            designations.Add("Associate Professor");
            designations.Add("Assistant Professor");
            designations.Add("Lecturer");
            designations.Add("Assistant Lecturer");
            return designations;
        
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.designations = GetAllDesignations();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.designations = GetAllDesignations();
            if (ModelState.IsValid)
            {
                string message = teacherManager.Save(teacher);
                ViewBag.Message = message;

            }

            return View();
        }
    }
}