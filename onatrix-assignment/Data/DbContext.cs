using Microsoft.EntityFrameworkCore;
using onatrix_assignment.Models;

namespace onatrix_assignment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContactFormEntry> ContactFormEntries { get; set; }
        public DbSet<WeHelpModel> WeHelpModels { get; set; }
    }
}
