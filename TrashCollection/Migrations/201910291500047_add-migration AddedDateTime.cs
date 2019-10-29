namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationAddedDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StartDateForNoPickup", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "EndDateForNoPickup", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndDateForNoPickup", c => c.String());
            AlterColumn("dbo.Customers", "StartDateForNoPickup", c => c.String());
        }
    }
}
