namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedomains : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfigurationSlice_Id", "dbo.WheelConfigurationSlice");
            DropForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropForeignKey("dbo.WheelConfigurationSpins", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropForeignKey("dbo.WheelConfigurationSpins", "Spin_Id", "dbo.Spins");
            DropIndex("dbo.WheelConfigurationSliceWheelConfigurations", new[] { "WheelConfigurationSlice_Id" });
            DropIndex("dbo.WheelConfigurationSliceWheelConfigurations", new[] { "WheelConfiguration_Id" });
            DropIndex("dbo.WheelConfigurationSpins", new[] { "WheelConfiguration_Id" });
            DropIndex("dbo.WheelConfigurationSpins", new[] { "Spin_Id" });
            AddColumn("dbo.Spins", "WheelConfiguration_Id", c => c.Int());
            AddColumn("dbo.WheelConfigurationSlice", "WheelConfiguration_Id", c => c.Int());
            CreateIndex("dbo.Spins", "WheelConfiguration_Id");
            CreateIndex("dbo.WheelConfigurationSlice", "WheelConfiguration_Id");
            AddForeignKey("dbo.Spins", "WheelConfiguration_Id", "dbo.WheelConfigurations", "Id");
            AddForeignKey("dbo.WheelConfigurationSlice", "WheelConfiguration_Id", "dbo.WheelConfigurations", "Id");
            DropTable("dbo.WheelConfigurationSliceWheelConfigurations");
            DropTable("dbo.WheelConfigurationSpins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WheelConfigurationSpins",
                c => new
                    {
                        WheelConfiguration_Id = c.Int(nullable: false),
                        Spin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WheelConfiguration_Id, t.Spin_Id });
            
            CreateTable(
                "dbo.WheelConfigurationSliceWheelConfigurations",
                c => new
                    {
                        WheelConfigurationSlice_Id = c.Int(nullable: false),
                        WheelConfiguration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WheelConfigurationSlice_Id, t.WheelConfiguration_Id });
            
            DropForeignKey("dbo.WheelConfigurationSlice", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropForeignKey("dbo.Spins", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropIndex("dbo.WheelConfigurationSlice", new[] { "WheelConfiguration_Id" });
            DropIndex("dbo.Spins", new[] { "WheelConfiguration_Id" });
            DropColumn("dbo.WheelConfigurationSlice", "WheelConfiguration_Id");
            DropColumn("dbo.Spins", "WheelConfiguration_Id");
            CreateIndex("dbo.WheelConfigurationSpins", "Spin_Id");
            CreateIndex("dbo.WheelConfigurationSpins", "WheelConfiguration_Id");
            CreateIndex("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfiguration_Id");
            CreateIndex("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfigurationSlice_Id");
            AddForeignKey("dbo.WheelConfigurationSpins", "Spin_Id", "dbo.Spins", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WheelConfigurationSpins", "WheelConfiguration_Id", "dbo.WheelConfigurations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfiguration_Id", "dbo.WheelConfigurations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfigurationSlice_Id", "dbo.WheelConfigurationSlice", "Id", cascadeDelete: true);
        }
    }
}
