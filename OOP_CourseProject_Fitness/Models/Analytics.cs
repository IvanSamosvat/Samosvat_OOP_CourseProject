using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_CourseProject_Fitness.Interfaces;

namespace OOP_CourseProject_Fitness.Models
{
    public class Analytics : Entity, IHasDate
    {
        public string AnalysisType { get; set; }
        public DateTime Period { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }

        public DateTime Date
        {
            get => Period;
            set => Period = value;
        }

        public override string GetInfo()
        {
            return $"Analytics: {AnalysisType}, Period: {Period}, Revenue: {Revenue}, Expenses: {Expenses}";
        }
    }

}
