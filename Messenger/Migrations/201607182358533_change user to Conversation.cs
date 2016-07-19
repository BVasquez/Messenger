namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeusertoConversation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConversationViewModels", "Conversation", c => c.String());
            DropColumn("dbo.ConversationViewModels", "user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ConversationViewModels", "user", c => c.Int(nullable: false));
            DropColumn("dbo.ConversationViewModels", "Conversation");
        }
    }
}
