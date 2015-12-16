using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using ApiModels.Lots;
using DomainModels.Categories;
using DomainModels.Lots;
using DomainModels.Status;
using Infrastructure.AuctionDb;
using Infrastructure.Repository;

namespace GlobalWebAuction.Controllers.LotControllers
{
	[Authorize]
	[RoutePrefix("api/Lot")]
	public class LotController: ApiController
	{
		[HttpPost]
		[Route("AddNewLot")]
		public IHttpActionResult AddNewLot(AddLotApiModel lotModel)
		{
			CategoryModel categoriesList;
			StatusModel statusModel;

			using (BaseModelRepository<CategoryModel> categoryRepository = 
				new BaseModelRepository<CategoryModel>(new AuctionDb()))
			{
				categoriesList = categoryRepository.GetAll()
					.Select(elem => elem).FirstOrDefault(
						sub => sub.CategoryName == lotModel.Category
						       &&
						       sub.SubCategoryId.Any(elem => elem.SubCategoryName == lotModel.SubCategory));
			}

			using (BaseModelRepository<StatusModel> statusRepository = 
				new BaseModelRepository<StatusModel>(new AuctionDb()))
			{
				statusModel =
					statusRepository.GetAll().Select(status => status).FirstOrDefault(elem => elem.Status == lotModel.Status);

				if (statusModel == null)
				{
					return NotFound();
				}
			}

			try
			{
				using (BaseModelRepository<LotModel> lotModelRepository = 
					new BaseModelRepository<LotModel>(new AuctionDb()))
				{
					var claimsIdentity = User.Identity as ClaimsIdentity;
					if (claimsIdentity == null) return Unauthorized();

					var claims = claimsIdentity.Claims.Select(claim => claim).FirstOrDefault(subj => subj.Type == "userIdString");
					if (claims == null) return Unauthorized();

					var user = lotModelRepository.GetAll()
						.Select(elem => elem.ApplicationUsersId.FirstOrDefault(filter => filter.Id == claims.Value)).ToList()
						.Select(element => element).Where(applicationUser => applicationUser != null).ToList();


					LotModel model = new LotModel()
					{
						Id = Guid.NewGuid(),
						ApplicationUsersId = user,
						LotDetailsId = new LotDetailsModel(),
						Name = lotModel.Name,
						StatusId = statusModel.Id
					};

					lotModelRepository.Add(model);
				}
				return Ok();
			}
			catch (Exception exception)
			{
				return Unauthorized();
			}

			return BadRequest();
		}

		
	}
}