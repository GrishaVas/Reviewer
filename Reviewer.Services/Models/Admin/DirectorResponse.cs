using Reviewer.Services.Models.Admin.Attributes;

namespace Reviewer.Services.Models.Admin
{
    [AdminResponseTypeAddName("Directors")]
    public class DirectorResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public ICollection<Guid> Movies { get; set; }
        public ICollection<Guid> Genres { get; set; }
    }
}
