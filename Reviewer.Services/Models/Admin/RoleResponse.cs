using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeApiName("Roles")]
    public class RoleResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }
    }
}
