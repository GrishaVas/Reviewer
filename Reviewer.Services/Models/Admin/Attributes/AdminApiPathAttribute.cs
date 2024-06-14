namespace Reviewer.Services.Models.Admin.Attributes
{
    public class AdminApiPathAttribute : Attribute
    {
        public string Value { get; set; }

        public AdminApiPathAttribute(string value)
        {
            Value = value;
        }
    }
}
