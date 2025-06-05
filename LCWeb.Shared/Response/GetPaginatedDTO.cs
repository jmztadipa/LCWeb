
using LCWeb.Shared.Enums;

namespace LCWeb.Shared.Response
{
    public class GetPaginatedDTO
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public LCStatus? Status { get; set; }
        public int? Id { get; set; }
        public string? SearchValue { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
