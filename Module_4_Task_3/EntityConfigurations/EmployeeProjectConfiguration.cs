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
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.Property(employeeProject => employeeProject.Rate).IsRequired().HasColumnType("money");
            builder.Property(employeeProject => employeeProject.StartedDate).IsRequired().HasColumnType("datetime2(7)");
        }
    }
}
