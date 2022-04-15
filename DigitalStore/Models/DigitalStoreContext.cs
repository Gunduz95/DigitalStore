using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalStore.Models
{
    public class DigitalStoreContext : DbContext
    {
        public DigitalStoreContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DBInitializer());
        }

        public DigitalStoreContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Manufacturer> Manufacturers { get; set; }        
    }
}