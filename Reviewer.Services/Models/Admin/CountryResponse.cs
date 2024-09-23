using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeApiName("Countries")]
    public class CountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
