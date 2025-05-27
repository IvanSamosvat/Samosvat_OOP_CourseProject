using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string WorkSchedule { get; set; }

        public override string GetInfo()
        {
            return $"Employee: {Name}, Position: {Position}, Schedule: {WorkSchedule}";
        }
    }

}
