using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Configurations.Categories
{
    public class CategoriesConfigurations : EntityTypeConfiguration<DomainModels.Categories.CategoryModel>
    {
        public CategoriesConfigurations()
        {
            //Primary key
            HasKey(key => key.Id);

            //Tables & columns relationship
            //Many to many
            HasMany(ctg => ctg.SubCategoryId)
                .WithMany(sctg => sctg.CategoriesId);
        }
    }
}
