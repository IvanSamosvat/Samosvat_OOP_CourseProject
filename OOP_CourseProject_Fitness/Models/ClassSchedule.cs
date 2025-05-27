using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class ClassSchedule : Entity
    {
        public string ClassType { get; set; }
        public DateTime ClassDate { get; set; }
        public string Instructor { get; set; }
        public int AvailableSpots { get; set; }

        public override string GetInfo()
        {
            return $"Class: {ClassType}, Date: {ClassDate}, Instructor: {Instructor}, Available Spots: {AvailableSpots}";
        }
    }

}
