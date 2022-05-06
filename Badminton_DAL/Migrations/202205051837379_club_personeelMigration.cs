namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class club_personeelMigration : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personeel");
            DropTable("dbo.Clubs");
        }
    }
}
