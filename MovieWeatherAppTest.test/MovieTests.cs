using MovieWeatherApp.Model;

namespace MovieWeatherAppTest.test
{
    using NUnit.Framework;
}

namespace MovieWeatherApp.Tests
{
    [TestFixture]
    public class MovieTests
    {
        [Test]
        public void Equals_SameImdbID_ReturnsTrue()
        {
            var movie1 = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };
            var movie2 = new Movie { ImdbID = "tt0111161", Title = "Different Title" };
            bool result = movie1.Equals(movie2);
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_DifferentImdbID_ReturnsFalse()
        {
            var movie1 = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };
            var movie2 = new Movie { ImdbID = "tt0068646", Title = "The Godfather" };
            bool result = movie1.Equals(movie2);
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_NullObject_ReturnsFalse()
        {
            var movie = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };
            bool result = movie.Equals(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void CompareTo_NewerYear_ReturnsNegative()
        {
            var movie1 = new Movie { Year = "2020", Title = "Movie A" };
            var movie2 = new Movie { Year = "2015", Title = "Movie B" };
            int result = movie1.CompareTo(movie2);
            Assert.Less(result, 0); 
        }

        [Test]
        public void CompareTo_OlderYear_ReturnsPositive()
        {
            var movie1 = new Movie { Year = "2010", Title = "Movie A" };
            var movie2 = new Movie { Year = "2020", Title = "Movie B" };
            int result = movie1.CompareTo(movie2);
            Assert.Greater(result, 0);
        }

        [Test]
        public void CompareTo_SameYear_ReturnsZero()
        {
            var movie1 = new Movie { Year = "2020", Title = "Movie A" };
            var movie2 = new Movie { Year = "2020", Title = "Movie B" };
            int result = movie1.CompareTo(movie2);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void IsValid_WithTitleAndImdbID_ReturnsTrue()
        {
            var movie = new Movie { Title = "Inception", ImdbID = "tt1375666" };
            bool result = movie.IsValid();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_WithoutTitle_ReturnsFalse()
        {
            var movie = new Movie { Title = "", ImdbID = "tt1375666" };
            bool result = movie.IsValid();
            Assert.IsFalse(result);
        }
    }
}