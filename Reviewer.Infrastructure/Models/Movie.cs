namespace Reviewer.Infrastructure.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tagline { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public string Storyline { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<MovieCountry> Countries { get; set; }
        public ICollection<MovieLanguage> Languages { get; set; }
        public ICollection<MovieDirector> Directors { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }
    }
}
