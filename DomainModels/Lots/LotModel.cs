using System;
using System.Collections.Generic;
using DomainModels.Abstraction;
using DomainModels.ApplicationSecurity;
using DomainModels.Bets;
using DomainModels.Photo;
using DomainModels.Shipping;
using DomainModels.Status;

namespace DomainModels.Lots
{
    public class LotModel : IBaseModel
    {
        public LotModel()
        {
            BetId = new List<BetModel>();
            PhotoId = new List<PhotoModel>();
            ShippingId = new List<ShippingModel>();
            LotDetailsId = new List<LotDetailsModel>();
            LotTypePriceId = new List<LotTypePriceModel>();
            ApplicationUsersId = new List<ApplicationUser>();
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public virtual Guid StatusId { get; set; }
        public virtual ICollection<BetModel> BetId { get; set; }
        public virtual ICollection<PhotoModel> PhotoId { get; set; }
        public virtual ICollection<ShippingModel> ShippingId { get; set; }
        public virtual ICollection<LotDetailsModel> LotDetailsId { get; set; }
        public virtual ICollection<LotTypePriceModel> LotTypePriceId { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsersId { get; set; }
    }
}
