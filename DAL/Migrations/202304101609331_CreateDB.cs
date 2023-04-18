namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Role = c.String(nullable: false),
                        TypeDiscount = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.AccountId)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        BillId = c.String(nullable: false, maxLength: 10, unicode: false),
                        EmployeeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        DiscountId = c.String(maxLength: 10, unicode: false),
                        DiscountPercent = c.Single(),
                        Total = c.Single(),
                        Date = c.DateTime(),
                        Status = c.String(nullable: false, maxLength: 255),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        ProductId = c.String(maxLength: 10, unicode: false),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Single(),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Discount", t => t.DiscountId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DiscountId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Discount",
                c => new
                    {
                        DiscountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        DiscountName = c.String(nullable: false, maxLength: 50),
                        DiscountPercent = c.Single(),
                    })
                .PrimaryKey(t => t.DiscountId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        Salary = c.Single(),
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        OtherInfomation = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        SellingPrice = c.Single(),
                        Type = c.String(nullable: false),
                        Stock = c.Single(),
                        Discription = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ProductId);
            
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
                .PrimaryKey(t => new { t.AccountId, t.ComputerId })
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Computer", t => t.ComputerId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.ComputerId);
            
            CreateTable(
                "dbo.Computer",
                c => new
                    {
                        ComputerId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ComputerName = c.String(nullable: false, maxLength: 50),
                        TypeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        NameType = c.String(maxLength: 50),
                        Status = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ComputerId)
                .ForeignKey("dbo.TypeComputer", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.TypeComputer",
                c => new
                    {
                        TypeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        NameType = c.String(nullable: false, maxLength: 50),
                        Price = c.Single(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 10, unicode: false),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        Balance = c.Single(),
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Reciept",
                c => new
                    {
                        RecieptId = c.String(nullable: false, maxLength: 10, unicode: false),
                        TotalBill = c.Single(),
                        Date = c.DateTime(),
                        EmployeeId = c.String(maxLength: 10, unicode: false),
                        Storekeeper = c.String(maxLength: 50),
                        Quantity = c.Single(),
                        CostPrice = c.Single(),
                        ProductId = c.String(maxLength: 10, unicode: false),
                        ProductName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RecieptId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.String(nullable: false, maxLength: 10, unicode: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        TotalTime = c.Single(),
                        UsedTime = c.Single(),
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ComputerId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Computer", t => t.ComputerId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.ComputerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Session", "ComputerId", "dbo.Computer");
            DropForeignKey("dbo.Session", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Reciept", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Reciept", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Customer", "AccountId", "dbo.Account");
            DropForeignKey("dbo.ComputerManvenue", "ComputerId", "dbo.Computer");
            DropForeignKey("dbo.Computer", "TypeId", "dbo.TypeComputer");
            DropForeignKey("dbo.ComputerManvenue", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Bill", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Bill", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Bill", "DiscountId", "dbo.Discount");
            DropIndex("dbo.Session", new[] { "ComputerId" });
            DropIndex("dbo.Session", new[] { "AccountId" });
            DropIndex("dbo.Reciept", new[] { "ProductId" });
            DropIndex("dbo.Reciept", new[] { "EmployeeId" });
            DropIndex("dbo.Customer", new[] { "AccountId" });
            DropIndex("dbo.Computer", new[] { "TypeId" });
            DropIndex("dbo.ComputerManvenue", new[] { "ComputerId" });
            DropIndex("dbo.ComputerManvenue", new[] { "AccountId" });
            DropIndex("dbo.Employee", new[] { "AccountId" });
            DropIndex("dbo.Bill", new[] { "ProductId" });
            DropIndex("dbo.Bill", new[] { "DiscountId" });
            DropIndex("dbo.Bill", new[] { "EmployeeId" });
            DropIndex("dbo.Account", new[] { "UserName" });
            DropTable("dbo.Session");
            DropTable("dbo.Reciept");
            DropTable("dbo.Customer");
            DropTable("dbo.TypeComputer");
            DropTable("dbo.Computer");
            DropTable("dbo.ComputerManvenue");
            DropTable("dbo.Product");
            DropTable("dbo.Employee");
            DropTable("dbo.Discount");
            DropTable("dbo.Bill");
            DropTable("dbo.Account");
        }
    }
}
