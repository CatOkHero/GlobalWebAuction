using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations.Bets
{
    public class BetsConfigurations: EntityTypeConfiguration<DomainModels.Bets.BetModel>
    {
        public BetsConfigurations()
        {
            //Primary key
            HasKey(key => key.Id);

            //Table & Columns mapping 
            //HasRequired(b => b.LotId)
            //    .WithRequiredDependent(l =)
        }
    }
}
