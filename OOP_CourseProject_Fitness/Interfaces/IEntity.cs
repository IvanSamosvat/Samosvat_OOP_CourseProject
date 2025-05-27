using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Interfaces
{
    public interface IEntity
    {
        int ID { get; set; }
        string GetInfo();
    }
}
