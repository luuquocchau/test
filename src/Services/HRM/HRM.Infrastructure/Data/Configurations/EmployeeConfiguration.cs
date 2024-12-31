using HRM.Domain.Employees;
using HRM.Domain.Organizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Identity.EntityConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.FullName)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.DateOfBirth)
            .IsRequired();

        builder.Property(o => o.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(o => o.Description)
        .HasMaxLength(256);

        builder.HasOne(p => p.Organization)            
           .WithMany(c => c.Employees)
           .HasForeignKey(p => p.OrganizationId);
    }
}
