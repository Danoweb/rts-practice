namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatesFKSetup : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Carriers", "StateID");
            AddForeignKey("dbo.Carriers", "StateID", "dbo.States", "StateID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carriers", "StateID", "dbo.States");
            DropIndex("dbo.Carriers", new[] { "StateID" });
        }
    }
}
