using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Gateway;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Manager
{
    public class AllocateClassRoomManager
    {
        public AllocateClassRoomsGateway allocateClassRoomsGateway { get; private set; }
        public AllocateClassRoomManager()
        {
            allocateClassRoomsGateway = new AllocateClassRoomsGateway();
        }
        public string Save(AllocateClassrooms allocateClassrooms)
        {
                if (allocateClassRoomsGateway.Save(allocateClassrooms) > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Time Overlaped";
                }
         }
        public string unallocateAllRooms()
        {
            if (allocateClassRoomsGateway.unallocateAllRooms() > 0 && allocateClassRoomsGateway.DeleteTeacherName()>0)
            {
                return "Delete successful";
            }
            else
            {
                return "Delete Failed";
            }
        }
        public List<AllocateClassrooms> GetAllClassByDepartmentId(int id)
        {
            return allocateClassRoomsGateway.GetAllClassByDepartmentId(id);
        }
    }
   
}