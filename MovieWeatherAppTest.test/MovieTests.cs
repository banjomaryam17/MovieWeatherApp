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
            // Arrange
            var movie1 = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };
            var movie2 = new Movie { ImdbID = "tt0111161", Title = "Different Title" };

            // Act
            bool result = movie1.Equals(movie2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_DifferentImdbID_ReturnsFalse()
        {
            // Arrange
            var movie1 = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };
            var movie2 = new Movie { ImdbID = "tt0068646", Title = "The Godfather" };

            // Act
            bool result = movie1.Equals(movie2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_NullObject_ReturnsFalse()
        {
            // Arrange
            var movie = new Movie { ImdbID = "tt0111161", Title = "The Shawshank Redemption" };

            // Act
            bool result = movie.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CompareTo_NewerYear_ReturnsNegative()
        {
            // Arrange
            var movie1 = new Movie { Year = "2020", Title = "Movie A" };
            var movie2 = new Movie { Year = "2015", Title = "Movie B" };

            // Act
            int result = movie1.CompareTo(movie2);

            // Assert
            Assert.Less(result, 0); // 2020 should come before 2015 (newer first)
        }

        [Test]
        public void CompareTo_OlderYear_ReturnsPositive()
        {
            // Arrange
            var movie1 = new Movie { Year = "2010", Title = "Movie A" };
            var movie2 = new Movie { Year = "2020", Title = "Movie B" };

            // Act
            int result = movie1.CompareTo(movie2);

            // Assert
            Assert.Greater(result, 0); // 2010 should come after 2020 (older)
        }

        [Test]
        public void CompareTo_SameYear_ReturnsZero()
        {
            // Arrange
            var movie1 = new Movie { Year = "2020", Title = "Movie A" };
            var movie2 = new Movie { Year = "2020", Title = "Movie B" };

            // Act
            int result = movie1.CompareTo(movie2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void IsValid_WithTitleAndImdbID_ReturnsTrue()
        {
            // Arrange
            var movie = new Movie { Title = "Inception", ImdbID = "tt1375666" };

            // Act
            bool result = movie.IsValid();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_WithoutTitle_ReturnsFalse()
        {
            // Arrange
            var movie = new Movie { Title = "", ImdbID = "tt1375666" };

            // Act
            bool result = movie.IsValid();

            // Assert
            Assert.IsFalse(result);
        }
    }
}