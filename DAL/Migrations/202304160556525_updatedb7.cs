namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Session_SessionId", "dbo.Session");
            DropIndex("dbo.Product", new[] { "Session_SessionId" });
            AddColumn("dbo.Reciept", "Product_ProductId", c => c.String(maxLength: 10, unicode: false));
            CreateIndex("dbo.Reciept", "Product_ProductId");
            AddForeignKey("dbo.Reciept", "Product_ProductId", "dbo.Product", "ProductId");
            DropColumn("dbo.Product", "Session_SessionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Session_SessionId", c => c.String(maxLength: 10, unicode: false));
            DropForeignKey("dbo.Reciept", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Reciept", new[] { "Product_ProductId" });
            DropColumn("dbo.Reciept", "Product_ProductId");
            CreateIndex("dbo.Product", "Session_SessionId");
            AddForeignKey("dbo.Product", "Session_SessionId", "dbo.Session", "SessionId");
        }
    }
}
