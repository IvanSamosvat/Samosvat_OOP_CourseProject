using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class PaymentTests
    {
        [TestMethod]
        public void Payment_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            int expectedClientId = 5;
            decimal expectedAmount = 120.75m;
            DateTime expectedDate = new DateTime(2025, 5, 27);
            string expectedType = "Credit Card";

            // Act
            var payment = new Payment
            {
                ClientID = expectedClientId,
                Amount = expectedAmount,
                PaymentDate = expectedDate,
                PaymentType = expectedType
            };

            // Assert
            Assert.AreEqual(expectedClientId, payment.ClientID);
            Assert.AreEqual(expectedAmount, payment.Amount);
            Assert.AreEqual(expectedDate, payment.PaymentDate);
            Assert.AreEqual(expectedType, payment.PaymentType);
        }
    }
}
