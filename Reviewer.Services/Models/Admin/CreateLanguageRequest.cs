using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeAddName("Languages")]
    public class CreateLanguageRequest
    {
        public string Name { get; set; }
    }
}
