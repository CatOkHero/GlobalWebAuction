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
            HasMany(l => l.LotDetailsId)
                .WithMany(ld => ld.LotId);
            HasRequired(l => l.StatusId)
                .WithMany(s => s.LotId);

            //Many to one/many
            HasMany(l => l.BetId)
                .WithRequired(b => b.LotId);
            HasMany(l => l.PhotoId)
                .WithOptional(ph => ph.LotId);
            HasMany(l => l.LotTypePriceId)
                .WithMany(ltp => ltp.LotId);
            HasMany(l => l.ShippingId)
                .WithMany(s => s.LotId);
            HasMany(l => l.ApplicationUsersId)
                .WithMany(apU => apU.LotlId);
        }
    }
}
