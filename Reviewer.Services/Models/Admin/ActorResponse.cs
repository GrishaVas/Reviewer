using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Actors", "Actor")]
    public class ActorResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
    }
}
