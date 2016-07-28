namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingRequiredfieldsatConversation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConversationViewModels", "Conversation", c => c.String(nullable: false));
            AlterColumn("dbo.ConversationViewModels", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConversationViewModels", "Message", c => c.String());
            AlterColumn("dbo.ConversationViewModels", "Conversation", c => c.String());
        }
    }
}
