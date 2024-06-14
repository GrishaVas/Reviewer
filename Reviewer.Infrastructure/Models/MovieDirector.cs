namespace Reviewer.Infrastructure.Models
{
    public class MovieDirector
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
