namespace Reviewer.Services.Models.Admin
{
    public class UpdateDirectorRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecodName { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
