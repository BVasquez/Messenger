namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConversationViewModels",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Message = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConversationId);
            
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        NickName = c.String(),
                        Status = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserViewModels");
            DropTable("dbo.ConversationViewModels");
        }
    }
}
