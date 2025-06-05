using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWeb.Shared.DTOs.MaintenanceDTO
{
    public class CreateMonitoringReportDTO
    {
        public string LCNo { get; set; } = string.Empty;
        public string PONo { get; set; } = string.Empty;
        public string OpeningBank1 { get; set; } = string.Empty;
        public string OpeningBank2 { get; set; } = string.Empty;
        public DateTime OpenedFrom { get; set; } = DateTime.Now;
        public DateTime OpenedTo { get; set; } = DateTime.Now;
    }
}
