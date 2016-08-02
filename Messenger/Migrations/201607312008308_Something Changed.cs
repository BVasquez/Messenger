namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupListViewModels",
                c => new
                    {
                        GroupListId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupListId);
            
            CreateTable(
                "dbo.GroupMemberViewModels",
                c => new
                    {
                        GroupMemberId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Member = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupMemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupMemberViewModels");
            DropTable("dbo.GroupListViewModels");
        }
    }
}
