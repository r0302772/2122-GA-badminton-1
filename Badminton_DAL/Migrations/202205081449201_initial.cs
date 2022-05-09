namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geslachten",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Spelers", "GeslachtID", c => c.Int(nullable: false));
            AddColumn("dbo.Spelers", "ClubID", c => c.Int(nullable: false));
            CreateIndex("dbo.Spelers", "GeslachtID");
            CreateIndex("dbo.Spelers", "ClubID");
            AddForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten", "Id", cascadeDelete: true);
            DropColumn("dbo.Spelers", "Geslacht");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Spelers", "Geslacht", c => c.String(nullable: false, maxLength: 1));
            DropForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten");
            DropForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs");
            DropIndex("dbo.Spelers", new[] { "ClubID" });
            DropIndex("dbo.Spelers", new[] { "GeslachtID" });
            DropColumn("dbo.Spelers", "ClubID");
            DropColumn("dbo.Spelers", "GeslachtID");
            DropTable("dbo.Geslachten");
        }
    }
}
