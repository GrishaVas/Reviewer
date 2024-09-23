namespace Reviewer.Services.Models.Admin.Attributes
{
    public abstract class BaseAdminTypeApiNameAttribute : Attribute
    {
        public string Name { get; set; }

        protected BaseAdminTypeApiNameAttribute(string name)
        {
            Name = name;
        }
    }
}
