namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillDay",
                c => new
                    {
                        BillDayId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Date = c.DateTime(nullable: false),
                        TotalBill = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.BillDayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BillDay");
        }
    }
}
