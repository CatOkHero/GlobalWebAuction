using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Guarantee;

namespace Infrastructure.Configurations.Guarantee
{
	public class GuaranteeConfiguration : EntityTypeConfiguration<GuaranteeModel>
	{
		public GuaranteeConfiguration()
		{
			HasKey(key => key.Id);

			HasMany(t => t.LotDetailsId)
				.WithOptional(l => l.GuaranteeId);
		}
	}
}
