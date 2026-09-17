using DirectoryService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgre.Configurations;

public class DepartmentPositionsConfiguration :IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        builder.ToTable("department_positions");
        
        builder.HasKey(x => x.Id).HasName("pk_department_positions");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
        
        builder.HasOne(x => x.Department)
            .WithMany(x => x.DepartmentPositions)
            .HasForeignKey(x => x.DepartmentId)
            .HasConstraintName("fk_department_positions_department_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Position)
            .WithMany(x => x.DepartmentPositions)
            .HasForeignKey(x => x.PositionId)
            .HasConstraintName("fk_department_positions_position_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}