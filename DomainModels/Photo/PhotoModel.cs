using System;
using DomainModels.Abstraction;
using DomainModels.ApplicationSecurity;
using DomainModels.Lots;

namespace DomainModels.Photo
{
    public class PhotoModel : IBaseModel
    {
        public Guid Id { get; set; }
        public String Photot { get; set; }
        public LotModel LotId { get; set; }
        public ApplicationUser UserId { get; set; }
    }
}
