namespace Reviewer.Infrastructure.Models
{
    public class Actor : Person
    {
        public ICollection<Role> Roles { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
