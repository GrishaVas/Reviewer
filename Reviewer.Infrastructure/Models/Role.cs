namespace Reviewer.Infrastructure.Models
{
    public class Role : BaseModel
    {
        public Guid ActorId { get; set; }
        public Actor Actor { get; set; }
        public string Name { get; set; }
        public Guid? MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
