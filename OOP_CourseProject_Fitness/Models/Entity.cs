using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_CourseProject_Fitness.Interfaces;

namespace OOP_CourseProject_Fitness.Models
{
    public abstract class Entity : IEntity
    {
        public int ID { get; set; }
        public abstract string GetInfo();
    }

}
