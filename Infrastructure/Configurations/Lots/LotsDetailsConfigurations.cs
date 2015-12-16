using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations.Lots
{
    public class LotsDetailsConfigurations: EntityTypeConfiguration<DomainModels.Lots.LotDetailsModel>
    {
        public LotsDetailsConfigurations()
        {
            //Primary key
            HasKey(key => key.Id);

	        HasRequired(t => t.LotId)
		        .WithRequiredPrincipal(lot => lot.LotDetailsId);

	        HasOptional(t => t.GuaranteeId)
		        .WithMany(g => g.LotDetailsId)
				.Map(m => m.MapKey("GuaranteeId"));
	        HasOptional(t => t.CategoryId)
		        .WithMany(c => c.LotDetailsId)
				.Map(m => m.MapKey("CategoryId"));
	        //Table & columns relationship
	        //Many to many
	        //HasMany(ld => ld.CategoryId)
	        //	.WithMany(ctg => ctg.LotDetailsId);

	        ////One to many
	        //HasOptional(ld => ld.GuaranteeId)
	        //	.WithMany(g => g.LotDetailsId);

	        ////Required one to many/one
	        ////HasMany(ld => ld.UserId)
	        ////    .WithMany(u => u.LotDetailId);
	        //HasMany(ld => ld.LotId)
	        //	.WithMany(l => l.LotDetailsId);
        }
    }
}
