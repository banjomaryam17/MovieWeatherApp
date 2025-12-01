using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieWeatherApp.Model
{
    public class Weather : BaseEntity
    {
        [Required(ErrorMessage = "City name is required")]
        [MinLength(3, ErrorMessage = "City name must be at least 3 characters")]
        public string City { get; set; }
        
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        public Weather()
        {
            City = string.Empty;
            Temperature = 0;
            Description = string.Empty;
            Icon = string.Empty;
            FeelsLike = 0;
            Humidity = 0;
        }
        
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(City) && City.Length >= 3;
        }

        public override int GetHashCode()
        {
            return Temperature.GetHashCode();
        }
        public string SuggestMovieMood()
        {
            var desc = Description.ToLower();
            
            if (desc.Contains("rain") || desc.Contains("drizzle"))
                return "Cozy indoor movies - perfect for thrillers or dramas!";
            else if (desc.Contains("snow"))
                return "Winter wonderland - great for holiday movies!";
            else if (desc.Contains("cloud"))
                return "Overcast day - ideal for mystery or indie films!";
            else if (Temperature > 25)
                return "Sunny and warm - try adventure or comedy movies!";
            else
                return "Perfect movie weather - any genre works!";
        }
    }
    
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("main")]
        public WeatherMain? Main { get; set; }
        
        [JsonPropertyName("weather")]
        public WeatherDescription[]? WeatherList { get; set; }
    }

    public class WeatherMain
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
}