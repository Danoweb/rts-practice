namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        CarrierID = c.Int(nullable: false, identity: true),
                        MCNumber = c.String(),
                        DOTNumber = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        StateID = c.Int(nullable: false),
                        Zip = c.String(),
                        Email = c.String(),
                        WebURL = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.String(),
                        LastModified = c.String(),
                    })
                .PrimaryKey(t => t.CarrierID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        StateAbbrev = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.States");
            DropTable("dbo.Carriers");
        }
    }
}
