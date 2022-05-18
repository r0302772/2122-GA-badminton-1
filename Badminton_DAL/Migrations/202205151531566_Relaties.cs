namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relaties : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CategorieSpeler", "SpelerId");
            CreateIndex("dbo.CategorieSpeler", "CategorieId");
            CreateIndex("dbo.CategorieSpelerRank", "SpelerId");
            AddForeignKey("dbo.CategorieSpeler", "CategorieId", "dbo.Categorie", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategorieSpeler", "SpelerId", "dbo.Spelers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategorieSpelerRank", "SpelerId", "dbo.Spelers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategorieSpelerRank", "SpelerId", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpeler", "SpelerId", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpeler", "CategorieId", "dbo.Categorie");
            DropIndex("dbo.CategorieSpelerRank", new[] { "SpelerId" });
            DropIndex("dbo.CategorieSpeler", new[] { "CategorieId" });
            DropIndex("dbo.CategorieSpeler", new[] { "SpelerId" });
        }
    }
}
