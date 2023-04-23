namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reciept", "Manufacturer", c => c.String(maxLength: 50));
            AddColumn("dbo.Reciept", "Discount", c => c.Single());
            DropColumn("dbo.Reciept", "Storekeeper");
            DropColumn("dbo.Reciept", "Quantity");
            DropColumn("dbo.Reciept", "CostPrice");
            DropColumn("dbo.Reciept", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reciept", "ProductName", c => c.String(maxLength: 50));
            AddColumn("dbo.Reciept", "CostPrice", c => c.Single());
            AddColumn("dbo.Reciept", "Quantity", c => c.Single());
            AddColumn("dbo.Reciept", "Storekeeper", c => c.String(maxLength: 50));
            DropColumn("dbo.Reciept", "Discount");
            DropColumn("dbo.Reciept", "Manufacturer");
        }
    }
}
