using System.ComponentModel.DataAnnotations;
namespace MovieWeatherApp.Model
{
    public class Weather
    {
        [Required(ErrorMessage = "City name is required")]
        [MinLength(2, ErrorMessage = "City name must be at least 2 characters")]
        public string City { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public double FeelsLike { get; set; }
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
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(City) && City.Length >= 2;
        }
        
        public string SuggestMovieMood()
        {
            if (Description.Contains("rain") || Description.Contains("drizzle"))
                return "Cozy indoor movies - perfect for thrillers or dramas!";
            else if (Description.Contains("snow"))
                return "Winter wonderland - great for holiday movies!";
            else if (Description.Contains("cloud"))
                return "Overcast day - ideal for mystery or indie films!";
            else if (Temperature > 25)
                return "Sunny and warm - try adventure or comedy movies!";
            else
                return "Perfect movie weather - any genre works!";
        }
    }
}