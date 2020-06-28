using Management.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DataAccess.Concrete.EfCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Detail).HasColumnType("ntext");
            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Work).WithMany(x => x.Reports).HasForeignKey(x => x.WorkId);
        }
    }
}
