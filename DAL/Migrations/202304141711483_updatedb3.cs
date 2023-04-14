namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComputerManvenue", "AccountId", "dbo.Account");
            DropForeignKey("dbo.ComputerManvenue", "ComputerId", "dbo.Computer");
            DropIndex("dbo.ComputerManvenue", new[] { "AccountId" });
            DropIndex("dbo.ComputerManvenue", new[] { "ComputerId" });
            AddColumn("dbo.Account", "DateCreate", c => c.DateTime());
            AddColumn("dbo.Customer", "TotalTime", c => c.Single());
            AddColumn("dbo.Customer", "TypeCustomer", c => c.Boolean(nullable: false));
            AddForeignKey("dbo.Customer", "DiscountId", "dbo.Discount", "DiscountId", cascadeDelete: true);
            DropColumn("dbo.Account", "TypeDiscount");
            DropColumn("dbo.Session", "UsedTime");
            DropTable("dbo.ComputerManvenue");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ComputerManvenue",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ComputerId = c.String(nullable: false, maxLength: 10, unicode: false),
                        IsEmployeeUsing = c.Boolean(),
                        Prepay = c.Single(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Total = c.Single(),
                    })
                .PrimaryKey(t => new { t.AccountId, t.ComputerId });
            
            AddColumn("dbo.Session", "UsedTime", c => c.Single());
            AddColumn("dbo.Account", "TypeDiscount", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Customer", "DiscountId", "dbo.Discount");
            DropIndex("dbo.Customer", new[] { "DiscountId" });
            DropColumn("dbo.Customer", "DiscountId");
            DropColumn("dbo.Customer", "TypeCustomer");
            DropColumn("dbo.Customer", "TotalTime");
            DropColumn("dbo.Account", "DateCreate");
            CreateIndex("dbo.ComputerManvenue", "ComputerId");
            CreateIndex("dbo.ComputerManvenue", "AccountId");
            AddForeignKey("dbo.ComputerManvenue", "ComputerId", "dbo.Computer", "ComputerId", cascadeDelete: true);
            AddForeignKey("dbo.ComputerManvenue", "AccountId", "dbo.Account", "AccountId", cascadeDelete: true);
        }
    }
}
