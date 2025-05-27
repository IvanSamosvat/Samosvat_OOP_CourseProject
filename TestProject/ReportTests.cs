using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void Report_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            string expectedType = "Monthly";
            DateTime expectedDate = new DateTime(2025, 5, 1);
            decimal expectedIncome = 10000.50m;
            decimal expectedExpenses = 4500.75m;

            // Act
            var report = new Report
            {
                ReportType = expectedType,
                Date = expectedDate,
                Income = expectedIncome,
                Expenses = expectedExpenses
            };

            // Assert
            Assert.AreEqual(expectedType, report.ReportType);
            Assert.AreEqual(expectedDate, report.Date);
            Assert.AreEqual(expectedIncome, report.Income);
            Assert.AreEqual(expectedExpenses, report.Expenses);
        }
    }
}
