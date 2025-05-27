using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;
using System.ComponentModel;

namespace OOP_CourseProject_Fitness.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void NameProperty_ShouldConcatenateFirstAndLastName()
        {
            // Arrange
            var client = new Client
            {
                FirstName = "Ivan",
                LastName = "Petrov"
            };

            // Act
            string fullName = client.Name;

            // Assert
            Assert.AreEqual("Ivan Petrov", fullName);
        }

        [TestMethod]
        public void SettingName_ShouldSplitIntoFirstAndLastName()
        {
            // Arrange
            var client = new Client();

            // Act
            client.Name = "Olena Ivanova";

            // Assert
            Assert.AreEqual("Olena", client.FirstName);
            Assert.AreEqual("Ivanova", client.LastName);
        }

        [TestMethod]
        public void PropertyChanged_ShouldFireWhenPropertiesChange()
        {
            // Arrange
            var client = new Client();
            string changedProperty = null;
            client.PropertyChanged += (sender, e) => changedProperty = e.PropertyName;

            // Act
            client.Name = "John Smith";

            Assert.AreEqual("John", client.FirstName);
            Assert.AreEqual("Smith", client.LastName);

            // Act
            changedProperty = null;
            client.ContactInfo = "123-456";

            // Assert
            Assert.AreEqual("ContactInfo", changedProperty);

            // Act
            changedProperty = null;
            client.MedicalDetails = "None";

            // Assert
            Assert.AreEqual("MedicalDetails", changedProperty);
        }

        [TestMethod]
        public void GetInfo_ShouldReturnFormattedString()
        {
            // Arrange
            var client = new Client
            {
                FirstName = "Oleg",
                LastName = "Shevchenko",
                ContactInfo = "oleg@example.com",
                MedicalDetails = "Allergic to nuts"
            };

            // Act
            string info = client.GetInfo();

            // Assert
            StringAssert.Contains(info, "Oleg Shevchenko");
            StringAssert.Contains(info, "oleg@example.com");
            StringAssert.Contains(info, "Allergic to nuts");
        }
    }
}
