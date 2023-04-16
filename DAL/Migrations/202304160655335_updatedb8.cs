namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "DateCreate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "DateCreate", c => c.DateTime());
        }
    }
}
