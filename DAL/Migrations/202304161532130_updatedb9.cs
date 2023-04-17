namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "CostPrice", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "CostPrice");
        }
    }
}
