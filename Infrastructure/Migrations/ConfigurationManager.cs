namespace Infrastructure.Migrations
{
    public class Configuration: System.Data.Entity.Migrations.DbMigrationsConfiguration<AuctionDb.AuctionDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
