namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GebruikerEntityAangemaaktAanpassing : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Gebruiker");
        }
    }
}
