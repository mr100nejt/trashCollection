namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Employee_Id");
            AddForeignKey("dbo.Customers", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Customers", new[] { "Employee_Id" });
            DropColumn("dbo.Customers", "Employee_Id");
        }
    }
}
