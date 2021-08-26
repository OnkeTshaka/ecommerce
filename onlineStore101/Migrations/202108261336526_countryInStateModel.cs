namespace onlineStore101.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countryInStateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.State", "CountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.State", "CountryID");
            AddForeignKey("dbo.State", "CountryID", "dbo.Country", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.State", "CountryID", "dbo.Country");
            DropIndex("dbo.State", new[] { "CountryID" });
            DropColumn("dbo.State", "CountryID");
        }
    }
}
