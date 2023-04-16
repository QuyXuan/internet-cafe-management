namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Session_SessionId", c => c.String(maxLength: 10, unicode: false));
            CreateIndex("dbo.Product", "Session_SessionId");
            AddForeignKey("dbo.Product", "Session_SessionId", "dbo.Session", "SessionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Session_SessionId", "dbo.Session");
            DropIndex("dbo.Product", new[] { "Session_SessionId" });
            DropColumn("dbo.Product", "Session_SessionId");
        }
    }
}
