using RestSharp;
using System.Text.Json;
using MovieWeatherApp.Model;

namespace MovieWeatherApp.Services
{
    public class WeatherService
    {
        private static string URL = "https://api.openweathermap.org/data/2.5/weather";
        private static string APIKey = "YOUR_OPENWEATHER_API_KEY_HERE"; // Replace with your actual key

        // Get weather by city name
        public static async Task<Weather?> GetWeatherAsync(string city)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(city) || city.Length < 2)
            {
                Console.WriteLine("City name must be at least 2 characters");
                return null;
            }

            var client = new RestClient(URL);
            var request = new RestRequest();

            // Add parameters
            request.AddParameter("q", city);
            request.AddParameter("appid", APIKey);
            request.AddParameter("units", "metric"); // Celsius

            try
            {
                var response = client.Execute(request);

                if (!string.IsNullOrEmpty(response.Content))
                {
                    var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(
                        response.Content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (weatherResponse != null && weatherResponse.Main != null)
                    {
                        // Map API response to our Weather model
                        var weather = new Weather
                        {
                            City = weatherResponse.Name ?? city,
                            Temperature = weatherResponse.Main.Temp,
                            FeelsLike = weatherResponse.Main.FeelsLike,
                            Humidity = weatherResponse.Main.Humidity,
                            Description = weatherResponse.WeatherList?[0]?.Description ?? "Unknown",
                            Icon = weatherResponse.WeatherList?[0]?.Icon ?? ""
                        };

                        // Validate before returning
                        if (weather.IsValid())
                        {
                            return weather;
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting weather: {ex.Message}");
                return null;
            }
        }
    }
}