using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ApiModels.Categories;
using ApiModels.Lots;
using DomainModels.Lots;
using Infrastructure.AuctionDb;
using Infrastructure.Repository;
using Categories = DomainModels.Categories.CategoryModel;

namespace GlobalWebAuction.Controllers.CategoryController
{
    [AllowAnonymous]
    [RoutePrefix("api/Categories")]
    public class CategoriesController: ApiController
    {
        [Route("GetCategories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            List<CategoryApiModel> categoryModels = new List<CategoryApiModel>();
            
            try
            {
				using (BaseModelRepository<Categories> repository = 
					new BaseModelRepository<Categories>(new AuctionDb()))
                {
                    var categoriesModels = repository.GetAll().ToList();

					categoriesModels.ForEach(elem => categoryModels.Add(new CategoryApiModel()
                    {
                        CategoryName = elem.CategoryName,
						SubCategoryModels = elem.SubCategoryId.Select(sub => new SubCategoryApiModel()
								{
									SubCategoryName = sub.SubCategoryName
								}).ToList()
					}));
				}
            }
            catch (Exception exception)
            {
				return NotFound();
            }

	        return await Task.FromResult(Ok(categoryModels));
        }


		[HttpPost]
		[AllowAnonymous]
	    [Route("GetSelectedCategory")]
	    public async Task<IHttpActionResult> GetSelectedCategory(GetSelectedCategoryModel model)
	    {
			try
			{
				var resultOfSearch = GetLotByCategory(model);
				if (resultOfSearch.Count == 0)
					return await Task.FromResult(BadRequest("There are no products in this category!"));

				return await Task.FromResult(Ok(resultOfSearch));
			}
			catch (Exception exception)
			{
				return NotFound();
			}
	    }

		private List<CategoryApiModel> GetLotByCategory(GetSelectedCategoryModel model)
	    {
			List<Categories> categoriesList;

			using (BaseModelRepository<Categories> categoryRepository =
				new BaseModelRepository<Categories>(new AuctionDb()))
			{
				categoriesList = categoryRepository.GetAll().Where(filter => filter.CategoryName == model.CategoryName).ToList();


				using (
					BaseModelRepository<LotDetailsModel> lotDetailsRepository =
						new BaseModelRepository<LotDetailsModel>(new AuctionDb()))
				{
					var lots = lotDetailsRepository.GetAll().ToList();
					var models = new List<CategoryApiModel>();

					foreach (var lotDetailsModel in lots)
					{
						foreach (var category in categoriesList)
						{
							//var lotDetailsModel = lot;
							//var categoryModel = category;
							//models.AddRange(from subCategory in category.SubCategoryId
							//	where subCategory.SubCategoryName == model.SubCategoryName
							//	select lot.LotId.Select(lotModel => lotModel).Where(subLotFilter => subLotFilter.Id == lot.Id).ToList()
							//	into subQuery
							//	select subQuery.ToList().Select(subLot => new LotApiModel()
							//	{
							//		Name = subLot.Name
							//	}).ToList()
							//	into lotsApi
							//	select new LotDetailsApiModel()
							//	{
							//		Address = lotDetailsModel.Adress,
							//		Description = lotDetailsModel.Description,
							//		Price = lotDetailsModel.Price,
							//		Lots = lotsApi
							//	}
							//	into lotDeatailsApi
							//	select new CategoryApiModel()
							//	{
							//		CategoryName = categoryModel.CategoryName,
							//		LotDetailsApiModelsApiModels = lotDeatailsApi
							//	});

							if (category.Id == lotDetailsModel.CategoryId.Id)
							{
								models.Add(new CategoryApiModel()
								{
									CategoryName = category.CategoryName,
									LotDetailsApiModelsApiModels = new LotDetailsApiModel()
									{
										Id = lotDetailsModel.Id,
										Address = lotDetailsModel.Adress,
										Description = lotDetailsModel.Description,
										Price = lotDetailsModel.Price,
										//Lots = new List<LotApiModel>()
										//{
										//	new LotApiModel()
										//	{
										//		Name = lot.LotId.FirstOrDefault(elem => elem.LotDetailsId == lot).Name
										//	}
										//}
									}
								});
							}
						}
					}

					return models;
				}
			}
	    }
    }
}



//using (BaseModelRepository<Categories> repository = new BaseModelRepository<Categories>(connection))
//{
//	var categories = repository.GetAll()
//		.Select(entity => entity)
//		.Where(filter => filter.CategoryName == model.CategoryName).ToList();

//	//categories.Select(elem => elem)
//	//		  .Where(filter => filter.SubCategoryId[);





//	//foreach (var category in categories)
//	//{
//	//	var categoryApi = new CategoryApiModel {CategoryName = category.CategoryName};
//	//	var lotDetail = category.LotDetailsId.ToList();
//	//	var lotsDetailsApi = new List<LotDetailsApiModel>();
//	//	var lotsApi = new List<LotApiModel>();

//	//	foreach (var lotDet in lotDetail)
//	//	{
//	//		var lots = lotDet.LotId;

//	//		lotsApi.AddRange(lots.Select(lot => new LotApiModel()
//	//		{
//	//			Name = lot.Name
//	//		}));

//	//		lotsDetailsApi.Add(new LotDetailsApiModel()
//	//		{
//	//			Adress = lotDet.Adress,
//	//			Description = lotDet.Description,
//	//			Price = lotDet.Price,
//	//			Quantity = lotDet.Quantity,
//	//			Lots = lotsApi
//	//		});

//	//		categoryApi.LotDetailsApiModelsApiModels = lotsDetailsApi;

//	//		models.Add(categoryApi);
//	//	}

//	//	return models;
//	//}

//	return null;
//}