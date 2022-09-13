using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class CarsMap : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.SubImage1).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.SubImage2).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.SubImage3).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.GearType).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Avaliable).HasDefaultValue(true);
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.RentPriceFirst).HasColumnType("money");
            builder.Property(x => x.RentPriceSecond).HasColumnType("money");
            builder.Property(x => x.RentPriceThird).HasColumnType("money");

            builder.HasOne(x => x.Categories).WithMany(x => x.Cars).HasForeignKey(x => x.CategoriesID);
            builder.HasMany(x => x.Rents).WithOne(x => x.Car).HasForeignKey(x => x.CarID);
            builder.ToTable("Cars");
        }
    }
}
