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
            var weather = new Weather { City = "London" };
            bool result = weather.IsValid();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_WithEmptyCity_ReturnsFalse()
        {
            var weather = new Weather { City = "" };
            bool result = weather.IsValid();
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_WithShortCity_ReturnsFalse()
        {
            var weather = new Weather { City = "A" }; 
            bool result = weather.IsValid();
            Assert.IsFalse(result);
        }

        [Test]
        public void SuggestMovieMood_RainyWeather_SuggestsCozyMovies()
        {
            var weather = new Weather { Description = "light rain", Temperature = 15 };
            string suggestion = weather.SuggestMovieMood();
            Assert.That(suggestion, Does.Contain("Cozy indoor movies"));
        }

        [Test]
        public void SuggestMovieMood_SnowyWeather_SuggestsHolidayMovies()
        {
            var weather = new Weather { Description = "snow", Temperature = -5 };
            string suggestion = weather.SuggestMovieMood();
            Assert.That(suggestion, Does.Contain("holiday movies"));
        }

        [Test]
        public void SuggestMovieMood_SunnyWeather_SuggestsAdventureMovies()
        {
            var weather = new Weather { Description = "clear sky", Temperature = 28 };
            string suggestion = weather.SuggestMovieMood();
            Assert.That(suggestion, Does.Contain("adventure"));
        }
    }
}