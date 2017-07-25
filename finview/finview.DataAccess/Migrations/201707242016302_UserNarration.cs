namespace finview.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNarration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "UserNarration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "UserNarration");
        }
    }
}
