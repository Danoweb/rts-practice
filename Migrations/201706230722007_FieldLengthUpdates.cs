namespace PracticeCarriers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldLengthUpdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carriers", "Address1", c => c.String(maxLength: 200));
            AlterColumn("dbo.Carriers", "Address2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Carriers", "City", c => c.String(maxLength: 200));
            AlterColumn("dbo.Carriers", "Zip", c => c.String(maxLength: 20));
            AlterColumn("dbo.Carriers", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Carriers", "WebURL", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carriers", "WebURL", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Zip", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Address2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Carriers", "Address1", c => c.String(maxLength: 50));
        }
    }
}
