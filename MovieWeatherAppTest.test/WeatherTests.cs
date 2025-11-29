using MovieWeatherApp.Model;

namespace MovieWeatherAppTest.test
{
    using MovieWeatherApp.Model;
    using NUnit.Framework;
}

namespace MovieWeatherApp.Tests
{
    [TestFixture]
    public class WeatherTests
    {
        [Test]
        public void IsValid_WithValidCity_ReturnsTrue()
        {
            // Arrange
            var weather = new Weather { City = "London" };

            // Act
            bool result = weather.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_WithEmptyCity_ReturnsFalse()
        {
            // Arrange
            var weather = new Weather { City = "" };

            // Act
            bool result = weather.IsValid();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_WithShortCity_ReturnsFalse()
        {
            // Arrange
            var weather = new Weather { City = "A" }; // Less than 2 characters

            // Act
            bool result = weather.IsValid();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SuggestMovieMood_RainyWeather_SuggestsCozyMovies()
        {
            // Arrange
            var weather = new Weather { Description = "light rain", Temperature = 15 };

            // Act
            string suggestion = weather.SuggestMovieMood();

            // Assert
            Assert.That(suggestion, Does.Contain("Cozy indoor movies"));
        }

        [Test]
        public void SuggestMovieMood_SnowyWeather_SuggestsHolidayMovies()
        {
            // Arrange
            var weather = new Weather { Description = "snow", Temperature = -5 };

            // Act
            string suggestion = weather.SuggestMovieMood();

            // Assert
            Assert.That(suggestion, Does.Contain("holiday movies"));
        }

        [Test]
        public void SuggestMovieMood_SunnyWeather_SuggestsAdventureMovies()
        {
            // Arrange
            var weather = new Weather { Description = "clear sky", Temperature = 28 };

            // Act
            string suggestion = weather.SuggestMovieMood();

            // Assert
            Assert.That(suggestion, Does.Contain("adventure"));
        }
    }
}