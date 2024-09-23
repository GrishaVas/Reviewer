using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Languages")]
    public class CreateLanguageRequest
    {
        public string Name { get; set; }
    }
}
