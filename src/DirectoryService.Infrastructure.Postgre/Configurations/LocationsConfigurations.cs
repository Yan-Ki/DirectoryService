using DirectoryService.Domain;
using DirectoryService.Domain.Constants;
using DirectoryService.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DirectoryService.Infrastructure.Postgre.Configurations;

public class LocationsConfigurations :IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");
        
        builder.HasKey(x => x.Id).HasName("pk_locations");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
         
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasConversion(
                x => x.Value,
                s => LocationName.Create(s).Value)
            .HasMaxLength(LengthConstants.Length120)
            .IsRequired();
        
        builder.Property(x => x.Adress).HasColumnName("adress").IsRequired();
        builder.Property(x => x.TimeZone).HasColumnName("time_zone").IsRequired();
        builder.Property(x => x.CreateAt).HasColumnName("create_at").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
        builder.Property(x => x.UpdateAt).HasColumnName("update_at").IsRequired();
    }
}