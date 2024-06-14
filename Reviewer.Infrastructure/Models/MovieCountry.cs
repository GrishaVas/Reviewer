namespace Reviewer.Infrastructure.Models
{
    public class MovieCountry
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
