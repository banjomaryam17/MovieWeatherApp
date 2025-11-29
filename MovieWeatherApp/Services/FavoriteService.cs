using System.Text.Json;
using MovieWeatherApp.Model;

namespace MovieWeatherApp.Services
{
    public static class FavoritesService
    {
        private static string FilePath = "favorites.json";

        // Get all favorites
        public static List<Movie> GetFavorites()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    var favorites = JsonSerializer.Deserialize<List<Movie>>(json);
                    return favorites ?? new List<Movie>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading favorites: {ex.Message}");
            }

            return new List<Movie>();
        }

        // Add a movie to favorites
        public static bool AddFavorite(Movie movie)
        {
            try
            {
                var favorites = GetFavorites();

                // Check if already in favorites
                if (favorites.Any(m => m.ImdbID == movie.ImdbID))
                {
                    return false; // Already exists
                }

                favorites.Add(movie);
                SaveFavorites(favorites);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding favorite: {ex.Message}");
                return false;
            }
        }

        // Remove a movie from favorites
        public static bool RemoveFavorite(string imdbId)
        {
            try
            {
                var favorites = GetFavorites();
                var movieToRemove = favorites.FirstOrDefault(m => m.ImdbID == imdbId);

                if (movieToRemove != null)
                {
                    favorites.Remove(movieToRemove);
                    SaveFavorites(favorites);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing favorite: {ex.Message}");
                return false;
            }
        }

        // Check if a movie is in favorites
        public static bool IsFavorite(string imdbId)
        {
            var favorites = GetFavorites();
            return favorites.Any(m => m.ImdbID == imdbId);
        }

        // Save favorites to file
        private static void SaveFavorites(List<Movie> favorites)
        {
            try
            {
                string json = JsonSerializer.Serialize(favorites, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving favorites: {ex.Message}");
            }
        }
    }
}