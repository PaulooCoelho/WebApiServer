using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiServer.Services;
using WebApiServer.ViewModels;

namespace WebApiServer.WebApiControllers
{
    /// <summary>
    /// Web Api Controller with Gets, Posts and Puts endpoints.
    /// This web api controller will handle the issues requested by the client.
    /// </summary>
    public class ServerAPIController : ApiController
    {
        private ILog log = LogManager.GetLogger(typeof(ServerAPIController));
        private QuestionService questionService = new QuestionService();

        #region GETS

        /// <summary>
        /// Check server's status (online/offline) returning an "OK" as message.
        /// </summary>
        /// <returns></returns>
        [Route("api/health")]
        [HttpGet]
        public HttpResponseMessage GetHealth()
        {
            log.Info("Checking server status: Online");
            Request.Content.Headers.Add("Content-Type", "application/json");
            return Request.CreateResponse(HttpStatusCode.OK, "status : OK");
        }

        /// <summary>
        /// Get a list of all questions and its respective choices of answers.
        /// </summary>
        /// <param name="limit">The number of records to retrieve.</param>
        /// <param name="offset">0 Based starting index of the first retrieved record. If you invoked with limit=5 then you should use offset=5 to obtain the next records. If you asked for 5 but only got 4 e.g., that means there are no more records to show.</param>
        /// <param name="filter">Use this field to search for the filter pattern on "question" and "choice" properties. The search will perfom a "lowercase contains" strategy on those fields to retrieve results.</param>
        /// <returns></returns>
        [Route("api/questions")]
        [HttpGet]
        public HttpResponseMessage GetQuestions(int limit = 0, int offset = 0, string filter = "")
        {
            if (limit < 0 || offset < 0 || filter == null)
            {
                var errorMessage = "Bad Request: limit[" + limit + "]; offset[" + offset + "]; filter[" + filter + "]; Expected: limit[>=0]; offset[>=0]; limit[!= null];";
                log.Error(errorMessage);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            }

            log.Info("Retrieving questions: limit[" + limit + "]; offset[" + offset + "]; filter[" + filter + "]");
            var viewModelList = questionService.GetQuestions(limit, offset, filter);
            return Request.CreateResponse(HttpStatusCode.OK, viewModelList);
        }

        /// <summary>
        /// Get a question by id.
        /// </summary>
        /// <param name="question_id">Id of the question to retrieve.</param>
        /// <returns></returns>
        [Route("api/questions/{question_id}")]
        [HttpGet]
        public HttpResponseMessage GetQuestion(int question_id)
        {
            if (question_id < 0)
            {
                var errorMessage = "Bad Request: question_id[" + question_id + "]; Expected: question_id[>=0];";
                log.Error(errorMessage);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
            }
            else if (!questionService.Exists(question_id))
            {
                var errorMessage = "Not Found: There is no question with the id[" + question_id + "].";
                log.Error(errorMessage);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, errorMessage);
            }

            log.Info("Retrieving question: question_id[" + question_id + "]");
            var viewModelList = questionService.GetQuestion(question_id);
            return Request.CreateResponse(HttpStatusCode.OK, viewModelList);
        }

        #endregion GETS

        #region POSTS

        /// <summary>
        /// Creates a new question given the properties. It takes a JSON object containing a question and a collection of answers in the form of choices.
        /// </summary>
        /// <param name="question">JSON Object with all properties to create the new question.</param>
        /// <returns></returns>
        [Route("api/questions")]
        [HttpPost]
        public HttpResponseMessage PostQuestion([FromBody] QuestionViewModel question)
        {
            if (question.GetType().GetProperties().Any(x => x.GetValue(question) == null))
            {
                log.Error("Bad Request: JSON Object passed by params is invalid!");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request. All fields are mandatory.");
            }

            log.Info("New question has been created!");
            question = questionService.CreateQuestion(question);
            return Request.CreateResponse(HttpStatusCode.Created, question);
        }

        /// <summary>
        /// Share the content url via email address.
        /// </summary>
        /// <param name="destination_email">The recipient of the email.</param>
        /// <param name="content_url">The URL to be sent via email.</param>
        /// <returns></returns>
        [Route("api/questions/share")]
        [HttpPost]
        public HttpResponseMessage PostShare(string destination_email, string content_url)
        {
            if (!questionService.IsValidEmail(destination_email) || String.IsNullOrEmpty(content_url))
            {
                log.Error("Bad Request: destination_email[" + destination_email + "]; content_url[" + content_url + "]");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request. Either destination_email not valid or empty content_url.");
            }

            log.Info("URL has been sent to destination_email[" + destination_email + "]");
            return Request.CreateResponse(HttpStatusCode.OK, "status : OK");
        }

        #endregion POSTS

        #region PUTS

        /// <summary>
        /// Updates an existing question . It takes a JSON object containing a question and aa collection of answers in the form of choices.
        /// </summary>
        /// <param name="question">JSON Object with all the properties to update the question.</param>
        /// <returns></returns>
        [Route("api/questions")]
        [HttpPut]
        public HttpResponseMessage PutQuestion([FromBody] QuestionViewModel question)
        {
            if (question.GetType().GetProperties().Any(x => x.GetValue(question) == null))
            {
                log.Error("Bad Request: JSON Object passed by params is invalid!");
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request. All fields are mandatory.");
            }
            else if (!questionService.Exists(question.ID))
            {
                log.Error("Bad Request: question id[" + question.ID + "] does not exists.");
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no question with the id[" + question.ID + "].");
            }

            log.Info("Question with the id[" + question.ID + "] has been updated!");
            questionService.EditQuestion(question);
            return Request.CreateResponse(HttpStatusCode.Created, question);
        }

        #endregion PUTS
    }
}
