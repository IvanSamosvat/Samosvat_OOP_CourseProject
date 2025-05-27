using System;
using System.Globalization;
using OOP_CourseProject_Fitness.Interfaces;
using OOP_CourseProject_Fitness.Models;
namespace OOP_CourseProject_Fitness.Models
{
    public class Payment : Entity, IPayable
    {
        public int ClientID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentType { get; set; }

        public override string GetInfo()
        {
            return $"Payment for Client {ClientID}, Amount: {Amount.ToString("F2", CultureInfo.InvariantCulture)}, Type: {PaymentType}, Date: {PaymentDate.ToString("yyyy-MM-dd HH:mm:ss")}";

        }
    }
}