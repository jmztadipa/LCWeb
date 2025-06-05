using LCWeb.Data;
using LCWeb.Shared.DTOs.LetterOfCreditsDTO;
using LCWeb.Shared.Enums;
using LCWeb.Shared.Models.LC;
using LCWeb.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Services.LetterOfCreditService
{
    public class LetterOfCreditService : ILetterOfCreditService
    {
        private readonly DataContext _context;

        public LetterOfCreditService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateLC(CreateLetterOfCreditsDTO request)
        {
            var entry = new LetterOfCredit
            {
                DraftLCSectionId = request.DraftLCSectionId,
                ExpiryDate = request.ExpiryDate,
                LatestShipDate = request.LatestShipDate,
                LCNo = request.LCNo,
                LCStatus = LCStatus.OPEN,
                OpeningBank = request.OpeningBank,
                DateOpened = request.DateOpened,
            };
            _context.LetterOfCredits.Add(entry);
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        public async Task<int> UpdateLC(CreateLetterOfCreditsDTO request, int LCId)
        {
            var query = await _context.LetterOfCredits
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.ExpiryDate = request.ExpiryDate;
            query.LatestShipDate = request.LatestShipDate;
            query.LCNo = request.LCNo;
            query.OpeningBank = request.OpeningBank;
            query.DateOpened = request.DateOpened;

            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        private GetLetterOfCreditsDTO ConvertLCToDTO(LetterOfCredit request)
        {
            return new GetLetterOfCreditsDTO
            {
                Id = request.Id,
                DraftLCSectionId = request.DraftLCSectionId,
                ExpiryDate = request.ExpiryDate,
                LatestShipDate = request.LatestShipDate,
                LCNo = request.LCNo,
                PONo = request.DraftLCSection.S1PONo,
                LCStatus = LCStatus.OPEN,
                OpeningBank = request.OpeningBank,
                DateOpened = request.DateOpened,
                ReceivedDate = request.ReceivedDate
            };
        }

        public async Task<PaginatedTableResponse<GetLetterOfCreditsDTO>> GetLetterOfCredits(GetPaginatedDTO request)
        {
            IQueryable<LetterOfCredit> query = _context.LetterOfCredits
                .Include(q => q.DraftLCSection)
                .OrderByDescending(q => q.Id);

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(q => q.Id.ToString().Contains(request.SearchValue)
                || q.LCNo.Contains(request.SearchValue));
            }

            if(request.Status != null)
            {
                query = query.Where(q => q.LCStatus == request.Status);
            }

            int totalCount = await query.CountAsync();

            List<LetterOfCredit> paginatedResult = await query
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            List<GetLetterOfCreditsDTO> result = paginatedResult.Select(lc => ConvertLCToDTO(lc)).ToList();

            return new PaginatedTableResponse<GetLetterOfCreditsDTO>
            {
                ResponseData = result,
                Count = totalCount,
            };
        }

        public async Task<GetLetterOfCreditsDTO?> GetSingleLC(int LCId)
        {
            var query = await _context.LetterOfCredits
                .Include(q => q.DraftLCSection)
                .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return null;

            return ConvertLCToDTO(query);
        }

        public async Task<List<GetDraftLCListDTO>> GetDraftLCList()
        {
            var query = await _context.DraftLCSections
                .Where(q => q.LCStatus == LCStatus.RELEASED)
                .ToListAsync();

            var responseData = query.Select(q => new GetDraftLCListDTO
            {
                Id = q.Id,
                PONo = q.S1PONo,
            }).ToList();
            return responseData;
        }

        public async Task<int> ReleaseLC(int LCId)
        {
            var query = await _context.LetterOfCredits
                 .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.LCStatus = LCStatus.RELEASED;
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }

        public async Task<int> ReceiveLC(int LCId)
        {
            var query = await _context.LetterOfCredits
                 .FirstOrDefaultAsync(q => q.Id == LCId);

            if (query == null) return 0;

            query.ReceivedDate = DateTime.Now;
            return await _context.SaveChangesAsync() == 0 ? 0 : 1;
        }
    }
}
