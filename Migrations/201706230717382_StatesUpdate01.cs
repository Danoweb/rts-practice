namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatesUpdate01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carriers", "MCNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Address1", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Address2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Zip", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "WebURL", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carriers", "WebURL", c => c.String());
            AlterColumn("dbo.Carriers", "Email", c => c.String());
            AlterColumn("dbo.Carriers", "Zip", c => c.String());
            AlterColumn("dbo.Carriers", "City", c => c.String());
            AlterColumn("dbo.Carriers", "Address2", c => c.String());
            AlterColumn("dbo.Carriers", "Address1", c => c.String());
            AlterColumn("dbo.Carriers", "MCNumber", c => c.String());
        }
    }
}
