using DirectoryService.Domain;
using DirectoryService.Domain.Constants;
using DirectoryService.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DirectoryService.Infrastructure.Postgre.Configurations;

public class PositionsConfigurations :IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");
        
        builder.HasKey(x => x.Id).HasName("pk_positions");
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();
         
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasConversion(
                x => x.Value,
                s => PositionName.Create(s).Value)
            .HasMaxLength(LenghtConstants.Length100)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasConversion(
                x => x.Value,
                s => Description.Create(s).Value)
            .HasMaxLength(LenghtConstants.Length10000)
            .IsRequired();
       
        builder.Property(x => x.CreateAt).HasColumnName("create_at").IsRequired();
        builder.Property(x => x.CreateAt).HasColumnName("is_active").IsRequired();
        builder.Property(x => x.CreateAt).HasColumnName("update_at").IsRequired();
    }
}