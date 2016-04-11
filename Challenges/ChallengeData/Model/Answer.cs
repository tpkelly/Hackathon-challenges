namespace ChallengeData.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Answer
    {
        [Key]
        public long Id { get; set; }

        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public string Value { get; set; }
    }
}
