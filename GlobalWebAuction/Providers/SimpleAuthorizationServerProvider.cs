using System.Security.Claims;
using System.Threading.Tasks;
using Infrastructure.Repository;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;

namespace GlobalWebAuction.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
			string userId;
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AuctionDbRepository repo = new AuctionDbRepository())
            {
                IdentityUser user = await repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

				userId = user.Id;
            }

			//Use this in test propose
			//using (UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuctionDb())))
			//{
			//	var ident = manager.Find(context.UserName, context.Password);
			//	var userIdentity = await manager.CreateIdentityAsync(ident, "Bearer");
			//	context.Validated(userIdentity);
			//}

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
			identity.AddClaim(new Claim("userIdString", userId));
			identity.AddClaim(new Claim("sub", context.UserName));
			identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}