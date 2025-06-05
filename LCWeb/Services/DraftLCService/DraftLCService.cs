using LCWeb.Data;
using LCWeb.Shared.DTOs.DraftLCDTO;
using LCWeb.Shared.Enums;
using LCWeb.Shared.Models.DraftLC;
using LCWeb.Shared.Response;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                S1Date = request.S1Date,
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
                S4Currency = request.S4Currency,
                S4Figures = request.S4Figures,
                S4ForexRate = request.S4ForexRate,

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

        public async Task<int> UpdateDraftLC(CreateDraftLCSectionDTO request, int LCId)
        {
            DraftLCSection? query = await _context.DraftLCSections
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.S1Date = request.S1Date;
            query.S1Confirmation = request.S1Confirmation;
            query.S1PONo = request.S1PONo;
            query.S1LCType = request.S1LCType;
            query.S1Enclosure = request.S1Enclosure;

            query.S2DateOfExpiry = request.S2DateOfExpiry;
            query.S2IssuingBank = request.S2IssuingBank;
            query.S2PlaceOfExpiry = request.S2PlaceOfExpiry;
            query.S2Remarks = request.S2Remarks;

            query.S3AdvisingBank = request.S3AdvisingBank;
            query.S3CreditAvailBy = request.S3CreditAvailBy;
            query.S3CreditAvailWith = request.S3CreditAvailWith;
            query.S3DifferredRemarks = request.S3DifferredRemarks;
            query.S3DraftAt = request.S3DraftAt;
            query.S3SwiftCode = request.S3SwiftCode;

            query.S4Figures = request.S4Figures;
            query.S4BeneficiaryName = request.S4BeneficiaryName;
            query.S4Currency = request.S4Currency;
            query.S4ForexRate = request.S4ForexRate;
            query.S4ItemDescription = request.S4ItemDescription;
            query.S4LCAmount = request.S4LCAmount;

            query.S5TTReimbursement = request.S5TTReimbursement;

            query.S6MannerOfShipment = request.S6MannerOfShipment;
            query.S6ShipmentTerms = request.S6ShipmentTerms;

            query.S7BeneficiaryName = request.S7BeneficiaryName;
            query.S7ItemDescription = request.S7ItemDescription;
            query.S7LatestShipDate = request.S7LatestShipDate;
            query.S7ShipmentTo = request.S7ShipmentTo;
            query.S7ShipmentFrom = request.S7ShipmentFrom;
            query.S7LCAmount = request.S7LCAmount;
            query.S7Remarks = request.S7Remarks;

            query.S8PartialShipment = request.S8PartialShipment;
            query.S8Transhipment = request.S8Transhipment;

            query.S9ReqDocuments = request.S9ReqDocuments;

            query.S10BankCharges = request.S10BankCharges;

            query.S11TermsAndCond = request.S11TermsAndCond;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        public async Task<PaginatedTableResponse<GetLCReleasingDTO>> GetDraftLCSections(GetPaginatedDTO request)
        {
            IQueryable<DraftLCSection> query = _context.DraftLCSections
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.Id.ToString().Contains(request.SearchValue)
                || q.S1PONo.Contains(request.SearchValue));
            }

            if(request.Status != null)
            {
                query = query.Where(q => q.LCStatus == LCStatus.RELEASED || q.LCStatus == LCStatus.LC_RELEASED);
            }
            else
            {
                query = query.Where(q => q.LCStatus == LCStatus.NONE);
            }

            int totalCount = await query.CountAsync();

            List<DraftLCSection> paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            List<GetLCReleasingDTO> result = paginatedResult.Select(lc => new GetLCReleasingDTO
            {
                Id = lc.Id,
                S1PONo = lc.S1PONo,
                LCStatus = lc.LCStatus,
            }).ToList();

            return new PaginatedTableResponse<GetLCReleasingDTO>
            {
                ResponseData = result,
                Count = totalCount,
            };
        }

        private GetLCReleasingDTO ConvertLCReleasingDTO(DraftLCSection request)
        {
            return new GetLCReleasingDTO
            {
                S1Date = request.S1Date,
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

                S4Figures = request.S4Figures,
                S4BeneficiaryName = request.S4BeneficiaryName,
                S4Currency = request.S4Currency,
                S4ForexRate = request.S4ForexRate,
                S4ItemDescription = request.S4ItemDescription,
                S4LCAmount = request.S4LCAmount,
                S5TTReimbursement = request.S5TTReimbursement,

                S6MannerOfShipment = request.S6MannerOfShipment,
                S6ShipmentTerms = request.S6ShipmentTerms,

                S7BeneficiaryName = request.S7BeneficiaryName,
                S7ItemDescription = request.S7ItemDescription,
                S7LatestShipDate = request.S7LatestShipDate,
                S7ShipmentTo = request.S7ShipmentTo,
                S7ShipmentFrom = request.S7ShipmentFrom,
                S7LCAmount = request.S7LCAmount,
                S7Remarks = request.S7Remarks,

                S8PartialShipment = request.S8PartialShipment,
                S8Transhipment = request.S8Transhipment,
                S9ReqDocuments = request.S9ReqDocuments,
                S10BankCharges = request.S10BankCharges,

                S11TermsAndCond = request.S11TermsAndCond
            };
        }

        public async Task<GetLCReleasingDTO?> GetSingleLCDraftSection(int LCId)
        {
            DraftLCSection? query = await _context.DraftLCSections
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return null;

            return ConvertLCReleasingDTO(query);
        }

        public async Task<int> ReleaseDraftLC(int LCId)
        {
            DraftLCSection? query = await _context.DraftLCSections
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.LCStatus = LCStatus.RELEASED;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        public async Task<int> ReopenDraftLC(int LCId)
        {
            DraftLCSection? query = await _context.DraftLCSections
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.LCStatus = LCStatus.NONE;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

    }
}
