namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumntypeandFormattingColumnsadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConversationViewModels", "DataType", c => c.String());
            AddColumn("dbo.ConversationViewModels", "FormatWeight", c => c.String());
            AddColumn("dbo.ConversationViewModels", "FormatCursive", c => c.String());
            AddColumn("dbo.ConversationViewModels", "FormatColor", c => c.String());
            AddColumn("dbo.ConversationViewModels", "FormatSize", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConversationViewModels", "FormatSize");
            DropColumn("dbo.ConversationViewModels", "FormatColor");
            DropColumn("dbo.ConversationViewModels", "FormatCursive");
            DropColumn("dbo.ConversationViewModels", "FormatWeight");
            DropColumn("dbo.ConversationViewModels", "DataType");
        }
    }
}
