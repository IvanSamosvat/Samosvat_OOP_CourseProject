using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class MarketingCampaignTests
    {
        [TestMethod]
        public void MarketingCampaign_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            string expectedType = "New Year Promo";
            DateTime expectedStart = new DateTime(2025, 12, 25);
            DateTime expectedEnd = new DateTime(2026, 1, 5);
            decimal expectedDiscount = 20;

            // Act
            var campaign = new MarketingCampaign
            {
                CampaignType = expectedType,
                StartDate = expectedStart,
                EndDate = expectedEnd,
                Discount = expectedDiscount
            };

            // Assert
            Assert.AreEqual(expectedType, campaign.CampaignType);
            Assert.AreEqual(expectedStart, campaign.StartDate);
            Assert.AreEqual(expectedEnd, campaign.EndDate);
            Assert.AreEqual(expectedDiscount, campaign.Discount);
        }

        [TestMethod]
        public void GetInfo_Should_ReturnFormattedCampaignString()
        {
            // Arrange
            var campaign = new MarketingCampaign
            {
                CampaignType = "Summer Sale",
                StartDate = new DateTime(2025, 7, 1),
                EndDate = new DateTime(2025, 7, 15),
                Discount = 30
            };

            // Act
            string info = campaign.GetInfo();

            // Assert
            StringAssert.Contains(info, "Campaign: Summer Sale");
            StringAssert.Contains(info, $"Start: {new DateTime(2025, 7, 1).ToString()}");
            StringAssert.Contains(info, "End: 15.07.2025 00:00:00");
            StringAssert.Contains(info, "Discount: 30%");
        }
    }
}
