using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCWeb.Shared.Enums;
using LCWeb.Shared.Models.DraftLC;

namespace LCWeb.Shared.DTOs.LetterOfCreditsDTO
{
    public class CreateLetterOfCreditsDTO
    {
        public int DraftLCSectionId { get; set; }
        public OpeningBank OpeningBank { get; set; }
        public string LCNo { get; set; } = string.Empty;
        public DateTime DateOpened { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; } = DateTime.Now;
        public DateTime LatestShipDate { get; set; } = DateTime.Now;
    }
}
