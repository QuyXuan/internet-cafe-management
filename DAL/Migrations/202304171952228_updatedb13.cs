namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillProduct",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 10, unicode: false),
                        BillId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Quantity = c.Single(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.BillId })
                .ForeignKey("dbo.Bill", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.RecieptProduct",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 10, unicode: false),
                        RecieptId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Quantity = c.Single(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.RecieptId })
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Reciept", t => t.RecieptId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.RecieptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.RecieptProduct", "RecieptId", "dbo.Reciept");
            DropForeignKey("dbo.RecieptProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.BillProduct", "BillId", "dbo.Bill");
            DropIndex("dbo.RecieptProduct", new[] { "RecieptId" });
            DropIndex("dbo.RecieptProduct", new[] { "ProductId" });
            DropIndex("dbo.BillProduct", new[] { "BillId" });
            DropIndex("dbo.BillProduct", new[] { "ProductId" });
            DropTable("dbo.RecieptProduct");
            DropTable("dbo.BillProduct");
        }
    }
}
