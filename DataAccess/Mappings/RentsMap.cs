using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class RentsMap : IEntityTypeConfiguration<Rents>
    {
        public void Configure(EntityTypeBuilder<Rents> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.RentDate).HasColumnType("datetime");
            builder.Property(x => x.DeliveryDate).HasColumnType("datetime");
            builder.HasOne(x => x.Car).WithMany(x => x.Rents).HasForeignKey(x => x.CarID);
            builder.HasOne(x => x.Customers).WithMany(x => x.Rents).HasForeignKey(x => x.CustomerID);
        }
    }
}
