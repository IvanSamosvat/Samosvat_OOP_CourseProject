using System;
using OOP_CourseProject_Fitness.Interfaces;
using OOP_CourseProject_Fitness.Models;

public class Membership : Entity, IHasDate
{
    public int ClientID { get; set; }
    public string MembershipType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }

    public DateTime Date
    {
        get => StartDate;
        set => StartDate = value;
    }

    public override string GetInfo()
    {
        return $"Membership for Client {ClientID}, Type: {MembershipType}, Discount: {Discount}%";
    }
}