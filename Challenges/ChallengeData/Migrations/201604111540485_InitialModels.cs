namespace ChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        QuestionId = c.Long(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        QuestionNo = c.String(),
                        Reward = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubmissionAnswers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SubmissionId = c.Long(nullable: false),
                        QuestionId = c.Long(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: true)
                .Index(t => t.SubmissionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TeamName = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Funds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmissionAnswers", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.SubmissionAnswers", new[] { "QuestionId" });
            DropIndex("dbo.SubmissionAnswers", new[] { "SubmissionId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.SubmissionAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
