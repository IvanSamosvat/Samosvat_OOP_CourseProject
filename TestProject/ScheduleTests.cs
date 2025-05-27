using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class ScheduleTests
    {
        [TestMethod]
        public void Schedule_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            int expectedEmployeeId = 101;
            DateTime expectedStart = new DateTime(2025, 6, 1, 9, 0, 0);
            DateTime expectedEnd = new DateTime(2025, 6, 1, 17, 0, 0);

            // Act
            var schedule = new Schedule
            {
                EmployeeID = expectedEmployeeId,
                ShiftStart = expectedStart,
                ShiftEnd = expectedEnd
            };

            // Assert
            Assert.AreEqual(expectedEmployeeId, schedule.EmployeeID);
            Assert.AreEqual(expectedStart, schedule.ShiftStart);
            Assert.AreEqual(expectedEnd, schedule.ShiftEnd);
        }

        [TestMethod]
        public void GetInfo_Should_ReturnFormattedString()
        {
            // Arrange
            var schedule = new Schedule
            {
                EmployeeID = 200,
                ShiftStart = new DateTime(2025, 6, 2, 8, 0, 0),
                ShiftEnd = new DateTime(2025, 6, 2, 16, 0, 0)
            };

            // Act
            string info = schedule.GetInfo();

            // Assert
            StringAssert.Contains(info, "Schedule for Employee 200");
            StringAssert.Contains(info, "2025");
        }
    }
}
