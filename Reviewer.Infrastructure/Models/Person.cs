namespace Reviewer.Infrastructure.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
