using System;
using System.Threading.Tasks;
using System.Web.Http;
using DomainModels.ApplicationSecurity;
using DomainModels.User;
using Infrastructure.Repository;
using Microsoft.AspNet.Identity;

namespace GlobalWebAuction.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly AuctionDbRepository repo;

        public AccountController()
        {
            repo = new AuctionDbRepository();
        }

        [AllowAnonymous]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser result = new ApplicationUser();
            try
            {
                using (AuctionDbRepository repository = new AuctionDbRepository())
                {
                    result = await repository.FindUser(userModel.Name, userModel.Password);
                }

	            if (result == null)
	            {
		            return NotFound();
	            }
            }
			catch (Exception exception)
            {
				return NotFound();
            }

            return Ok(result.SecurityStamp);
        }

            // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = new IdentityResult();
            try
            {
                result = await repo.RegisterUser(userModel);
            }
            catch (Exception exception)
            {
                var a = exception;
            }
           

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}