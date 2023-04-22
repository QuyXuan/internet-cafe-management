namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bill", "TotalDiscountPercent", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bill", "TotalDiscountPercent");
        }
    }
}
