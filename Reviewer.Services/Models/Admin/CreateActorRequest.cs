using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Actors")]
    public class CreateActorRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
