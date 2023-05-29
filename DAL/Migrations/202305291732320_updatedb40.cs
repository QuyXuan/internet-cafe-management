namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillProduct", "Price", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillProduct", "Price");
        }
    }
}
