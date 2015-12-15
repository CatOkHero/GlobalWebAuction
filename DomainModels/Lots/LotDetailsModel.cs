using System;
using System.Collections.Generic;
using DomainModels.Abstraction;
using DomainModels.ApplicationSecurity;
using DomainModels.Categories;
using DomainModels.Guarantee;

namespace DomainModels.Lots
{
    public class LotDetailsModel: IBaseModel
    {
        public LotDetailsModel()
        {
            //UserId = new List<ApplicationUser>();
            LotId = new List<LotModel>();
			//CategoryId = new List<CategoryModel>();
        }

        public Guid Id { get; set; }
        public Double Price { get; set; }
        public String Adress { get; set; }
        public String Description { get; set; }
        public Int16 Quantity { get; set; }
        //public virtual ICollection<ApplicationUser> UserId { get; set; }
        public virtual GuaranteeModel GuaranteeId { get; set; }
        public virtual ICollection<LotModel> LotId { get; set; }
		public virtual Guid CategoryId { get; set; }
    }
}
