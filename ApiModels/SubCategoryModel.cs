using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class SubCategoryModel
    {
        public Guid Id { get; set; }
        public String SubCategoryName { get; set; }
        public List<CategoryModel> CategoriesId { get; set; } 
    }
}
