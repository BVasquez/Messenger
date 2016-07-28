namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statusfieldisdeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserViewModels", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserViewModels", "Status", c => c.String(nullable: false));
        }
    }
}
