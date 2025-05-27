using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_CourseProject_Fitness.Models;

namespace OOP_CourseProject_Fitness.Tests
{
    public class TestEntity : Entity
    {
        public override string GetInfo()
        {
            return $"TestEntity with ID {ID}";
        }
    }

    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void Entity_ID_Should_Be_Settable()
        {
            // Arrange
            int expectedId = 123;
            var testEntity = new TestEntity { ID = expectedId };

            // Act & Assert
            Assert.AreEqual(expectedId, testEntity.ID);
        }

        [TestMethod]
        public void GetInfo_Should_ReturnExpectedString()
        {
            // Arrange
            var testEntity = new TestEntity { ID = 10 };

            // Act
            string info = testEntity.GetInfo();

            // Assert
            Assert.AreEqual("TestEntity with ID 10", info);
        }
    }
}
