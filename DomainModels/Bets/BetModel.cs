using System;
using DomainModels.Abstraction;
using DomainModels.ApplicationSecurity;
using DomainModels.Lots;

namespace DomainModels.Bets
{
    public class BetModel: IBaseModel
    {
        public Guid Id { get; set; }
        public Double Price { get; set; }
        public DateTime DateOfBet { get; set; }
        public virtual LotModel LotId { get; set; }
        public virtual ApplicationUser UserId { get; set; }
    }
}
