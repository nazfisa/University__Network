using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
        public List<string> getAllSemester()
        {
            List<string> semesters = new List<string>();
            semesters.Add("1st");
            semesters.Add("2nd");
            semesters.Add("3rd");
            semesters.Add("4th");
            semesters.Add("5th");
            semesters.Add("6th");
            semesters.Add("7th");
            semesters.Add("8th");
            return semesters;
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.semesters = getAllSemester();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.semesters = getAllSemester();
            if (ModelState.IsValid)
            {
                string message = courseManager.Save(course);
                ViewBag.Message = message;
                
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult EnrollCourse()
        {
            ViewBag.students = studentManager.GetAllStudents();
            ViewBag.courses = courseManager.GetAllCourse();
            return View();
        }

        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {

            ViewBag.students = studentManager.GetAllStudents();
            ViewBag.courses = courseManager.GetAllCourse();
            if (ModelState.IsValid)
            {
                string message = courseManager.EnrollCourseSave(enrollCourse);
                ViewBag.Message = message;

            }

            return View();
        }
        public JsonResult GetAllCourse()
        {
            List<Course> Course = courseManager.GetAllCourse();
            return Json(Course);
        }
        public JsonResult GetStudentByRegistraionId(string RgId)
        {
            Student student = studentManager.GetStudentByRegistraionId(RgId);
            return Json(student);
        }
        [HttpGet]
        public ActionResult unassaignAllCourse()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult unassaignAllCourse(string Course)
        {
            
            if (ModelState.IsValid)
            {
                string message = courseManager.unassaignAllCourse();
                ViewBag.Message = message;

            }

            return View();
        }
    }
}