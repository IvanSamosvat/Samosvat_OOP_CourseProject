using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;

namespace TestProject
{
    [TestClass]
    public class AnalyticsTests
    {
        [TestMethod]
        public void GetInfo_ShouldReturnCorrectInfo()
        {
            // Arrange
            var analytics = new Analytics
            {
                AnalysisType = "Monthly",
                Period = new DateTime(2025, 1, 1),
                Revenue = 10000m,
                Expenses = 4000m
            };

            // Act
            var result = analytics.GetInfo();

            // Assert
            var expected = "Analytics: Monthly, Period: 01/01/2025 00:00:00, Revenue: 10000, Expenses: 4000";
            var actual = analytics.GetInfo();
            Assert.IsTrue(actual.Contains("Analytics: Monthly"));
            Assert.IsTrue(actual.Contains("Revenue: 10000"));
            Assert.IsTrue(actual.Contains("Expenses: 4000"));
        }

        [TestMethod]
        public void Should_Set_And_Get_AnalysisType()
        {
            var analytics = new Analytics { AnalysisType = "Weekly" };
            Assert.AreEqual("Weekly", analytics.AnalysisType);
        }

        [TestMethod]
        public void Should_Set_And_Get_Period()
        {
            var date = new DateTime(2025, 5, 27);
            var analytics = new Analytics { Period = date };
            Assert.AreEqual(date, analytics.Period);
        }

        [TestMethod]
        public void Should_Set_And_Get_Revenue()
        {
            var analytics = new Analytics { Revenue = 7500m };
            Assert.AreEqual(7500m, analytics.Revenue);
        }

        [TestMethod]
        public void Should_Set_And_Get_Expenses()
        {
            var analytics = new Analytics { Expenses = 2300m };
            Assert.AreEqual(2300m, analytics.Expenses);
        }

        [TestMethod]
        public void Should_Set_And_Get_Date_As_Period()
        {
            var date = new DateTime(2025, 12, 31);
            var analytics = new Analytics();
            analytics.Date = date;

            Assert.AreEqual(date, analytics.Date);
            Assert.AreEqual(date, analytics.Period); // Date — це обгортка для Period
        }
    }
}
