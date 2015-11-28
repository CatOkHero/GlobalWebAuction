using System;
using DomainModels.Abstraction;

namespace DomainModels.User
{
    public class UserModel: IBaseModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String SurName { get; set; }
        public String Password { get; set; }
        public String ConfirmePassword { get; set; }
    }
}
