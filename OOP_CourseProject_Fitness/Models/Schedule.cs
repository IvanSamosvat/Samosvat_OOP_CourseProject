using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class Schedule : Entity
    {
        public int EmployeeID { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

        public override string GetInfo()
        {
            return $"Schedule for Employee {EmployeeID}, Shift: {ShiftStart} to {ShiftEnd}";
        }
    }

}
