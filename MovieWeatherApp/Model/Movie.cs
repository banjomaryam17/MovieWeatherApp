using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieWeatherApp.Model
{
    public class Movie :BaseEntity, IComparable<Movie>
    {
        [JsonPropertyName("Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [JsonPropertyName("Year")]
        public string Year { get; set; }
        
        [JsonPropertyName("imdbID")]
        [Required]
        public string ImdbID { get; set; }
        
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        
        [JsonPropertyName("Poster")]
        public string Poster { get; set; }
        
        [JsonPropertyName("Plot")]
        public string Plot { get; set; }
        
        [JsonPropertyName("imdbRating")]
        public string ImdbRating { get; set; }
        
        [JsonPropertyName("Genre")]
        public string Genre { get; set; }
        
        [JsonPropertyName("Director")]
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

        public override bool IsValid()
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

        public int CompareTo(Movie? other)
        {
            if (other == null) return 1;
            if (string.IsNullOrEmpty(this.Year) && string.IsNullOrEmpty(other.Year))
                return 0;
            if (string.IsNullOrEmpty(this.Year))
                return 1;
            if (string.IsNullOrEmpty(other.Year))
                return -1;
            return string.Compare(other.Year, this.Year, StringComparison.Ordinal);
        }
    }

    public class MovieSearchResult
    {
        [JsonPropertyName("Search")]
        public Movie[]? Search { get; set; }
        
        [JsonPropertyName("totalResults")]
        public string? TotalResults { get; set; }
        
        [JsonPropertyName("Response")]
        public string? Response { get; set; }
    }
}