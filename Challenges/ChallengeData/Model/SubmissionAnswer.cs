namespace ChallengeData.Model
{
    using System.ComponentModel.DataAnnotations;

    public class SubmissionAnswer
    {
        [Key]
        public long Id { get; set; }

        public long SubmissionId { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public string Value { get; set; }
    }
}
