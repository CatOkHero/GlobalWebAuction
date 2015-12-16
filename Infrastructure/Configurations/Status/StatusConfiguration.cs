using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Status;

namespace Infrastructure.Configurations.Status
{
	public class StatusConfiguration : EntityTypeConfiguration<StatusModel>
	{
		public StatusConfiguration()
		{
			HasKey(key => key.Id);

			ToTable("Status");
            Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Status).HasColumnName("Status");
			//Property(t => t.LotId).HasColumnName("LotId");

			//HasMany(t => t.LotId).WithOptional(lot => lot.Id);
		}
	}
}
