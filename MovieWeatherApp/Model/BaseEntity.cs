namespace MovieWeatherApp.Model;


    public abstract class BaseEntity
    {
        public abstract bool IsValid();
        public abstract int GetHashCode();
    }
