using System;
using System.Collections.Generic;
using DomainModels.Abstraction;

namespace DomainModels.Categories
{
    public class SubCategoryModel : IBaseModel
    {
        public SubCategoryModel()
        {
            CategoriesId = new List<CategoryModel>();
        }

        public Guid Id { get; set; }
        public String SubCategoryName { get; set; }
        public virtual ICollection<CategoryModel> CategoriesId { get; set; } 
    }
}
