namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKVoorWerkenemerClub : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Personeel", "ClubId");
            AddForeignKey("dbo.Personeel", "ClubId", "dbo.Clubs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personeel", "ClubId", "dbo.Clubs");
            DropIndex("dbo.Personeel", new[] { "ClubId" });
        }
    }
}
