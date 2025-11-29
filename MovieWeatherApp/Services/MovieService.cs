using RestSharp;
using System.Text.Json;
using MovieWeatherApp.Model;

namespace MovieWeatherApp.Services
{
    public class MovieService
    {
        private static string URL = "https://www.omdbapi.com/";
        private static string APIKey = "bfb308aa"; 

        // Search movies by title
        public static async Task<List<Movie>?> SearchMoviesAsync(string searchTerm)
        {
          
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty");
                return null;
            }

            var client = new RestClient(URL);
            var request = new RestRequest();

         
            request.AddParameter("apikey", APIKey);
            request.AddParameter("s", searchTerm);
            request.AddParameter("type", "movie");

            try
            {
                var response = client.Execute(request);

                if (!string.IsNullOrEmpty(response.Content))
                {
                    var searchResult = JsonSerializer.Deserialize<MovieSearchResult>(
                        response.Content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (searchResult?.Search != null)
                    {
                        return searchResult.Search.ToList();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching movies: {ex.Message}");
                return null;
            }
        }

        // Get detailed movie info by IMDb ID
        public static async Task<Movie?> GetMovieDetailsAsync(string imdbId)
        {
        
            if (string.IsNullOrWhiteSpace(imdbId))
            {
                Console.WriteLine("IMDb ID cannot be empty");
                return null;
            }

            var client = new RestClient(URL);
            var request = new RestRequest();

           
            request.AddParameter("apikey", APIKey);
            request.AddParameter("i", imdbId);
            request.AddParameter("plot", "full");

            try
            {
                var response = client.Execute(request);

                if (!string.IsNullOrEmpty(response.Content))
                {
                    var movie = JsonSerializer.Deserialize<Movie>(
                        response.Content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    // Validate the movie object
                    if (movie != null && movie.IsValid())
                    {
                        return movie;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting movie details: {ex.Message}");
                return null;
            }
        }
    }
}