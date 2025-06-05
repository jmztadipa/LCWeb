using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWeb.Shared.DTOs.MaintenanceDTO
{
    public class GetAmendmentReportDTO
    {
        public int Id { get; set; }
        public string LCNo { get; set; } = string.Empty;
        public string OpeningBank1 { get; set; } = string.Empty;
        public string OpeningBank2 { get; set; } = string.Empty;
        public DateTime ReceivedFrom { get; set; }
        public DateTime ReceivedTo { get; set; }
    }
}
