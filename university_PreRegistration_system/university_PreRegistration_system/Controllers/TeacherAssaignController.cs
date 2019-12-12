using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class TeacherAssaignController : Controller
    {
        TeacherAssaignManager teacherAssaignManager = new TeacherAssaignManager();
        // GET: TeacherAssaign
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.departments = teacherAssaignManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Save(AssaignCourse assaignCourse)
        {
            ViewBag.departments = teacherAssaignManager.GetAllDepartment();
            if(ModelState.IsValid)
            {
                string message = teacherAssaignManager.Save(assaignCourse);
                string message1 = teacherAssaignManager.UpdateRemainingCredit(assaignCourse);
                string message2 = teacherAssaignManager.UpdateTeacherNameInCourse(assaignCourse);
                ViewBag.Message = message;
            }

            return View();
        }
        [HttpGet]
        public ActionResult showAssaignedCourse()
        {
            ViewBag.departments = teacherAssaignManager.GetAllDepartment();
            return View();
        }
        public JsonResult GetTeacherByDepartmentId(int deptId)
        {
            List<Teacher> assaignCourse=teacherAssaignManager.GetTeacherByDepartmentId(deptId);
            return Json(assaignCourse);
        }
        public JsonResult GetCourseByDepartmentId(int deptId)
        {
            List<Course> assaignCourse = teacherAssaignManager.GetCourseByDepartmentId(deptId);
            return Json(assaignCourse);
        }
        public JsonResult GetAllCourseByDepartmentId(int deptId)
        {
            List<Course> assaignCourse = teacherAssaignManager.GetAllCourseByDepartmentId(deptId);
            return Json(assaignCourse);
        }
        public JsonResult GetOneTeacherById(int TId)
        {
            Teacher assaignOneCourse = teacherAssaignManager.GetOneTeacherById(TId);
            return Json(assaignOneCourse);
        }
        public JsonResult GetOneCourseById(int CId)
        {
            Course assaignOneCourse = teacherAssaignManager.GetOneCourseById(CId);
            return Json(assaignOneCourse);
        }
        
    }
}