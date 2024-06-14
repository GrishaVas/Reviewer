namespace Reviewer.Services.Models
{
    public class RequestFilters
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public string Search { get; set; }
        public RequestFiltersOrder Order { get; set; }
    }
}
