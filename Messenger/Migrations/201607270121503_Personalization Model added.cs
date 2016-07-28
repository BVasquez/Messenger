namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalizationModeladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalizationViewModels",
                c => new
                    {
                        PersonalizationId = c.Int(nullable: false, identity: true),
                        User = c.Int(nullable: false),
                        PhotoProfile = c.String(),
                        PhotoBackground = c.String(),
                        Color = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.PersonalizationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalizationViewModels");
        }
    }
}
