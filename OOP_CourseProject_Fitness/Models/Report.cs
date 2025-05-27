using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class Report : Entity
    {
        public string ReportType { get; set; }
        public DateTime Date { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }

        public override string GetInfo()
        {
            return $"Report: {ReportType}, date: {Date}, Income: {Income}, Expenses: {Expenses}";
        }
    }

}
