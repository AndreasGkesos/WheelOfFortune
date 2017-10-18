namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChangeToMakeBalnceDefautt100 : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.Balances", "BalanceValue", c => c.Long(defaultValue:100));
        }
        
        public override void Down()
        {
        }
    }
}
