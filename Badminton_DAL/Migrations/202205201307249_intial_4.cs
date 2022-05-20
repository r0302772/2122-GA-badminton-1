namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial_4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategorieWedstrijd", newName: "CategorieSpelerWedstrijd");
            DropForeignKey("dbo.CategorieSpeler", "CategorieId", "dbo.Categorie");
            DropForeignKey("dbo.CategorieSpeler", "SpelerId", "dbo.Spelers");
            DropIndex("dbo.CategorieSpeler", new[] { "SpelerId" });
            DropIndex("dbo.CategorieSpeler", new[] { "CategorieId" });
            AddColumn("dbo.CategorieSpelerWedstrijd", "CategorieId", c => c.Int(nullable: false));
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerId");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "CategorieId");
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "CategorieId", "dbo.Categorie", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerId", "dbo.Spelers", "Id", cascadeDelete: true);
            DropColumn("dbo.CategorieSpelerWedstrijd", "Wedstrijd");
            DropTable("dbo.CategorieSpeler");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategorieSpeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpelerId = c.Int(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CategorieSpelerWedstrijd", "Wedstrijd", c => c.Int(nullable: false));
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerId", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "CategorieId", "dbo.Categorie");
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "CategorieId" });
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerId" });
            DropColumn("dbo.CategorieSpelerWedstrijd", "CategorieId");
            CreateIndex("dbo.CategorieSpeler", "CategorieId");
            CreateIndex("dbo.CategorieSpeler", "SpelerId");
            AddForeignKey("dbo.CategorieSpeler", "SpelerId", "dbo.Spelers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategorieSpeler", "CategorieId", "dbo.Categorie", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CategorieSpelerWedstrijd", newName: "CategorieWedstrijd");
        }
    }
}
