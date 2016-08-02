namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilePhototoGroupListadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupListViewModels", "ProfilePhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupListViewModels", "ProfilePhoto");
        }
    }
}
