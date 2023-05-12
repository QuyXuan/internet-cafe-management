namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb38 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Computer", "ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computer", "ColorId", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
