using System;
using System.Collections.Generic;
using ApiModels.Lots;

namespace ApiModels.Categories
{
    public class CategoryApiModel
    {
        public String CategoryName { get; set; }
        public List<SubCategoryApiModel> SubCategoryModels { get; set; }
		public LotDetailsApiModel LotDetailsApiModelsApiModels { get; set; }
    } 
}
