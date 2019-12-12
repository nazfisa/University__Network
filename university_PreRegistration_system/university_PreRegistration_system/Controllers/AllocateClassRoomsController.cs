using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class AllocateClassRoomsController : Controller
    {
        CourseManager courseManager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();
        AllocateClassRoomManager allocateClassRoomManager = new AllocateClassRoomManager();
        public List<string> getAllDays()
        {
            List<string> Days = new List<string>();
            Days.Add("Saturday");
            Days.Add("Sunday");
            Days.Add("Monday");
            Days.Add("Tuesday");
            Days.Add("Wednesday");
            Days.Add("Thursday");
            Days.Add("Friday");
            return Days;
        }
        public List<string> getAllRooms()
        {
            List<string> Rooms = new List<string>();
            Rooms.Add("S101");
            Rooms.Add("S102");
            Rooms.Add("S103");
            Rooms.Add("S104");
            Rooms.Add("S105");
            return Rooms;
        }


        // GET: AllocateClassRooms
        [HttpGet]
        public ActionResult SaveClassRooms()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.courses = courseManager.GetAllCourse();
            ViewBag.days = getAllDays();
            ViewBag.rooms = getAllRooms();
            return View();
        }
        [HttpPost]
        public ActionResult SaveClassRooms(AllocateClassrooms allocateClassrooms)
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.courses = courseManager.GetAllCourse();
            ViewBag.days = getAllDays();
            ViewBag.rooms = getAllRooms();
           // List<Course> courseList= courseManager.GetAllCourse();
            if (ModelState.IsValid)
            {
                int id = allocateClassrooms.CourseId;
                Course courseList = courseManager.GetOneCourseById(id);
                allocateClassrooms.CourseCode = courseList.Code;
                allocateClassrooms.CourseName = courseList.Name;

                string message = allocateClassRoomManager.Save(allocateClassrooms);
                ViewBag.Message = message;

            }

            return View();
        }
        [HttpGet]
        public ActionResult ShowClassRoom()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }
        public JsonResult GetAllCourseByDepartmentId(int deptId)
        {
            List<AllocateClassrooms> assaignClass = allocateClassRoomManager.GetAllClassByDepartmentId(deptId);
            return Json(assaignClass);
        }

        [HttpGet]
        public ActionResult unallocateAllRooms()
        {
            return View();
        }

        [HttpPost]

        public ActionResult unallocateAllRooms(string ClassRoom)
        {

            if (ModelState.IsValid)
            {
                string message = allocateClassRoomManager.unallocateAllRooms();
                ViewBag.Message = message;

            }

            return View();
        }
    }
}