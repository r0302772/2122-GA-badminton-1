namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class securestring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gebruiker", "Gebruikersnaam", c => c.String(nullable: false));
            DropColumn("dbo.Gebruiker", "Gebruikernaam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gebruiker", "Gebruikernaam", c => c.String(nullable: false));
            DropColumn("dbo.Gebruiker", "Gebruikersnaam");
        }
    }
}
