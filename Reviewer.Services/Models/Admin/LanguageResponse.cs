using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Languages")]
    public class LanguageResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
