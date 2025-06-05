using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LCWeb.Shared.Enums;
using LCWeb.Shared.Models.LC;

namespace LCWeb.Shared.Models.DraftLC
{
    public class DraftLCSection
    {
        [Key]
        public int Id { get; set; }
        public LCStatus LCStatus { get; set; }

        //SECTION 1
        public DateTime S1Date { get; set; }
        public string S1PONo {  get; set; } = string.Empty;
        public string S1LCType {  get; set; } = string.Empty;
        public string S1Confirmation {  get; set; } = string.Empty;
        public string S1Enclosure {  get; set; } = string.Empty;

        //SECTION 2
        public string S2IssuingBank { get; set; } = string.Empty;
        public DateTime S2DateOfExpiry { get; set; }
        public string S2Remarks { get; set;} = string.Empty;
        public string S2PlaceOfExpiry { get; set;} = string.Empty;

        //SECTION 3
        public string S3DraftAt { get; set; } = string.Empty;
        public string S3DifferredRemarks { get; set; } = string.Empty;
        public string S3CreditAvailWith { get; set; } = string.Empty;
        public string S3CreditAvailBy { get; set; } = string.Empty;
        public string S3AdvisingBank { get; set; } = string.Empty;
        public string S3SwiftCode { get; set; } = string.Empty;

        //SECTION 4
        public string S4BeneficiaryName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal S4Currency { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal S4Figures { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal S4ForexRate { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal S4LCAmount { get; set; } = 0;

        public string S4ItemDescription { get; set; } = string.Empty;

        //SECTION 5
        public string S5TTReimbursement { get; set; } = string.Empty;

        //SECTION 6
        public string S6MannerOfShipment { get; set; } = string.Empty;
        public string S6ShipmentTerms { get; set; } = string.Empty;

        //SECTION 7
        public string S7BeneficiaryName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal S7LCAmount { get; set; } = 0;
        public string S7ItemDescription { get; set; } = string.Empty;
        public DateTime S7LatestShipDate { get; set; }
        public string S7Remarks { get; set; } = string.Empty;
        public string S7ShipmentFrom { get; set; } = string.Empty;
        public string S7ShipmentTo { get; set; } = string.Empty;

        //SECTION 8
        public string S8PartialShipment { get; set; } = string.Empty;
        public string S8Transhipment { get; set; } = string.Empty;

        //SECTION 9
        public string S9ReqDocuments { get; set; } = string.Empty;

        //SECTION 10
        public string S10BankCharges { get; set; } = string.Empty;

        //SECTION 11
        public string S11TermsAndCond { get; set; } = string.Empty;

        [JsonIgnore]
        public List<LetterOfCredit>? LetterOfCredits { get; set; }

    }
}
