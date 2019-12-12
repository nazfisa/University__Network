using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using university_PreRegistration_system.Models;

namespace university_PreRegistration_system.Gateway
{
    public class AllocateClassRoomsGateway:Base
    {
        public int Save(AllocateClassrooms allocateClassrooms)
        {
            int rowAffect = -1;
            
            bool isOverLapped=isOverlapp(allocateClassrooms.FromTime,allocateClassrooms.ToTime);
            if (!isOverLapped) { 
            string query = "INSERT INTO AssaignClassRoom (DepartmentId,CourseId,RoomNo,Day,FromTime,ToTIme,) VALUES " +
                "(@DepartmentId,@CourseId,@RoomNo,@Day,@FromTime,@ToTime,@CourseCode,@CourseName)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentId", allocateClassrooms.DepartmentId);
            command.Parameters.AddWithValue("@CourseId", allocateClassrooms.CourseId);
            command.Parameters.AddWithValue("@RoomNo", allocateClassrooms.RoomNo);
            command.Parameters.AddWithValue("@Day", allocateClassrooms.Day);
            command.Parameters.AddWithValue("@FromTime", allocateClassrooms.FromTime);
            command.Parameters.AddWithValue("@ToTime", allocateClassrooms.ToTime);
            command.Parameters.AddWithValue("@CourseCode", allocateClassrooms.CourseCode);
            command.Parameters.AddWithValue("@CourseName", allocateClassrooms.CourseName);
            
            connection.Open();
            rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
            }
            else
            {
            return rowAffect;
            }
        }
        public bool isOverlapp(DateTime FromTime, DateTime ToTime)
        {
            DateTime FromTimeInner, ToTimeInner;
            //int hour = Convert.ToInt32(FromTime);
            string FromTimeAm=FromTime.ToString("tt", CultureInfo.InvariantCulture);
            int FromTimeHour = FromTime.Hour;
            int FromTimeMinuite = FromTime.Minute;
            string ToTimeAm = ToTime.ToString("tt", CultureInfo.InvariantCulture);
            int ToTimeHour = ToTime.Hour;
            int ToTimeMinuite = ToTime.Minute;
            bool isExists=false;
            string query = "SELECT * FROM AssaignClassRoom";
            command = new SqlCommand(query, connection);
            connection.Open();
           // FromTime = FromTime.ToString("HH:mm:ss:tt");
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                FromTimeInner = Convert.ToDateTime(reader["FromTime"]);
                ToTimeInner = Convert.ToDateTime(reader["ToTime"]);
                string FromTimeInnerAm = FromTimeInner.ToString("tt", CultureInfo.InvariantCulture);
                int FromTimeInnerHour = FromTime.Hour;
                int FromTimeInnerMinuite = FromTime.Minute;
                string ToTimeInnerAm = ToTime.ToString("tt", CultureInfo.InvariantCulture);
                int ToTimeInnerHour = ToTime.Hour;
                int ToTimeInnerMinuite = ToTime.Minute;
                /*int resultFromGreaterBeginingTime,resultFromLessEndingTime, resultToGreaterBeginingTime, resultToLessEndingTime;
                resultFromGreaterBeginingTime = DateTime.Compare(FromTime, FromTimeInner);
                resultFromLessEndingTime = DateTime.Compare(FromTime, FromTimeInner);
                resultToGreaterBeginingTime = DateTime.Compare(ToTime, ToTimeInner);
                resultToLessEndingTime = DateTime.Compare(ToTime, ToTimeInner);
                if(resultFromGreaterBeginingTime==0 || resultFromLessEndingTime==0 || resultToGreaterBeginingTime==0|| resultToLessEndingTime==0 ||(resultFromGreaterBeginingTime<0 && resultFromLessEndingTime>0) ||(resultToGreaterBeginingTime<0 && resultToLessEndingTime>0))
                {
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }*/
                
                if(FromTimeAm== FromTimeInnerAm || FromTimeAm == ToTimeInnerAm || ToTimeAm == FromTimeInnerAm || ToTimeAm == ToTimeInnerAm)
                {
                    if((FromTimeHour >= FromTimeInnerHour && FromTimeHour<= ToTimeInnerHour)|| (ToTimeHour >= FromTimeInnerHour && ToTimeHour <= ToTimeInnerHour))
                    {
                        if ((FromTimeMinuite >= FromTimeInnerMinuite && FromTimeMinuite <= ToTimeInnerMinuite) || (ToTimeHour >= FromTimeInnerHour && ToTimeHour <= ToTimeInnerHour))
                        {
                            isExists = true;
                        }
                    }
                }

            }
            connection.Close();
            return isExists;
        }
        public List<AllocateClassrooms> GetAllClassByDepartmentId(int id)
        {
            string query = "SELECT * FROM AssaignClassRoom where DepartmentId=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            reader = command.ExecuteReader();
            List<AllocateClassrooms> classList = new List<AllocateClassrooms>();
            //teacherList.Add(new Teacher() { Id = 0, Name = "----Select----" });

            while (reader.Read())
            {
                AllocateClassrooms Class = new AllocateClassrooms();
                Class.Id = Convert.ToInt32(reader["Id"]);
                Class.CourseCode = reader["CourseCode"].ToString();
                Class.CourseName= reader["CourseName"].ToString();
                Class.Day = reader["Day"].ToString();
                Class.RoomNo = reader["RoomNo"].ToString();
                Class.FromTime = Convert.ToDateTime(reader["FromTime"]);
                Class.ToTime = Convert.ToDateTime(reader["ToTIme"]);
                classList.Add(Class);
            }
            reader.Close();
            connection.Close();
            return classList;
        }
        public int unallocateAllRooms()
        {
            string query = "DELETE FROM AssaignClassRoom";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }
        public int DeleteTeacherName()
        {
            
            string query = "UPDATE TblCourse SET TeacherName = 0";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;

        }

    }
}