namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Geslachten : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten");
            DropPrimaryKey("dbo.Geslachten");
            DropColumn("dbo.Geslachten", "GeslachtID");
            AddColumn("dbo.Geslachten", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Geslachten", "Id");
            AddForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Geslachten", "GeslachtID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten");
            DropPrimaryKey("dbo.Geslachten");
            DropColumn("dbo.Geslachten", "Id");
            AddPrimaryKey("dbo.Geslachten", "GeslachtID");
            AddForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten", "GeslachtID", cascadeDelete: true);
        }
    }
}
