namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextColorandStatusConnectionaddedtoPersonalizationViewModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalizationViewModels", "TextColor", c => c.String());
            AddColumn("dbo.PersonalizationViewModels", "ConnectionStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalizationViewModels", "ConnectionStatus");
            DropColumn("dbo.PersonalizationViewModels", "TextColor");
        }
    }
}
