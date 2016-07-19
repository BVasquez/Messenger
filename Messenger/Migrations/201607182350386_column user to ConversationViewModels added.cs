namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnusertoConversationViewModelsadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConversationViewModels", "user", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConversationViewModels", "user");
        }
    }
}
