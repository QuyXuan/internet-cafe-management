namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bill", "DiscountId", "dbo.Discount");
            DropIndex("dbo.Bill", new[] { "DiscountId" });
            CreateTable(
                "dbo.BillDiscount",
                c => new
                    {
                        DiscountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        BillId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => new { t.DiscountId, t.BillId })
                .ForeignKey("dbo.Bill", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Discount", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.DiscountId)
                .Index(t => t.BillId);
            
            AlterColumn("dbo.Discount", "TypeCustomer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Bill", "DiscountId");
            DropColumn("dbo.Bill", "DiscountPercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bill", "DiscountPercent", c => c.Single());
            AddColumn("dbo.Bill", "DiscountId", c => c.String(maxLength: 10, unicode: false));
            DropForeignKey("dbo.BillDiscount", "DiscountId", "dbo.Discount");
            DropForeignKey("dbo.BillDiscount", "BillId", "dbo.Bill");
            DropIndex("dbo.BillDiscount", new[] { "BillId" });
            DropIndex("dbo.BillDiscount", new[] { "DiscountId" });
            AlterColumn("dbo.Discount", "TypeCustomer", c => c.String(maxLength: 100));
            DropTable("dbo.BillDiscount");
            CreateIndex("dbo.Bill", "DiscountId");
            AddForeignKey("dbo.Bill", "DiscountId", "dbo.Discount", "DiscountId");
        }
    }
}
