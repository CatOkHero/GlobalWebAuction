using System;
using System.Threading.Tasks;
using DomainModels.ApplicationSecurity;
using DomainModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Repository
{
    public class AuctionDbRepository: IDisposable
    {
        private readonly AuctionDb.AuctionDb auctionDb;
        private readonly ApplicationUserManager applicationUserManager;

        public AuctionDbRepository()
        {
            auctionDb = AuctionDb.AuctionDb.Create();
            applicationUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(auctionDb));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userModel.Name
            };

            return await applicationUserManager.CreateAsync(user, userModel.Password);
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            return await applicationUserManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            auctionDb.Dispose();
            applicationUserManager.Dispose();
        }
    }
}