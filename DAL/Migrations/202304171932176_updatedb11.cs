namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Computer");
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Customer");
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Bill_BillId", "dbo.Bill");
            DropForeignKey("dbo.Reciept", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Reciept_RecieptId", "dbo.Reciept");
            DropIndex("dbo.Bill", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "Bill_BillId" });
            DropIndex("dbo.Product", new[] { "Reciept_RecieptId" });
            DropIndex("dbo.Reciept", new[] { "ProductId" });
            AddColumn("dbo.Product", "CostPrice", c => c.Single());
            DropColumn("dbo.Bill", "CreatedBy");
            DropColumn("dbo.Bill", "ProductId");
            DropColumn("dbo.Bill", "ProductName");
            DropColumn("dbo.Bill", "ComputerId");
            DropColumn("dbo.Bill", "IPClient");
            DropColumn("dbo.Bill", "CustomerId");
            DropColumn("dbo.Product", "Bill_BillId");
            DropColumn("dbo.Product", "Reciept_RecieptId");
            DropColumn("dbo.Reciept", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reciept", "ProductId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "Reciept_RecieptId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "Bill_BillId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "CustomerId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "IPClient", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Bill", "ComputerId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Bill", "ProductId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "CreatedBy", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Product", "CostPrice");
            CreateIndex("dbo.Reciept", "ProductId");
            CreateIndex("dbo.Product", "Reciept_RecieptId");
            CreateIndex("dbo.Product", "Bill_BillId");
            CreateIndex("dbo.Bill", "ProductId");
            AddForeignKey("dbo.Product", "Reciept_RecieptId", "dbo.Reciept", "RecieptId");
            AddForeignKey("dbo.Reciept", "ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.Product", "Bill_BillId", "dbo.Bill", "BillId");
            AddForeignKey("dbo.Bill", "ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.Bill", "ProductId", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.Bill", "ProductId", "dbo.Computer", "ComputerId");
        }
    }
}
