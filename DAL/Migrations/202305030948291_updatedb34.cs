namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb34 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Session", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Session", "ComputerId", "dbo.Computer");
            DropIndex("dbo.Session", new[] { "AccountId" });
            DropIndex("dbo.Session", new[] { "ComputerId" });
            AddColumn("dbo.Product", "Status", c => c.Boolean(nullable: false));
            DropTable("dbo.Session");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.String(nullable: false, maxLength: 10, unicode: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        TotalTime = c.Single(),
                        AccountId = c.String(nullable: false, maxLength: 10, unicode: false),
                        ComputerId = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.SessionId);
            
            DropColumn("dbo.Product", "Status");
            CreateIndex("dbo.Session", "ComputerId");
            CreateIndex("dbo.Session", "AccountId");
            AddForeignKey("dbo.Session", "ComputerId", "dbo.Computer", "ComputerId", cascadeDelete: true);
            AddForeignKey("dbo.Session", "AccountId", "dbo.Account", "AccountId", cascadeDelete: true);
        }
    }
}
