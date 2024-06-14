namespace Reviewer.Services.Models
{
    public abstract class BaseRefProp
    {
        public string Name { get; set; }
        public IEnumerable<object> Values { get; set; }
    }
}
