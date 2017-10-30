namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateExchangedpropertytoCoupondomain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "DateExchanged", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "DateExchanged");
        }
    }
}
