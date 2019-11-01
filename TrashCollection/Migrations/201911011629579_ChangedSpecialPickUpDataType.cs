namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedSpecialPickUpDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SpecialPickUp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SpecialPickUp", c => c.DateTime(nullable: false));
        }
    }
}
