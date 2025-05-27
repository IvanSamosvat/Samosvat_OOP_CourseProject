using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class MembershipTests
    {
        [TestMethod]
        public void Membership_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            int expectedClientId = 1;
            string expectedType = "Gold";
            DateTime expectedStart = new DateTime(2025, 6, 1);
            DateTime expectedEnd = new DateTime(2025, 9, 1);
            decimal expectedDiscount = 15;

            // Act
            var membership = new Membership
            {
                ClientID = expectedClientId,
                MembershipType = expectedType,
                StartDate = expectedStart,
                EndDate = expectedEnd,
                Discount = expectedDiscount
            };

            // Assert
            Assert.AreEqual(expectedClientId, membership.ClientID);
            Assert.AreEqual(expectedType, membership.MembershipType);
            Assert.AreEqual(expectedStart, membership.StartDate);
            Assert.AreEqual(expectedEnd, membership.EndDate);
            Assert.AreEqual(expectedDiscount, membership.Discount);
        }

        [TestMethod]
        public void Membership_IHasDate_Implementation_Should_WorkCorrectly()
        {
            // Arrange
            var membership = new Membership();
            DateTime expectedDate = new DateTime(2025, 7, 1);

            // Act
            membership.Date = expectedDate;

            // Assert
            Assert.AreEqual(expectedDate, membership.StartDate);
            Assert.AreEqual(expectedDate, membership.Date);
        }

        [TestMethod]
        public void GetInfo_Should_ReturnFormattedString()
        {
            // Arrange
            var membership = new Membership
            {
                ClientID = 42,
                MembershipType = "Platinum",
                Discount = 25
            };

            // Act
            string info = membership.GetInfo();

            // Assert
            StringAssert.Contains(info, "Membership for Client 42");
            StringAssert.Contains(info, "Type: Platinum");
            StringAssert.Contains(info, "Discount: 25%");
        }
    }
}
