using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CourseProject_Fitness.Models
{
    public class MarketingCampaign : Entity
    {
        public string CampaignType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }

        public override string GetInfo()
        {
            return $"Campaign: {CampaignType}, Start: {StartDate.ToString("M/d/yyyy")}, End: {EndDate.ToString("M/d/yyyy")}, Discount: {Discount}%";
        }
    }

}
