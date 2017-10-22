namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeallmoneypropertiestodecimal : DbMigration
    {
        public override void Up()
        {
            Sql("alter table dbo.Balances drop constraint[DF_dbo.Balances_BalanceValue]");
            AlterColumn("dbo.Balances", "BalanceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CouponValues", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Spins", "ScoreValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Spins", "BetValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Spins", "ResultValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Value", c => c.Double(nullable: false));
            AlterColumn("dbo.Spins", "ResultValue", c => c.Double(nullable: false));
            AlterColumn("dbo.Spins", "BetValue", c => c.Double(nullable: false));
            AlterColumn("dbo.Spins", "ScoreValue", c => c.Double(nullable: false));
            AlterColumn("dbo.CouponValues", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Balances", "BalanceValue", c => c.Long(nullable: false));
        }
    }
}
