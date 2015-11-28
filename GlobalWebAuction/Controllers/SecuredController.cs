using System.Web.Http;

namespace GlobalWebAuction.Controllers
{
    [RoutePrefix("api/Secured")]
    public class SecuredController: ApiController
    {
        [HttpGet]
        [Authorize]
        public IHttpActionResult ReturName()
        {
            return Ok("name was returned");
        }
    }
}