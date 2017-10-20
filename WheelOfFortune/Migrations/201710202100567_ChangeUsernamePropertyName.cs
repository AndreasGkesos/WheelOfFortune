namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUsernamePropertyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UName");
        }
    }
}
