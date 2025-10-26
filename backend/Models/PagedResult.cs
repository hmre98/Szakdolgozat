using backend.Enums;

namespace backend.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public SortDirection SortDirection { get; set; }
        public List<T> Results { get; set; }
    }
}