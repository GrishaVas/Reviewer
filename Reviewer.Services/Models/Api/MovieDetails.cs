namespace Reviewer.Services.Models.Api
{
    public class MovieDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tagline { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public string Storyline { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<CountryDetails> Countries { get; set; }
        public ICollection<LanguageDetails> Languages { get; set; }
        public ICollection<DirectorDetails> Directors { get; set; }
        public ICollection<RoleDetails> Roles { get; set; }
        public ICollection<GenreDetails> Genres { get; set; }
    }
}
