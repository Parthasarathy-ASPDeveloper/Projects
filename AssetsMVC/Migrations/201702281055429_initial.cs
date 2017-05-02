namespace AssetsMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cpuentry16", "asset_id", c => c.String(nullable: false));
            AlterColumn("dbo.cpuentry16", "assetLocation_id", c => c.String(nullable: false));
            AlterColumn("dbo.cpuentry16", "productnumber", c => c.String(nullable: false));
            AlterColumn("dbo.cpuentry16", "serialnumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cpuentry16", "serialnumber", c => c.String());
            AlterColumn("dbo.cpuentry16", "productnumber", c => c.String());
            AlterColumn("dbo.cpuentry16", "assetLocation_id", c => c.String());
            AlterColumn("dbo.cpuentry16", "asset_id", c => c.String());
        }
    }
}
