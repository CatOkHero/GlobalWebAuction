using System;
using System.Linq;
using System.Web.Http;
using DomainModels.Status;
using Infrastructure.AuctionDb;
using Infrastructure.Repository;

namespace GlobalWebAuction.Controllers.StatusController
{
	[AllowAnonymous]
	[RoutePrefix("api/Status")]
	public class StatusController: ApiController
	{
		[Route("GetStatus")]
		public IHttpActionResult GetStatus()
		{
			try
			{
				using (BaseModelRepository<StatusModel> statusRepository =
					new BaseModelRepository<StatusModel>(new AuctionDb()))
				{
					var result = statusRepository.GetAll().Select(status => status.Status).ToList();
					return Ok(result);
				}
			}
			catch (Exception exception)
			{
				return NotFound();
			}
		}
	}
}