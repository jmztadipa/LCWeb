using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWeb.Shared.Models.Maintenance
{
    public class MonitoringReport
    {
        [Key]
        public int Id { get; set; }
        public string LCNo { get; set; } = string.Empty;
        public string PONo { get; set; } = string.Empty;
        public string OpeningBank1 { get; set; } = string.Empty;
        public string OpeningBank2 { get; set; } = string.Empty;
        public DateTime OpenedFrom { get; set; }
        public DateTime OpenedTo { get; set; }
    }
}
