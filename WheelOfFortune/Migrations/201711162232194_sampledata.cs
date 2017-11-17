namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sampledata : DbMigration
    {
        public override void Up()
        {

            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(25,'string','x1.5',1,'You win',1.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',1)");

            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "25,'string','Lose -4.5',0,'Oops',-4.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',1)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "25,'string','Win 5',1,'You win yeah',5.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',1)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "25,'string','Lose -2',0,'You Lose Sorry',-2.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',1)");


            Sql("INSERT INTO dbo.WheelConfigurations (DateCreated,User_id) VALUES('11/25/2017','adf343a0-bfea-4474-82ec-c3185b8a102d')");



            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "10,'string','Win 1.5',1,'You win',1.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',2)");

            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "10,'string','Lose -4.5',0,'Oops',-4.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',2)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "10,'string','Win +5',1,'You win yeah',5.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',2)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "10,'string','Lose -2',0,'You Lose Sorry',-2.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',2)");

            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "10,'string','Win 1.5',1,'You win',1.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',2)");

            Sql("INSERT INTO dbo.WheelConfigurations (DateCreated,User_id) VALUES('11/26/2017','adf343a0-bfea-4474-82ec-c3185b8a102d')");



            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "34,'string','Lose -14.5',0,'Oops',-14.5,'adf343a0-bfea-4474-82ec-c3185b8a102d',3)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "34,'string','Win 15',1,'You win yeah',15.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',3)");


            Sql(
                "INSERT INTO dbo.WheelConfigurationSlice  (Propability,Type,Value,Win,ResultText,Score,User_id,WheelConfiguration_id) VALUES(" +
                "32,'string','Lose -12',0,'You Lose Sorry',-12.0,'adf343a0-bfea-4474-82ec-c3185b8a102d',3)");

        }

        public override void Down()
        {
        }
    }
}
