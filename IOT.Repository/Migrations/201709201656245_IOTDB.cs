namespace IOT.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IOTDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Type = c.String(),
                        Name = c.String(),
                        ModelId = c.String(),
                        ProductId = c.String(),
                        SwConfigId = c.String(),
                        UniqueId = c.String(),
                        LuminaireUniqueId = c.String(),
                        ManufacturerName = c.String(),
                        SoftwareVersion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        On = c.Boolean(nullable: false),
                        Brightness = c.Byte(nullable: false),
                        Hue = c.Int(),
                        Saturation = c.Int(),
                        ColorTemperature = c.Int(),
                        Alert = c.Int(nullable: false),
                        Effect = c.Int(),
                        ColorMode = c.String(),
                        IsReachable = c.Boolean(),
                        TransitionTime = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lights", "StateId", "dbo.States");
            DropIndex("dbo.Lights", new[] { "StateId" });
            DropTable("dbo.States");
            DropTable("dbo.Lights");
        }
    }
}
