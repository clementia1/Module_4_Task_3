using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_3.Entities;

namespace Module_4_Task_3.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.Property(project => project.Id).HasColumnName("ProjectId");
            builder.Property(project => project.Name).IsRequired().HasMaxLength(50);
            builder.Property(project => project.Budget).IsRequired().HasColumnType("money");
            builder.Property(project => project.StartedDate).IsRequired().HasColumnType("datetime2(7)");

            builder.HasMany(c => c.Employees)
                .WithMany(s => s.Projects)
                .UsingEntity<EmployeeProject>(
                    j => j
                        .HasOne<Employee>()
                        .WithMany()
                        .HasForeignKey("EmployeeId"),
                    j => j
                        .HasOne<Project>()
                        .WithMany()
                        .HasForeignKey("ProjectId"),
                    j =>
                    {
                        j.HasKey(t => t.Id);
                        j.Property(t => t.Id).HasColumnName("EmployeeProjectId");
                        j.ToTable("EmployeeProject");
                    });
        }
    }
}
