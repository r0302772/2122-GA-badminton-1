namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Spelers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false, maxLength: 50),
                        Familienaam = c.String(nullable: false, maxLength: 50),
                        Geslacht = c.String(nullable: false, maxLength: 1),
                        Geboortedatum = c.DateTime(nullable: false),
                        Telefoonnummer = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Spelers");
        }
    }
}
