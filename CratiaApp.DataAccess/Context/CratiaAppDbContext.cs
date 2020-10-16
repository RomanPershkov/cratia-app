using CratiaApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CratiaApp.DataAccess.Context
{
    public class CratiaAppDbContext : DbContext
    {
        public CratiaAppDbContext() : base("name=CratiaAppDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Boxer> Users { get; set; }
        public DbSet<Battle> Battles { get; set; }
    }
}
