using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeApiName("Genres")]
    public class GenreResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
