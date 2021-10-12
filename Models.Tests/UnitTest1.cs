using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Models.Tests
{
    [TestClass]
    public class PersonTests
    {
        private Person _unit = null;
        private System.DateTimeOffset _now = System.DateTimeOffset.UtcNow;
        private System.TimeSpan aYearAgo = new System.TimeSpan(365, 0, 0, 0, 0);

        [TestInitialize]
        public void Setup()
        {
            // Arrange - common
            _unit = new Person()
            {
                Given = "Test",
                Initials = "A",
                Family = "Subject",
                Born = _now.Subtract(aYearAgo)
            };
        }


        [TestMethod]
        public void PersonCanRoundTripSerialisation()
        {

            // Act
            var data = JsonConvert.SerializeObject(_unit);
            var newUnit = JsonConvert.DeserializeObject<Person>(data);


            // Assert
            Assert.IsNotNull(newUnit);
        }


        [TestMethod]
        public void TestAgeAsOfNow()
        {

            // Act
            _unit.Born = _now.Subtract(aYearAgo);

            // Assert
            Assert.AreEqual(aYearAgo.Days, _unit.Age(_now).Days);
        }

        [TestMethod]
        public void TestAgeWithoutReferenceDate()
        {

            // Act
            var age = _unit.Age();

            // Assert
            Assert.AreEqual(aYearAgo.Days, age.Days);
        }

    }
}
