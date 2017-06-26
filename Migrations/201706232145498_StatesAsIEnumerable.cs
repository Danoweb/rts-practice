namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatesAsIEnumerable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carriers", "StateID", "dbo.States");
            DropIndex("dbo.Carriers", new[] { "StateID" });
            RenameColumn(table: "dbo.Carriers", name: "StateID", newName: "States_StateID");
            AlterColumn("dbo.Carriers", "States_StateID", c => c.Int());
            CreateIndex("dbo.Carriers", "States_StateID");
            AddForeignKey("dbo.Carriers", "States_StateID", "dbo.States", "StateID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carriers", "States_StateID", "dbo.States");
            DropIndex("dbo.Carriers", new[] { "States_StateID" });
            AlterColumn("dbo.Carriers", "States_StateID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Carriers", name: "States_StateID", newName: "StateID");
            CreateIndex("dbo.Carriers", "StateID");
            AddForeignKey("dbo.Carriers", "StateID", "dbo.States", "StateID", cascadeDelete: true);
        }
    }
}
