namespace ChallengeData.Context
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Model;

    public interface IDataContext : IDisposable
    {
        IDbSet<Submission> Submissions { get; set; }
        IDbSet<SubmissionAnswer> SubmissionAnswers { get; set; }
        IDbSet<Question> Questions { get; }
        IDbSet<Answer> Answers { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
