﻿using System.Data.Entity;
using DomainModels.Abstraction;
using DomainModels.Bets;
using DomainModels.Categories;
using DomainModels.Guarantee;
using DomainModels.Lots;
using DomainModels.Photo;
using DomainModels.Shipping;
using DomainModels.Status;
using Infrastructure.Configurations.Bets;
using Infrastructure.Configurations.Categories;
using Infrastructure.Configurations.Lots;
using Infrastructure.Configurations.Photo;
using Infrastructure.Configurations.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using DomainModels.ApplicationSecurity;
using Infrastructure.Configurations.Guarantee;
using Infrastructure.Configurations.Shipping;
using Infrastructure.Configurations.Status;

namespace Infrastructure.AuctionDb
{
    public class AuctionDb : IdentityDbContext<ApplicationUser>
    {
        public AuctionDb() : base("name=WebAuctionDataBase4") { }

        public static AuctionDb Create()
        {
            return new AuctionDb();
        }

        public DbSet<StatusModel> StatusModels { get; set; }
        public DbSet<ShippingModel> ShippingModels { get; set; }
        public DbSet<PhotoModel> PhotoModels { get; set; }
        public DbSet<LotModel> LotModels { get; set; }
        public DbSet<LotDetailsModel> LotDetailsModels { get; set; }
        public DbSet<LotTypePriceModel> LotTyPmModels { get; set; }
        public DbSet<GuaranteeModel> GuaranteeModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<SubCategoryModel> SubCategoryModels { get; set; }
        public DbSet<BetModel> BetModels { get; set; }
        //public DbSet<IBaseModel> BaseModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BetsConfigurations());
            modelBuilder.Configurations.Add(new CategoriesConfigurations());
            modelBuilder.Configurations.Add(new LotsConfigurations());
            modelBuilder.Configurations.Add(new LotsDetailsConfigurations());
            modelBuilder.Configurations.Add(new PhotoConfigurations());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
	        modelBuilder.Configurations.Add(new ShippingConfiguration());
			modelBuilder.Configurations.Add(new StatusConfiguration());
			modelBuilder.Configurations.Add(new GuaranteeConfiguration());

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
