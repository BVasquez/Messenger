namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationGroupsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConversationGroupViewModels",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        From = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        DataType = c.String(),
                        FormatWeight = c.String(),
                        FormatCursive = c.String(),
                        FormatColor = c.String(),
                        FormatSize = c.String(),
                    })
                .PrimaryKey(t => t.ConversationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConversationGroupViewModels");
        }
    }
}
