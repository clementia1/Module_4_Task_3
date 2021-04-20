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
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title");
            builder.Property(title => title.Id).HasColumnName("TitleId");
            builder.Property(title => title.Name).IsRequired().HasMaxLength(50);
        }
    }
}
