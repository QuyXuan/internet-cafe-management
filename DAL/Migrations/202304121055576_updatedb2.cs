namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageFilePath", c => c.String());
            DropColumn("dbo.Product", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Image", c => c.Binary());
            DropColumn("dbo.Product", "ImageFilePath");
        }
    }
}
