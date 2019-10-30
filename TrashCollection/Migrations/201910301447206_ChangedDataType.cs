namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Customers", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
        }
    }
}
