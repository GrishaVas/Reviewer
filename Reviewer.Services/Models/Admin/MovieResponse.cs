using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Movies")]
    public class MovieResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tagline { get; set; }
        public TimeOnly Duration { get; set; }
        public int Rating { get; set; }
        public string Storyline { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<Guid> Countries { get; set; }
        public ICollection<Guid> Languages { get; set; }
        public ICollection<Guid> Directors { get; set; }
        public ICollection<Guid> Roles { get; set; }
        public ICollection<Guid> Genres { get; set; }
    }
}
