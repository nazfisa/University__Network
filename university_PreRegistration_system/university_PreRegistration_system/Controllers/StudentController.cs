using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StudentRegitration()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult StudentRegitration(Student student)
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            if (ModelState.IsValid)
            {
                int id = student.DepartmentId;
                Department department = departmentManager.DepartmenentNameById(id);
                student.DepartmentName = department.Name;
                string message = studentManager.Save(student);
                ViewBag.Message = message;
            }
            return View();

        }
        public JsonResult GetCourseByDepartmentId(int deptId)
        {
            List<Course> Course = courseManager.GetCourseByDepartmentId(deptId);
            return Json(Course);
        }
        public List<string> getAllGrade()
        {
            List<string> grade = new List<string>();
            grade.Add(" A+ ");
            grade.Add(" A ");
            grade.Add(" A- ");
            grade.Add(" B+ ");
            grade.Add(" B ");
            grade.Add(" B- ");
            return grade;
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
        public ActionResult StudentGrade()
        {
            ViewBag.students = studentManager.GetAllStudents();
            ViewBag.courses = courseManager.GetAllCourse();
            ViewBag.grades = getAllGrade();
            return View();
        }
        [HttpPost]
        public ActionResult StudentGrade(StudentResult studentResult)
        {

            ViewBag.students = studentManager.GetAllStudents();
            ViewBag.courses = courseManager.GetAllCourse();
            ViewBag.grades = getAllGrade();
            if (ModelState.IsValid)
            {
                string message = studentManager.StudentResultSave(studentResult);
                ViewBag.Message = message;

            }

            return View();
        }

    }
}