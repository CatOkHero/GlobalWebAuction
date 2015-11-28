using System;
using System.Collections.Generic;
using DomainModels.Abstraction;
using DomainModels.Lots;

namespace DomainModels.Categories
{
    public class CategoryModel: IBaseModel
    {
        public CategoryModel()
        {
            LotDetailsId = new List<LotDetailsModel>();
            SubCategoryId = new List<SubCategoryModel>();
        }

        public Guid Id { get; set; }
        public String CategoryName { get; set; }
        public virtual ICollection<LotDetailsModel> LotDetailsId { get; set; } 
        public virtual ICollection<SubCategoryModel> SubCategoryId { get; set; } 
    }
}
