using Microsoft.EntityFrameworkCore;
using Teledoc_WebAPI.Tables;

namespace Teledoc_WebAPI
{
    public class TeledocDBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public TeledocDBContext(DbContextOptions<TeledocDBContext> options) : base(options)
        {
            
        }
    }
}
