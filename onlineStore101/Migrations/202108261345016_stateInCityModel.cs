namespace onlineStore101.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stateInCityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.City", "StateID", c => c.Int(nullable: false));
            CreateIndex("dbo.City", "StateID");
            AddForeignKey("dbo.City", "StateID", "dbo.State", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "StateID", "dbo.State");
            DropIndex("dbo.City", new[] { "StateID" });
            DropColumn("dbo.City", "StateID");
        }
    }
}
