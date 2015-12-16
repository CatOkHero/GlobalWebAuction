using System.Data.Entity.ModelConfiguration;
using DomainModels.ApplicationSecurity;

namespace Infrastructure.Configurations.Users
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            //Relationship many to one
            HasMany(u => u.BetId)
                .WithRequired(b => b.UserId);
            HasMany(u => u.PhotoId)
                .WithOptional(p => p.UserId);
            HasMany(u => u.LotlId)
                .WithMany(ld => ld.ApplicationUsersId);
        }
    }
}
