namespace onlineStore101.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countryInCurrencyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Currency", "CountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Currency", "CountryID");
            AddForeignKey("dbo.Currency", "CountryID", "dbo.Country", "ID", cascadeDelete: false);
            DropColumn("dbo.Currency", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Currency", "Country", c => c.String());
            DropForeignKey("dbo.Currency", "CountryID", "dbo.Country");
            DropIndex("dbo.Currency", new[] { "CountryID" });
            DropColumn("dbo.Currency", "CountryID");
        }
    }
}
