namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendViewModels",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Friend = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FriendViewModels");
        }
    }
}
