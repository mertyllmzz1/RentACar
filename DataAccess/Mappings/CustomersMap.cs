using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class CustomersMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.NameSurname).HasMaxLength(25);
            builder.Property(x => x.BirthDate).HasColumnType("datetime");
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Password).HasMaxLength(30);
            builder.HasMany(x => x.Rents).WithOne(x => x.Customers).HasForeignKey(x => x.CustomerID);

        }
    }
}
