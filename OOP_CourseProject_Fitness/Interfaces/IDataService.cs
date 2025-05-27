using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Interfaces
{
    public interface IDataService
    {
        void SaveData<T>(List<T> data);
        List<T> LoadData<T>();
    }
}
