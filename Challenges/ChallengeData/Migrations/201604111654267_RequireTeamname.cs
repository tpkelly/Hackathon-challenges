namespace ChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireTeamname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "TeamName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "TeamName", c => c.String());
        }
    }
}
