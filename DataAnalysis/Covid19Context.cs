using DataAnalysis.Models;
using System.Data.Entity;

namespace DataAnalysis
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("Server=DESKTOP-B7NB7CM;Database=data_analysis;Trusted_Connection=True;")
        { }

        public DbSet<Covid19DailyReport> Covid19DailyReports { get; set; }

        public DbSet<Covid19DailyReportUS> Covid19DailyUSReports { get; set; }
    }
}
