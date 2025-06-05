using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCWeb.Shared.DTOs.LetterOfCreditsDTO
{
    public class GetDraftLCListDTO
    {
        public int Id { get; set; }
        public string PONo { get; set; } = string.Empty;
    }
}
