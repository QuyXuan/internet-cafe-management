namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TypeComputer", "ColorId", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Product", "ProductImage", c => c.Binary());
            DropColumn("dbo.Product", "ImageFilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ImageFilePath", c => c.String());
            DropColumn("dbo.Product", "ProductImage");
            DropColumn("dbo.TypeComputer", "ColorId");
        }
    }
}
