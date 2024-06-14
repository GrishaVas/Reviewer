namespace Reviewer.Infrastructure.Models
{
    public class Director : Person
    {
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
