namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aanpassingFKClubId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs");
            DropIndex("dbo.Spelers", new[] { "ClubID" });
            AlterColumn("dbo.Spelers", "ClubID", c => c.Int());
            CreateIndex("dbo.Spelers", "ClubID");
            AddForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs");
            DropIndex("dbo.Spelers", new[] { "ClubID" });
            AlterColumn("dbo.Spelers", "ClubID", c => c.Int(nullable: false));
            CreateIndex("dbo.Spelers", "ClubID");
            AddForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs", "Id", cascadeDelete: true);
        }
    }
}
