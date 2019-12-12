using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using university_PreRegistration_system.Manager;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department depatment)
        {
            if(ModelState.IsValid)
            {
                string message = departmentManager.Save(depatment);
                ViewBag.Message = message;
            }
            return View();
        }
        public ActionResult ShowDepartment()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            return View(departments);
        }
    }
}