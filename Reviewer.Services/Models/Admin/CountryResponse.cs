using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Countries")]
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
