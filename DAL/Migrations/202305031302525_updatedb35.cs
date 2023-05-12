namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bill", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Bill", new[] { "EmployeeId" });
            AlterColumn("dbo.Bill", "EmployeeId", c => c.String(maxLength: 10, unicode: false));
            CreateIndex("dbo.Bill", "EmployeeId");
            AddForeignKey("dbo.Bill", "EmployeeId", "dbo.Employee", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bill", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Bill", new[] { "EmployeeId" });
            AlterColumn("dbo.Bill", "EmployeeId", c => c.String(nullable: false, maxLength: 10, unicode: false));
            CreateIndex("dbo.Bill", "EmployeeId");
            AddForeignKey("dbo.Bill", "EmployeeId", "dbo.Employee", "EmployeeId", cascadeDelete: true);
        }
    }
}
