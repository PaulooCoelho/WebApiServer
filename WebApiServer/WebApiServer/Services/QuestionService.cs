using log4net;
using QuestionDataAccess;
using QuestionDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApiServer.Helpers;
using WebApiServer.Repositories;
using WebApiServer.ViewModels;

namespace WebApiServer.Services
{
    /// <summary>
    /// This class represents the business layer. It is here where all the logic is done.
    /// When the client issues a request, the api calls the respective method from this class, passing all the information needed. 
    /// The called method (here in this class) works on the data and returns the values to the api.
    /// </summary>
    public class QuestionService
    {
        private Mapper map = new Mapper();
        private ILog log = LogManager.GetLogger(typeof(QuestionService));
        private QuestionRepository questionRepository = new QuestionRepository();

        public IEnumerable<QuestionViewModel> GetQuestions(int limit, int offset, string filter)
        {
            try
            {
                if (limit == 0)
                    limit = questionRepository.GetTotal();

                var modelList = questionRepository.GetQuestions(limit, offset, filter.ToLower());
                var questionsList = map.EntityIEnumerableToViewModelList(modelList);
            
                return questionsList;
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new List<QuestionViewModel>();
            }
        }

        public QuestionViewModel GetQuestion(int id)
        {
            try
            {
                return map.EntityToViewModel(questionRepository.GetQuestion(id));
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new QuestionViewModel();
            }
        }

        public void CreateQuestion(QuestionViewModel question)
        {
            try
            {
                questionRepository.CreateQuestion(map.ViewModelToEntity(question));
            }
            catch (Exception exception)
            {
                log.Error(exception);
            }
        }

        public void EditQuestion(QuestionViewModel viewModel)
        {
            try
            {
                questionRepository.EditQuestion(map.ViewModelToEntity(viewModel));
            }
            catch (Exception exception)
            {
                log.Error(exception);
            }
        }

        public bool Exists(int question_id)
        {
            try
            {
                return questionRepository.Exists(question_id);
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch(Exception exception)
            {
                log.Error(exception);
                return false;
            }
        }
    }
}