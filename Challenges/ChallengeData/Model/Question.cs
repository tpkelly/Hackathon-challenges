namespace ChallengeData.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        [Key]
        public long Id { get; set; }

        public string QuestionNo { get; set; }

        public int Reward { get; set; }
    }
}
