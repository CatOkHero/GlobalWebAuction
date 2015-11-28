using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DomainModels.Abstraction;
using DomainModels.Bets;
using DomainModels.Lots;
using DomainModels.Photo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DomainModels.ApplicationSecurity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            BetId = new List<BetModel>();
            LotlId = new List<LotModel>();
            PhotoId = new List<PhotoModel>();
        }

        public string Hometown { get; set; }

        public virtual ICollection<BetModel> BetId { get; set; }
        public virtual ICollection<LotModel> LotlId { get; set; }
        public virtual ICollection<PhotoModel> PhotoId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            // Add custom user claims here
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
