using DataAccess.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RentContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Customers> Customers {get;set;}
        public DbSet<Rents>Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=OZATA-LT-188\SQLEXPRESS;Database=RentACar;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomersMap());
            modelBuilder.ApplyConfiguration(new RentsMap());
            modelBuilder.ApplyConfiguration(new CarsMap());
        }
    }
}
