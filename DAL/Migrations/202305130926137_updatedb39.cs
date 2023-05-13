namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computer", "AccountId", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computer", "AccountId");
        }
    }
}
