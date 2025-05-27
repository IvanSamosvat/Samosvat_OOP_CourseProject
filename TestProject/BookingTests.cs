using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void Booking_SetProperties_ShouldAssignCorrectly()
        {
            // Arrange
            int expectedClientId = 101;
            int expectedClassScheduleId = 202;
            DateTime expectedBookingDate = new DateTime(2025, 6, 20, 14, 0, 0);

            // Act
            var booking = new Booking
            {
                ClientID = expectedClientId,
                ClassScheduleID = expectedClassScheduleId,
                BookingDate = expectedBookingDate
            };

            // Assert
            Assert.AreEqual(expectedClientId, booking.ClientID);
            Assert.AreEqual(expectedClassScheduleId, booking.ClassScheduleID);
            Assert.AreEqual(expectedBookingDate, booking.BookingDate);
        }

        [TestMethod]
        public void GetInfo_ShouldReturnFormattedString()
        {
            // Arrange
            var booking = new Booking
            {
                ClientID = 123,
                ClassScheduleID = 456,
                BookingDate = new DateTime(2025, 7, 10, 9, 30, 0)
            };

            // Act
            string info = booking.GetInfo();

            // Assert
            StringAssert.Contains(info, "Booking for Client 123");
            StringAssert.Contains(info, "Class: 456");
        }
    }
}
