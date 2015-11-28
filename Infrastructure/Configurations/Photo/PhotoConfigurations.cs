using System.Data.Entity.ModelConfiguration;
using DomainModels.Photo;

namespace Infrastructure.Configurations.Photo
{
    public class PhotoConfigurations: EntityTypeConfiguration<PhotoModel>
    {
        public PhotoConfigurations()
        {
            //Primary key
            HasKey(key => key.Id);

            //Tables & columns relationship
            HasOptional(ph => ph.UserId)
                .WithMany(u => u.PhotoId);

            HasOptional(ph => ph.LotId)
                .WithMany(l => l.PhotoId);
        }
    }
}
