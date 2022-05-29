namespace FDNS.WebAPI.Models.Domains
{
    public class DomainsGetListRequest
    {
        public string? ListType { get; set; }
        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public string? SortBy { get; set; }
    }
}
