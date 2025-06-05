using LCWeb.Shared.Models.DraftLC;
using LCWeb.Shared.Models.LC;
using LCWeb.Shared.Models.Maintenance;
using Microsoft.EntityFrameworkCore;

namespace LCWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //DRAFT LC
        public DbSet<DraftLCSection> DraftLCSections => Set<DraftLCSection>();
        public DbSet<VendorMaintenance> VendorMaintenances => Set<VendorMaintenance>();
        public DbSet<AmendmentReport> AmendmentReports => Set<AmendmentReport>();
        public DbSet<MonitoringReport> MonitoringReports => Set<MonitoringReport>();

        //LC
        public DbSet<LetterOfCredit> LetterOfCredits => Set<LetterOfCredit>();
    }
}
