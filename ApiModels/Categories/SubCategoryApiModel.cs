using System;
using System.Collections.Generic;

namespace ApiModels.Categories
{
    public class SubCategoryApiModel
    {
        public String SubCategoryName { get; set; }
        public List<CategoryApiModel> CategoriesId { get; set; } 
    }
}
