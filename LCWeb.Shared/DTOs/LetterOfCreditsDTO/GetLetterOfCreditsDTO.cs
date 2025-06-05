using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Enums;
using LCWeb.Shared.Models.DraftLC;

namespace LCWeb.Shared.DTOs.LetterOfCreditsDTO
{
    public class GetLetterOfCreditsDTO
    {
        public int Id { get; set; }
        public LCStatus LCStatus { get; set; }
        public GetLCReleasingDTO DraftLCSection { get; set; }

        public int DraftLCSectionId { get; set; }

        public OpeningBank OpeningBank { get; set; }
        public string PONo { get; set; } = string.Empty;
        public string LCNo { get; set; } = string.Empty;
        public DateTime DateOpened { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime LatestShipDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
    }
}
