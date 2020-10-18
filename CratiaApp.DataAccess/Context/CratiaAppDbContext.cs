using CratiaApp.DataAccess.Entities;
using System.Data.Entity;

namespace CratiaApp.DataAccess.Context
{
    public class CratiaAppDbContext : DbContext
    {
        public CratiaAppDbContext() : base("name=CratiaAppDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
                
        public DbSet<Battle> Battles { get; set; }
    }
}
