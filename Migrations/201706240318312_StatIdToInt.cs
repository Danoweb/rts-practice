namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carriers", "States_StateID", "dbo.States");
            DropIndex("dbo.Carriers", new[] { "States_StateID" });
            RenameColumn(table: "dbo.Carriers", name: "States_StateID", newName: "StateID");
            AlterColumn("dbo.Carriers", "StateID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carriers", "StateID");
            AddForeignKey("dbo.Carriers", "StateID", "dbo.States", "StateID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carriers", "StateID", "dbo.States");
            DropIndex("dbo.Carriers", new[] { "StateID" });
            AlterColumn("dbo.Carriers", "StateID", c => c.Int());
            RenameColumn(table: "dbo.Carriers", name: "StateID", newName: "States_StateID");
            CreateIndex("dbo.Carriers", "States_StateID");
            AddForeignKey("dbo.Carriers", "States_StateID", "dbo.States", "StateID");
        }
    }
}
