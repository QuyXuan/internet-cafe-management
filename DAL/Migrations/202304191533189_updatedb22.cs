namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Computer", "NameType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computer", "NameType", c => c.String(maxLength: 50));
        }
    }
}
