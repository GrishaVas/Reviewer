namespace Reviewer.Services.Models.Admin.Attributes
{
    public abstract class BaseAdminTypeAddNameAttribute : Attribute
    {
        public IEnumerable<string> Names { get; set; }

        protected BaseAdminTypeAddNameAttribute(params string[] names)
        {
            Names = names;
        }
    }
}
