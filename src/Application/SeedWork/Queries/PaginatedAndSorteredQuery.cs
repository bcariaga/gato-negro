namespace Application.SeedWork.Queries
{
    public abstract class PaginatedAndSorteredQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool Asc { get; set; }
    }
}