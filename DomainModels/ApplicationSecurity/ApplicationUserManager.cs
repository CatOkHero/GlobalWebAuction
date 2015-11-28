using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DomainModels.ApplicationSecurity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager CreareUserManager(IdentityFactoryOptions<ApplicationUserManager> applicationOptions, IOwinContext owinContext)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(owinContext.Get<Infrastructure.AuctionDb.AuctionDb>()));
            // Configure validation logic for user names
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true
            };

            //manager.EmailService = new EmailService();
            //var dataProtectionProvider = applicationOptions.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
            //    {
            //        TokenLifespan = TimeSpan.FromHours(6)
            //    };
            //}

            return manager;
        }
    }
}