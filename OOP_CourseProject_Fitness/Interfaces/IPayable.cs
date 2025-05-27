using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Interfaces
{
    public interface IPayable
    {
        decimal Amount { get; set; }
        DateTime PaymentDate { get; set; }
        string PaymentType { get; set; }
    }
}
