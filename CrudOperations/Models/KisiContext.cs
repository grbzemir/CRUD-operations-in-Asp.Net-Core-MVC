using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Models
{
    public class KisiContext: DbContext
    {
        public KisiContext(DbContextOptions<KisiContext> options) :base(options)
        {
            
        }

        public DbSet<Kisiler> Kisilers { get; set; }
    }
}
