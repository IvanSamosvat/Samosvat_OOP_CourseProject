using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class ClassScheduleTests
    {
        [TestMethod]
        public void ClassSchedule_SetProperties_ShouldAssignCorrectly()
        {
            // Arrange
            var expectedClassType = "Yoga";
            var expectedDate = new DateTime(2025, 6, 1, 10, 0, 0);
            var expectedInstructor = "Anna Ivanova";
            var expectedSpots = 15;

            // Act
            var schedule = new ClassSchedule
            {
                ClassType = expectedClassType,
                ClassDate = expectedDate,
                Instructor = expectedInstructor,
                AvailableSpots = expectedSpots
            };

            // Assert
            Assert.AreEqual(expectedClassType, schedule.ClassType);
            Assert.AreEqual(expectedDate, schedule.ClassDate);
            Assert.AreEqual(expectedInstructor, schedule.Instructor);
            Assert.AreEqual(expectedSpots, schedule.AvailableSpots);
        }

        [TestMethod]
        public void GetInfo_ShouldReturnFormattedString()
        {
            // Arrange
            var schedule = new ClassSchedule
            {
                ClassType = "Pilates",
                ClassDate = new DateTime(2025, 7, 15, 18, 30, 0),
                Instructor = "Serhii Petrenko",
                AvailableSpots = 10
            };

            // Act
            string info = schedule.GetInfo();

            // Assert
            StringAssert.Contains(info, "Class: Pilates");
            StringAssert.Contains(info, "Instructor: Serhii Petrenko");
            StringAssert.Contains(info, "Available Spots: 10");
        }
    }
}
