using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Models.Tests
{
    [TestClass]
    public class PersonTests
    {
        private Person _unit = null;
        private readonly System.DateTimeOffset _now = System.DateTimeOffset.UtcNow;
        private readonly System.TimeSpan _thirtyYears = new System.TimeSpan(10950, 0, 0, 0, 0);

        [TestInitialize]
        public void Setup()
        {
            // Arrange - common
            _unit = new Person()
            {
                Given = "Test",
                Initials = "A",
                Family = "Subject",
                Born = _now.Subtract(_thirtyYears)
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
        public void PersonAgeAsOfAYearAgoIsCorrect()
        {
            // Act
            var ageAsOfAYearAgo = _unit.Age(System.DateTimeOffset.UtcNow.Subtract(new System.TimeSpan(365,0,0,0,0)));

            // Assert
            Assert.AreEqual(_thirtyYears.Days - 365, ageAsOfAYearAgo.Days );

        }

        [TestMethod]
        public void PersonAgeAsOfNowIsCorrect()
        {

            // Act
            var age = _unit.Age();

            // Assert
            Assert.AreEqual(_thirtyYears.Days, age.Days);
        }

    }
}
