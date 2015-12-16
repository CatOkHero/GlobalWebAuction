using System.Data.Entity.ModelConfiguration;
using DomainModels.Shipping;

namespace Infrastructure.Configurations.Shipping
{
	public class ShippingConfiguration : EntityTypeConfiguration<ShippingModel>
	{
		public ShippingConfiguration()
		{
			HasKey(key => key.Id);

			HasMany(t => t.LotId)
				.WithOptional(l => l.ShippingId);
		}
	}
}
