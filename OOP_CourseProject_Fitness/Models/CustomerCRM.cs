using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class CustomerCRM : Entity
    {
        public List<string> VisitHistory { get; set; }
        public List<string> PersonalizedOffers { get; set; }

        public override string GetInfo()
        {
            return $"Customer CRM: Visits - {string.Join(", ", VisitHistory)}, Offers - {string.Join(", ", PersonalizedOffers)}";
        }
    }

}
