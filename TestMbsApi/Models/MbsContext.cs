using Microsoft.EntityFrameworkCore;

namespace TestMbsApi.Models
{
    public class MbsContext : DbContext
    {
        public MbsContext(DbContextOptions<MbsContext> options)
            : base(options)
        {
        }

        public DbSet<MbsItem> MbsItems { get; set; }
    }
}
