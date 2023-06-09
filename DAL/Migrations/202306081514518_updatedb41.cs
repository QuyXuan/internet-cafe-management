namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillDiscount", "DiscountPercent", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillDiscount", "DiscountPercent");
        }
    }
}
