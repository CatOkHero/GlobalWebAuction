using System.Data.Entity.ModelConfiguration;
using DomainModels.Lots;

namespace Infrastructure.Configurations.Lots
{
    public class LotsConfigurations: EntityTypeConfiguration<LotModel>
    {
        public LotsConfigurations()
        {
            //Primary key
            HasKey(key => key.Id);

            //Table & columns mapping
            //One to one/many
			//HasMany(l => l.LotDetailsId)
			//	.WithMany(ld => ld.LotId);
			//HasRequired(l => l.StatusId)
			//	.WithMany(s => s.LotId);
	        HasRequired(t => t.LotDetailsId)
		        .WithRequiredDependent(l => l.LotId)
				.Map(m => m.MapKey("LotDetailsId"));

	        HasOptional(t => t.LotTypePriceId)
		        .WithMany(p => p.LotId)
				.Map(m => m.MapKey("LotTypePriceId"));
	        HasOptional(t => t.ShippingId)
		        .WithMany(s => s.LotId)
				.Map(m => m.MapKey("ShippingId"));


            //Many to one/many
            HasMany(l => l.BetId)
                .WithRequired(b => b.LotId);
            HasMany(l => l.PhotoId)
                .WithOptional(ph => ph.LotId);
			//HasMany(l => l.LotTypePriceId)
			//	.WithMany(ltp => ltp.LotId);
			//HasMany(l => l.ShippingId)
			//	.WithMany(s => s.LotId);
            HasMany(l => l.ApplicationUsersId)
                .WithMany(apU => apU.LotlId);
        }
    }
}
