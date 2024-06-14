namespace Reviewer.Infrastructure.Models
{
    public class MovieLanguage
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
