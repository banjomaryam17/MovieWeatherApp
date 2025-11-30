# MovieWeatherApp - Plan Your Perfect Movie Night

A Blazor web application that combines weather forecasts with movie recommendations to help you plan the perfect movie night based on current weather conditions.

## Author
Maryam Ayomide Banjo

DkIT - Web Frameworks CA2 - November 2025

## Features
- 🌤️ Real-time weather information using OpenWeatherMap API
- 🎬 Movie search using OMDb API
- ⭐ Save favorite movies to JSON file
- 🔄 Recent search history
- 📊 Sort movies by year or title
- 💡 Weather-based movie mood suggestions

## Technologies
- C# / .NET 8.0
- Blazor Server
- RestSharp for API calls
- NUnit for testing
- Bootstrap for UI

## APIs Used
- [OMDb API](http://www.omdbapi.com/) - Movie database
- [OpenWeatherMap API](https://openweathermap.org/api) - Weather data

## Setup Instructions
1. Clone the repository
2. Add your API keys in `Services/MovieService.cs` and `Services/WeatherService.cs`
3. Navigate to: https://localhost:7220/movieweather


## Project Structure
- **Models**: Movie, Weather, BaseEntity (abstract class)
- **Services**: MovieService, WeatherService, FavoritesService
- **Components**: Blazor pages and UI components
- **Tests**: NUnit test project with comprehensive unit tests

## Key Features Demonstrated
- Abstract classes (BaseEntity) and interfaces (IComparable)
- Object comparison (Equals, CompareTo for sorting)
- Data validation with Data Annotations
- Error handling and input validation
- Unit testing with NUnit
- File I/O (JSON favorites storage)
- API integration with RestSharp
- Responsive UI with Bootstrap

## Context
This application helps users plan their movie night by suggesting movie genres based on current weather conditions. For example:
- Rainy weather → Suggests cozy indoor movies (thrillers, dramas)
- Sunny weather → Suggests adventure and comedy movies
- Snowy weather → Suggests holiday movies

Users can search for movies, save favorites, and quickly access recent searches for a personalized experience.


