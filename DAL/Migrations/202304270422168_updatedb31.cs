namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillDay", "Type", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillDay", "Type");
        }
    }
}
