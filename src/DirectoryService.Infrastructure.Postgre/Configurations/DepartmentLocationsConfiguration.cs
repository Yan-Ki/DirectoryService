using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgre.Configurations;

public class DepartmentLocationsConfiguration :IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder.ToTable("department_locations");
        
        builder.HasKey(x => x.Id).HasName("pk_department_locations");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.HasOne(x => x.Department)
            .WithMany(x => x.DepartmentLocations)
            .HasForeignKey(x => x.DepartmentId)
            .HasConstraintName("fk_department_locations_department_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Location)
            .WithMany(x => x.DepartmentLocations)
            .HasForeignKey(x => x.LocationId)
            .HasConstraintName("fk_department_locations_location_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}