using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminCreateTypeApiName("Roles")]
    public class CreateRoleRequest
    {
        public string Name { get; set; }
        [AdminApiPath("Actors")]
        public Guid Actor { get; set; }
    }
}
