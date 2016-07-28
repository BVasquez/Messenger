namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingrequiredtoUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserViewModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserViewModels", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserViewModels", "Password", c => c.String());
            AlterColumn("dbo.UserViewModels", "Email", c => c.String());
            AlterColumn("dbo.UserViewModels", "Country", c => c.String());
            AlterColumn("dbo.UserViewModels", "Gender", c => c.String());
            AlterColumn("dbo.UserViewModels", "Status", c => c.String());
            AlterColumn("dbo.UserViewModels", "LastName", c => c.String());
            AlterColumn("dbo.UserViewModels", "FirstName", c => c.String());
        }
    }
}
