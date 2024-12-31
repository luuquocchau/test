using HRM.Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Identity.EntityConfigurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.Location)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.Description)
            .HasMaxLength(256);

        builder.HasOne(o => o.Parent)
            .WithMany(o => o.Children)
            .HasForeignKey(o => o.ParentId);
    }
}
