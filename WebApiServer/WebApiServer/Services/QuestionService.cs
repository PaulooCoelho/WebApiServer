using log4net;
using QuestionDataAccess;
using QuestionDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiServer.Repositories;
using WebApiServer.ViewModels;

namespace WebApiServer.Services
{
    public class QuestionService
    {
        private ILog log = LogManager.GetLogger(typeof(QuestionService));
        private QuestionRepository questionRepository = new QuestionRepository();
        public IEnumerable<QuestionViewModel> GetQuestions(int limit, int offset, string filter)
        {
            try
            {
                if (limit == 0)
                    limit = questionRepository.GetTotal();

                var questionsList = new List<QuestionViewModel>();
                var modelList = questionRepository.GetQuestions(limit, offset, filter.ToLower());

                foreach (var model in modelList)
                {
                    var question = new QuestionViewModel();

                    question.ID = model.ID;
                    question.Question = model.Question;
                    question.Image_url = model.Image_url;
                    question.Thumb_url = model.Thumb_url;
                    question.Published_at = model.Published_at;

                    foreach (var item in model.TChoices.ToList())
                        question.Choices.Add(new ChoiceModel(item.Choice, item.Votes));

                    questionsList.Add(question);
                }

                return questionsList;
            }
            catch (Exception exception)
            {
                return new List<QuestionViewModel>();
            }
        }

        public QuestionViewModel GetQuestion(int id)
        {
            try
            {
                return MapEntityToViewModel(questionRepository.GetQuestion(id));
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
                questionRepository.CreateQuestion(MapViewModelToEntity(question));
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
                questionRepository.EditQuestion(MapViewModelToEntity(viewModel));
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
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch(Exception exception)
            {
                log.Error(exception);
                return false;
            }
        }

        private TQuestion MapViewModelToEntity(QuestionViewModel viewModel)
        {
            try
            {
                var entity = new TQuestion();

                if (viewModel != null)
                {
                    entity.ID = viewModel.ID;
                    entity.Question = viewModel.Question;
                    entity.Image_url = viewModel.Image_url;
                    entity.Thumb_url = viewModel.Thumb_url;
                    entity.Published_at = viewModel.Published_at;

                    foreach (var item in viewModel.Choices.ToList())
                        entity.TChoices.Add(new TChoice() { FK_TQuestion_ID = entity.ID, Choice = item.Choice, Votes = item.Votes });
                }

                return entity;
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new TQuestion();
            }
        }

        private QuestionViewModel MapEntityToViewModel(TQuestion entity)
        {
            try
            {
                var viewModel = new QuestionViewModel();

                if (entity != null)
                {
                    viewModel.ID = entity.ID;
                    viewModel.Question = entity.Question;
                    viewModel.Image_url = entity.Image_url;
                    viewModel.Thumb_url = entity.Thumb_url;
                    viewModel.Published_at = entity.Published_at;

                    foreach (var item in entity.TChoices.ToList())
                        viewModel.Choices.Add(new ChoiceModel(item.Choice, item.Votes));

                }

                return viewModel;
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new QuestionViewModel();
            }
        }
    }
}