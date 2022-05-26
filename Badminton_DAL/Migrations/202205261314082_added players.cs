namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedplayers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerId", "dbo.Spelers");
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerId" });
            RenameColumn(table: "dbo.CategorieSpelerWedstrijd", name: "SpelerId", newName: "Speler_Id");
            AddColumn("dbo.CategorieSpelerWedstrijd", "SpelerHome1Id", c => c.Int(nullable: false));
            AddColumn("dbo.CategorieSpelerWedstrijd", "SpelerHome2Id", c => c.Int());
            AddColumn("dbo.CategorieSpelerWedstrijd", "SpelerAway1Id", c => c.Int(nullable: false));
            AddColumn("dbo.CategorieSpelerWedstrijd", "SpelerAway2Id", c => c.Int());
            AlterColumn("dbo.CategorieSpelerWedstrijd", "Speler_Id", c => c.Int());
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerHome1Id");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerHome2Id");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerAway1Id");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerAway2Id");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "Speler_Id");
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerAway1Id", "dbo.Spelers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerAway2Id", "dbo.Spelers", "Id");
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerHome1Id", "dbo.Spelers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerHome2Id", "dbo.Spelers", "Id");
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "Speler_Id", "dbo.Spelers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "Speler_Id", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerHome2Id", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerHome1Id", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerAway2Id", "dbo.Spelers");
            DropForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerAway1Id", "dbo.Spelers");
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "Speler_Id" });
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerAway2Id" });
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerAway1Id" });
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerHome2Id" });
            DropIndex("dbo.CategorieSpelerWedstrijd", new[] { "SpelerHome1Id" });
            AlterColumn("dbo.CategorieSpelerWedstrijd", "Speler_Id", c => c.Int(nullable: false));
            DropColumn("dbo.CategorieSpelerWedstrijd", "SpelerAway2Id");
            DropColumn("dbo.CategorieSpelerWedstrijd", "SpelerAway1Id");
            DropColumn("dbo.CategorieSpelerWedstrijd", "SpelerHome2Id");
            DropColumn("dbo.CategorieSpelerWedstrijd", "SpelerHome1Id");
            RenameColumn(table: "dbo.CategorieSpelerWedstrijd", name: "Speler_Id", newName: "SpelerId");
            CreateIndex("dbo.CategorieSpelerWedstrijd", "SpelerId");
            AddForeignKey("dbo.CategorieSpelerWedstrijd", "SpelerId", "dbo.Spelers", "Id", cascadeDelete: true);
        }
    }
}
