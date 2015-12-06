using System;
using System.Collections.Generic;

namespace ApiModels
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public String CategoryName { get; set; }
        public List<SubCategoryModel> SubCategoryModels { get; set; }
    } 
}
