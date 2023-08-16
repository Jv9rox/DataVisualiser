using DataVisualiser.Models;
using Microsoft.EntityFrameworkCore;

namespace DataVisualiser.Data
{
    public class DataVisualiserDbContext:DbContext
    {
        public DataVisualiserDbContext(DbContextOptions<DataVisualiserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<DashboardConfiguration> DashboardConfigurations { get; set; }
    }
}
