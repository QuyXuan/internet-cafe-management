namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "ComputerId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "IPClient", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Bill", "CustomerId", c => c.String(maxLength: 10, unicode: false));
            CreateIndex("dbo.Bill", "ComputerId");
            CreateIndex("dbo.Bill", "CustomerId");
            AddForeignKey("dbo.Bill", "ComputerId", "dbo.Computer", "ComputerId");
            AddForeignKey("dbo.Bill", "CustomerId", "dbo.Customer", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bill", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Bill", "ComputerId", "dbo.Computer");
            DropIndex("dbo.Bill", new[] { "CustomerId" });
            DropIndex("dbo.Bill", new[] { "ComputerId" });
            DropColumn("dbo.Bill", "CustomerId");
            DropColumn("dbo.Bill", "IPClient");
            DropColumn("dbo.Bill", "ComputerId");
        }
    }
}
