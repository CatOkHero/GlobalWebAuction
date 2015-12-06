using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DomainModels.Categories;
using Infrastructure.AuctionDb;
using Infrastructure.Repository;
using ApiModels;
using CategoryModel = ApiModels.CategoryModel;
using SubCategoryModel = ApiModels.SubCategoryModel;

namespace GlobalWebAuction.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Categories")]
    public class CategoriesController: ApiController
    {
        [Route("GetCategories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            List<ApiModels.CategoryModel> categoryModels = new List<CategoryModel>();
            
            try
            {
                using (AuctionDb context = new AuctionDb())
                {
                    BaseModelRepository<DomainModels.Categories.CategoryModel> repository =
                        new BaseModelRepository<DomainModels.Categories.CategoryModel>(context);
                    var categoriesModels = repository.GetAll().ToList();

					//foreach (var category in categoriesModels)
					//{
					//	categoryModels.Add(new CategoryModel()
					//	{
					//		Id = category.Id,
					//		SubCategoryModels = 
					//	});
					//}


					categoriesModels.ForEach(elem => categoryModels.Add(new ApiModels.CategoryModel()
                    {
                        Id = elem.Id,
                        CategoryName = elem.CategoryName,
						SubCategoryModels = elem.SubCategoryId.Select(sub => new SubCategoryModel()
								{
									Id = sub.Id,
									SubCategoryName = sub.SubCategoryName
								}).ToList()
						//SubCategoryModels = new List<SubCategoryModel>()
						//{		
						//	new SubCategoryModel()
						//	{
						//		Id = elem.SubCategoryId.Where(sub => sub.CategoriesId.Contains(elem)).GetEnumerator().Current.Id,

						//		SubCategoryName =
						//			elem.SubCategoryId.Where(sub => sub.CategoriesId.Contains(elem)).GetEnumerator().Current.SubCategoryName
						//	}
						//}
					}));
				}
            }
            catch (Exception exception)
            {
                var ex = exception;
                return NotFound();
            }

        

            return Ok(categoryModels);
        }

		//public List<SubCategoryModel> MapSubCategoryModels(List<DomainModels.Categories.SubCategoryModel> subCategory)
		//{
		//	List<SubCategoryModel> subCategoryModels = subCategory.Select(sub => new SubCategoryModel()
		//	{
		//		Id = sub.Id, SubCategoryName = sub.SubCategoryName
		//	}).ToList();
		//}
    }
}