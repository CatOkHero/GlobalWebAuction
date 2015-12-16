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
							.Where(lot => lot.LotDetailsId.ToString() == lotDetailsId.ToString()).ToList();

					if (lotRepository.Delete(lots))
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