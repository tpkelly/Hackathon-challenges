using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeData.Context
{
    using System.Data.Entity;
    using Model;

    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
            : base("DataContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.UseDatabaseNullSemantics = true;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Submission> Submissions { get; set; } 
        public IDbSet<SubmissionAnswer> SubmissionAnswers { get; set; } 
        public IDbSet<Question> Questions { get; } 
        public IDbSet<Answer> Answers { get; }
    }
}
