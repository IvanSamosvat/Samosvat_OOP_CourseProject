using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System.Collections.Generic;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class CustomerCRMTests
    {
        [TestMethod]
        public void CustomerCRM_Should_SetVisitHistoryAndOffersCorrectly()
        {
            // Arrange
            var visits = new List<string> { "2025-05-01", "2025-05-10" };
            var offers = new List<string> { "10% Off", "Free Session" };

            // Act
            var customerCRM = new CustomerCRM
            {
                VisitHistory = visits,
                PersonalizedOffers = offers
            };

            // Assert
            CollectionAssert.AreEqual(visits, customerCRM.VisitHistory);
            CollectionAssert.AreEqual(offers, customerCRM.PersonalizedOffers);
        }

        [TestMethod]
        public void GetInfo_Should_ReturnFormattedString()
        {
            // Arrange
            var customerCRM = new CustomerCRM
            {
                VisitHistory = new List<string> { "2025-05-01", "2025-05-10" },
                PersonalizedOffers = new List<string> { "10% Off", "Free Session" }
            };

            // Act
            string info = customerCRM.GetInfo();

            // Assert
            StringAssert.Contains(info, "Visits - 2025-05-01, 2025-05-10");
            StringAssert.Contains(info, "Offers - 10% Off, Free Session");
        }
    }
}
