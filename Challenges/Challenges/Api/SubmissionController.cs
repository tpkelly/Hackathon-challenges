namespace Challenges.Api
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ChallengeData.Context;
    using ChallengeData.Model;
    using System.Web.Http.ModelBinding;

    public class SubmissionController : ApiController
    {
        private readonly IContextFactory _contextFactory;

        public SubmissionController(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        [HttpPost]
        public void Post(Submission submission)
        {
            if (submission == null)
            {
                ThrowError(HttpStatusCode.BadRequest, "Submission is required");
            }

            if (!ModelState.IsValid)
            {
                ThrowError(HttpStatusCode.BadRequest, ModelState);
            }

            using (var context = _contextFactory.CreateContext())
            {
                var answerDict = context.Answers
                    .Include(a => a.Question)
                    .ToDictionary(a => a.QuestionId);

                // Grade the submission
                submission.Funds = 0;
                submission.TimeStamp = DateTime.UtcNow;
                context.Submissions.Add(submission);
                context.SaveChanges();

                foreach (var submissionAnswer in submission.Answers)
                {
                    var answer = answerDict[submissionAnswer.QuestionId];
                    if (answer.Value.Equals(submissionAnswer.Value))
                    {
                        submission.Funds += answer.Question.Reward;
                    }

                    submissionAnswer.SubmissionId = submission.Id;
                    context.SubmissionAnswers.Add(submissionAnswer);
                }

                context.SaveChanges();
            }
        }

        private void ThrowError(HttpStatusCode statusCode, string message = null)
        {
            var httpResponseMessage = new HttpResponseMessage(statusCode);
            if (!string.IsNullOrWhiteSpace(message))
            {
                httpResponseMessage.ReasonPhrase = message;
            }

            HttpResponseException exception = new HttpResponseException(httpResponseMessage);

            throw exception;
        }

        public void ThrowError(HttpStatusCode statusCode, ModelStateDictionary modelState)
        {
            throw new HttpResponseException(Request.CreateErrorResponse(statusCode, modelState));
        }
    }
}