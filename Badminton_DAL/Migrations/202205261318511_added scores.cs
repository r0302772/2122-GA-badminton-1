namespace Badminton_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedscores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wedstrijd", "ScoreHome", c => c.Int(nullable: false));
            AddColumn("dbo.Wedstrijd", "ScoreAway", c => c.Int(nullable: false));
            DropColumn("dbo.Wedstrijd", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wedstrijd", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Wedstrijd", "ScoreAway");
            DropColumn("dbo.Wedstrijd", "ScoreHome");
        }
    }
}
