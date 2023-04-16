namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "ComputerId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "IPClient", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Bill", "CustomerId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "Product_ProductId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "Bill_BillId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "Reciept_RecieptId", c => c.String(maxLength: 10, unicode: false));
            CreateIndex("dbo.Bill", "Product_ProductId");
            CreateIndex("dbo.Product", "Bill_BillId");
            CreateIndex("dbo.Product", "Reciept_RecieptId");
            AddForeignKey("dbo.Bill", "ProductId", "dbo.Computer", "ComputerId");
            AddForeignKey("dbo.Bill", "ProductId", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.Bill", "Product_ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.Product", "Bill_BillId", "dbo.Bill", "BillId");
            AddForeignKey("dbo.Product", "Reciept_RecieptId", "dbo.Reciept", "RecieptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Reciept_RecieptId", "dbo.Reciept");
            DropForeignKey("dbo.Product", "Bill_BillId", "dbo.Bill");
            DropForeignKey("dbo.Bill", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Customer");
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Computer");
            DropIndex("dbo.Product", new[] { "Reciept_RecieptId" });
            DropIndex("dbo.Product", new[] { "Bill_BillId" });
            DropIndex("dbo.Bill", new[] { "Product_ProductId" });
            DropColumn("dbo.Product", "Reciept_RecieptId");
            DropColumn("dbo.Product", "Bill_BillId");
            DropColumn("dbo.Bill", "Product_ProductId");
            DropColumn("dbo.Bill", "CustomerId");
            DropColumn("dbo.Bill", "IPClient");
            DropColumn("dbo.Bill", "ComputerId");
        }
    }
}
