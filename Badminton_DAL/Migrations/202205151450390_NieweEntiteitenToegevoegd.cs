namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NieweEntiteitenToegevoegd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieWedstrijd",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpelerId = c.Int(nullable: false),
                        Wedstrijd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wedstrijd",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Seizoen = c.String(),
                        CategorieSpelerWedstrijd_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorieWedstrijd", t => t.CategorieSpelerWedstrijd_Id)
                .Index(t => t.CategorieSpelerWedstrijd_Id);
            
            CreateTable(
                "dbo.CategorieSpeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategorieId = c.Int(nullable: false),
                        SpelerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategorieSpelerRank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategorieId = c.Int(nullable: false),
                        SpelerId = c.Int(nullable: false),
                        RankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Functie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Personeel", "ClubId", c => c.Int(nullable: false));
            AddColumn("dbo.Personeel", "FunctieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personeel", "FunctieId");
            AddForeignKey("dbo.Personeel", "FunctieId", "dbo.Functie", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personeel", "FunctieId", "dbo.Functie");
            DropForeignKey("dbo.Wedstrijd", "CategorieSpelerWedstrijd_Id", "dbo.CategorieWedstrijd");
            DropIndex("dbo.Personeel", new[] { "FunctieId" });
            DropIndex("dbo.Wedstrijd", new[] { "CategorieSpelerWedstrijd_Id" });
            DropColumn("dbo.Personeel", "FunctieId");
            DropColumn("dbo.Personeel", "ClubId");
            DropTable("dbo.Functie");
            DropTable("dbo.CategorieSpelerRank");
            DropTable("dbo.CategorieSpeler");
            DropTable("dbo.Wedstrijd");
            DropTable("dbo.CategorieWedstrijd");
            DropTable("dbo.Categorie");
        }
    }
}
