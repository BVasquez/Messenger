namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalizationFieldaddedtoGroupList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupListViewModels", "Color", c => c.String());
            AddColumn("dbo.GroupListViewModels", "TextColor", c => c.String());
            AddColumn("dbo.GroupListViewModels", "Background", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupListViewModels", "Background");
            DropColumn("dbo.GroupListViewModels", "TextColor");
            DropColumn("dbo.GroupListViewModels", "Color");
        }
    }
}
