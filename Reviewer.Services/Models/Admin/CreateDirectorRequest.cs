using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Directors")]
    public class CreateDirectorRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
