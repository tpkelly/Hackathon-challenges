namespace ChallengeData.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Funds { get; set; }

        public ICollection<SubmissionAnswer> Answers { get; set; }
    }
}
