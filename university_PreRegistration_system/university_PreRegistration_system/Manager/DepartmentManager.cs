using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class DepartmentManager
    {
        public DepartmentGateway departmentGateway { get; private set; }
        public DepartmentManager()
            {
            departmentGateway= new DepartmentGateway();
            }
        public string Save(Department department)
        {
            if( (departmentGateway.IsNameExists(department.Name) && departmentGateway.IsCodeExists(department.Code)))
                    {
                return "Department Name and Code Already Exists";
            }
            else if (departmentGateway.IsNameExists(department.Name))
            {
                return "Department Name Already Exists";
            }
            else if (departmentGateway.IsCodeExists(department.Code))
            {
                return "Department Code Already Exists";
            }
            
            else
            {
                if (departmentGateway.Save(department) > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }
        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }
        public Department DepartmenentNameById(int id)
        {
            return departmentGateway.DepartmenentNameById(id);
        }
    }
}