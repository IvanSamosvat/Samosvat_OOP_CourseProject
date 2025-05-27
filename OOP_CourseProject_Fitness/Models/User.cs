using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_CourseProject_Fitness.Interfaces;

namespace OOP_CourseProject_Fitness.Models
{
    public class User : IUserRole
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

}
