using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class Booking : Entity
    {
        public int ClientID { get; set; }
        public int ClassScheduleID { get; set; }
        public DateTime BookingDate { get; set; }

        public override string GetInfo()
        {
            return $"Booking for Client {ClientID}, Class: {ClassScheduleID}, Date: {BookingDate.ToString("M/d/yyyy")}";
        }
    }

}
