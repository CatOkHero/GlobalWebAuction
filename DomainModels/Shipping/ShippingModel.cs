using System;
using System.Collections.Generic;
using DomainModels.Abstraction;
using DomainModels.Lots;

namespace DomainModels.Shipping
{
    public class ShippingModel : IBaseModel
    {
        public ShippingModel()
        {
            LotId = new List<LotModel>();
        }

        public Guid Id { get; set; }
        public String ShippingCompany { get; set; }
        public virtual ICollection<LotModel> LotId { get; set; }
    }
}
