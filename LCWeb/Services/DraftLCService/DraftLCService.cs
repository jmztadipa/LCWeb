using LCWeb.Data;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Models.DraftLC;

namespace LCWeb.Services.DraftLCService
{
    public class DraftLCService : IDraftLCService
    {
        private readonly DataContext _context;

        public DraftLCService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateDraftLC(CreateDraftLCSectionDTO request)
        {
            var entry = new DraftLCSection
            {
                S1Confirmation = request.S1Confirmation,
                S1PONo = request.S1PONo,
                S1LCType = request.S1LCType,
                S1Enclosure = request.S1Enclosure,

                S2DateOfExpiry = request.S2DateOfExpiry,
                S2IssuingBank = request.S2IssuingBank,
                S2PlaceOfExpiry = request.S2PlaceOfExpiry,
                S2Remarks = request.S2Remarks,

                S3AdvisingBank = request.S3AdvisingBank,
                S3CreditAvailBy = request.S3CreditAvailBy,
                S3CreditAvailWith = request.S3CreditAvailWith,
                S3DifferredRemarks = request.S3DifferredRemarks,
                S3DraftAt = request.S3DraftAt,
                S3SwiftCode = request.S3SwiftCode,

                S4BeneficiaryName = request.S4BeneficiaryName,
                S4ItemDescription = request.S4ItemDescription,
                S4LCAmount = request.S4LCAmount,

                S5TTReimbursement = request.S5TTReimbursement,

                S6MannerOfShipment = request.S6MannerOfShipment,
                S6ShipmentTerms = request.S6ShipmentTerms,
                
                S7BeneficiaryName = request.S7BeneficiaryName,
                S7ItemDescription = request.S7ItemDescription,
                S7LatestShipDate = request.S7LatestShipDate,
                S7LCAmount = request.S7LCAmount,
                S7Remarks = request.S7Remarks,
                S7ShipmentFrom = request.S7ShipmentFrom,
                S7ShipmentTo = request.S7ShipmentTo,
                
                S8PartialShipment = request.S8PartialShipment,
                S8Transhipment = request.S8Transhipment,
                
                S9ReqDocuments = request.S9ReqDocuments,

                S10BankCharges = request.S10BankCharges,

                S11TermsAndCond = request.S11TermsAndCond,
            };
            _context.DraftLCSections.Add(entry);
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

    }
}
