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

		//POST api/Account/Login
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser result;
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

            return Ok(result.Id);
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

            IdentityResult result;
            try
            {
                result = await repo.RegisterUser(userModel);
            }
            catch (Exception exception)
            {
				return BadRequest(exception.Message);
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
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}