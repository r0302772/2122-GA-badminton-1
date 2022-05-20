namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial_30 : DbMigration
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
                "dbo.CategorieSpeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpelerId = c.Int(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorie", t => t.CategorieId, cascadeDelete: true)
                .ForeignKey("dbo.Spelers", t => t.SpelerId, cascadeDelete: true)
                .Index(t => t.SpelerId)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.Spelers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false, maxLength: 50),
                        Familienaam = c.String(nullable: false, maxLength: 50),
                        Geboortedatum = c.DateTime(nullable: false),
                        Telefoonnummer = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        GeslachtID = c.Int(nullable: false),
                        ClubID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clubs", t => t.ClubID)
                .ForeignKey("dbo.Geslachten", t => t.GeslachtID, cascadeDelete: true)
                .Index(t => t.GeslachtID)
                .Index(t => t.ClubID);
            
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clubnaam = c.String(nullable: false, maxLength: 50),
                        Adres = c.String(nullable: false, maxLength: 50),
                        Gemeente = c.String(nullable: false, maxLength: 50),
                        DatumOpgericht = c.DateTime(nullable: false),
                        Telefoonnummer = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Geslachten",
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
                "dbo.CategorieSpelerRank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategorieId = c.Int(nullable: false),
                        SpelerId = c.Int(nullable: false),
                        RankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spelers", t => t.SpelerId, cascadeDelete: true)
                .Index(t => t.SpelerId);
            
            CreateTable(
                "dbo.Functie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personeel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false, maxLength: 50),
                        Familienaam = c.String(nullable: false, maxLength: 50),
                        Adres = c.String(nullable: false, maxLength: 50),
                        Gemeente = c.String(nullable: false, maxLength: 50),
                        Telefoonnummer = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        ClubId = c.Int(nullable: false),
                        FunctieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clubs", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.Functie", t => t.FunctieId, cascadeDelete: true)
                .Index(t => t.ClubId)
                .Index(t => t.FunctieId);
            
            CreateTable(
                "dbo.Gebruiker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gebruikernaam = c.String(nullable: false),
                        Wachtwoord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personeel", "FunctieId", "dbo.Functie");
            DropForeignKey("dbo.Personeel", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.CategorieSpelerRank", "SpelerId", "dbo.Spelers");
            DropForeignKey("dbo.Wedstrijd", "CategorieSpelerWedstrijd_Id", "dbo.CategorieWedstrijd");
            DropForeignKey("dbo.Spelers", "GeslachtID", "dbo.Geslachten");
            DropForeignKey("dbo.Spelers", "ClubID", "dbo.Clubs");
            DropForeignKey("dbo.CategorieSpeler", "SpelerId", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpeler", "CategorieId", "dbo.Categorie");
            DropIndex("dbo.Personeel", new[] { "FunctieId" });
            DropIndex("dbo.Personeel", new[] { "ClubId" });
            DropIndex("dbo.CategorieSpelerRank", new[] { "SpelerId" });
            DropIndex("dbo.Wedstrijd", new[] { "CategorieSpelerWedstrijd_Id" });
            DropIndex("dbo.Spelers", new[] { "ClubID" });
            DropIndex("dbo.Spelers", new[] { "GeslachtID" });
            DropIndex("dbo.CategorieSpeler", new[] { "CategorieId" });
            DropIndex("dbo.CategorieSpeler", new[] { "SpelerId" });
            DropTable("dbo.Gebruiker");
            DropTable("dbo.Personeel");
            DropTable("dbo.Functie");
            DropTable("dbo.CategorieSpelerRank");
            DropTable("dbo.Wedstrijd");
            DropTable("dbo.CategorieWedstrijd");
            DropTable("dbo.Geslachten");
            DropTable("dbo.Clubs");
            DropTable("dbo.Spelers");
            DropTable("dbo.CategorieSpeler");
            DropTable("dbo.Categorie");
        }
    }
}
