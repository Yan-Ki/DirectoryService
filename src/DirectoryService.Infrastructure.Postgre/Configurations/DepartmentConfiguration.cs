using DirectoryService.Domain;
using DirectoryService.Domain.Constants;
using DirectoryService.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Postgre.Configurations;

public class DepartmentConfiguration :IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");
        
        builder.HasKey(x => x.Id).HasName("pk_departments");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
         
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasConversion(
                x => x.Value,
                s => Name.Create(s).Value)
            .HasMaxLength(LenghtConstants.Length150)
            .IsRequired();
        
        builder.Property(x => x.Path)
            .HasColumnName("path")
            .HasConversion(
                x => x.Value,
                s => DirectoryService.Domain.ValueObject.Path.Create(s).Value) // Исправить Path
            .HasMaxLength(LenghtConstants.Length150)
            .IsRequired();
        
        builder.Property(x => x.ParentId)
            .HasColumnName("parent_id")
            .IsRequired();
        
        builder.Property(x => x.Identifier)
            .HasColumnName("identifier")
            .HasConversion(
                x => x.Value,
                s => Identifier.Create(s).Value) // Исправить Path
            .HasMaxLength(LenghtConstants.Length150)
            .IsRequired();
        
        builder.Property(x => x.Depth).HasColumnName("depth").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
        builder.Property(x => x.CreateAt).HasColumnName("create_at").IsRequired();
        builder.Property(x => x.UpdateAt).HasColumnName("update_at").IsRequired();
    }
}