using System.ComponentModel.DataAnnotations;
namespace MovieWeatherApp.Model
{
    public class Movie
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Year { get; set; }
        [Required] 
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string ImdbRating { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        
        public Movie()
        {
            Title = string.Empty;
            Year = string.Empty;
            ImdbID = string.Empty;
            Type = string.Empty;
            Poster = string.Empty;
            Plot = string.Empty;
            ImdbRating = string.Empty;
            Genre = string.Empty;
            Director = string.Empty;
        }
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Title) && 
                   !string.IsNullOrWhiteSpace(ImdbID);
        }


       
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Movie) return false;
            Movie other = (Movie)obj;
            return this.ImdbID == other.ImdbID;
        }

        public override int GetHashCode()
        {
            return ImdbID.GetHashCode();
        }
    }
}