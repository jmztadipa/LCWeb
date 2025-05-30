using LCWeb.Shared.Models.DraftLC;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //DRAFT LC
        public DbSet<DraftLCSection> DraftLCSections => Set<DraftLCSection>();
    }
}
