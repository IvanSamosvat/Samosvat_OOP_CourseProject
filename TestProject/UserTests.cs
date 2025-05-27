using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_Creation_Should_SetPropertiesCorrectly()
        {
            // Arrange
            int expectedId = 1;
            string expectedUsername = "john_doe";
            string expectedPassword = "1234";
            string expectedRole = "User";

            // Act
            var user = new User
            {
                ID = expectedId,
                Username = expectedUsername,
                Password = expectedPassword,
                Role = expectedRole
            };

            // Assert
            Assert.AreEqual(expectedId, user.ID);
            Assert.AreEqual(expectedUsername, user.Username);
            Assert.AreEqual(expectedPassword, user.Password);
            Assert.AreEqual(expectedRole, user.Role);
        }
    }
}


