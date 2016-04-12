namespace ChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoQuestionLinkOnSubmissionAnswer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubmissionAnswers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.SubmissionAnswers", new[] { "QuestionId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SubmissionAnswers", "QuestionId");
            AddForeignKey("dbo.SubmissionAnswers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
