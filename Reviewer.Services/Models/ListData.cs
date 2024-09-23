namespace Reviewer.Services.Models
{
    public class ListData<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public int DataMaxCount { get; set; }

        public ListData GetListData()
        {
            var getListData = new ListData
            {
                Data = Data.Select(x => (object)x),
                Count = Count,
                DataMaxCount = DataMaxCount,
                Page = Page
            };

            return getListData;
        }
    }

    public class ListData
    {
        public IEnumerable<object> Data { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public int DataMaxCount { get; set; }
    }
}
