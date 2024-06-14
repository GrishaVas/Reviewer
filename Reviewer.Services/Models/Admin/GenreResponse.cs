using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Genres")]
    public class GenreResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
