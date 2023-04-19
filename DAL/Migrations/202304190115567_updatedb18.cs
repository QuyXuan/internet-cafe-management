namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb18 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "DiscountId", "dbo.Discount");
            DropIndex("dbo.Customer", new[] { "DiscountId" });
            AddColumn("dbo.Discount", "TypeCustomer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Bill", "Quantity");
            DropColumn("dbo.Customer", "DiscountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "DiscountId", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AddColumn("dbo.Bill", "Quantity", c => c.Single());
            DropColumn("dbo.Discount", "TypeCustomer");
            CreateIndex("dbo.Customer", "DiscountId");
            AddForeignKey("dbo.Customer", "DiscountId", "dbo.Discount", "DiscountId", cascadeDelete: true);
        }
    }
}
