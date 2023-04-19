namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb131 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computer", "IPComputer", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computer", "IPComputer");
        }
    }
}
