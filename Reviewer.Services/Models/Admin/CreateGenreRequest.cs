using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeAddName("Genres")]
    public class CreateGenreRequest
    {
        public string Name { get; set; }
    }
}
