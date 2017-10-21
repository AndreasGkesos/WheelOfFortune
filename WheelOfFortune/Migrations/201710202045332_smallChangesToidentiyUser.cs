namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallChangesToidentiyUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary(nullable: false));
        }
    }
}
