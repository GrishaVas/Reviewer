using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Countries")]
    public class CreateCountryRequest
    {
        public string Name { get; set; }
    }
}
