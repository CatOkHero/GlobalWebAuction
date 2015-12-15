using System;
using System.Linq;
using System.Web.Http;
using DomainModels.Lots;
using Infrastructure.AuctionDb;
using Infrastructure.Repository;

namespace GlobalWebAuction.Controllers.LotControllers
{
	[Authorize]
	[RoutePrefix("api/DeleteLot")]
	public class DeleteLotController : ApiController
	{
		[HttpDelete]
		[Route("Delete")]
		public IHttpActionResult Delete(Guid lotDetailsId)
		{
			var deleted = false;
			try
			{
				using (BaseModelRepository<LotModel> lotRepository =
					new BaseModelRepository<LotModel>(new AuctionDb()))
				{
					var lots =
						lotRepository.GetAll()
							.Select(lot => lot.LotDetailsId.Where(lotDetails => lotDetails.Id.ToString() == lotDetailsId.ToString())).ToList();

					var concreteLot = lots.First(filter => filter.Count() != 0).Select(el => el.LotId).ToList().FirstOrDefault();

					if (lotRepository.Delete(concreteLot.ToList()))
					{
						deleted = true;
					}
				}

				if (deleted)
				{
					using (BaseModelRepository<LotDetailsModel> lotDetailsRepository = new BaseModelRepository<LotDetailsModel>(new AuctionDb()))
					{
						var lotDetToDelete = lotDetailsRepository.GetAll().Where(lot => lot.Id == lotDetailsId);

						if (lotDetailsRepository.Delete(lotDetToDelete))
						{
							deleted = true;
						}
					}

					return Ok();
				}
			}
			catch (Exception exception)
			{
				return BadRequest(exception.Message);
			}

			return BadRequest();
		}
	}
}