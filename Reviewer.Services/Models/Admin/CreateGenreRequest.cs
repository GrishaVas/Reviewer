using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Genres")]
    public class CreateGenreRequest
    {
        public string Name { get; set; }
    }
}
