using log4net;
using QuestionDataAccess;
using QuestionDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiServer.ViewModels;

namespace WebApiServer.Helpers
{
    /// <summary>
    /// This simple class intent is only to map the properties from view model to model and vice versa.
    /// </summary>
    public class Mapper
    {
        private ILog log = LogManager.GetLogger(typeof(Mapper));

        public TQuestion ViewModelToEntity(QuestionViewModel viewModel)
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

        public QuestionViewModel EntityToViewModel(TQuestion entity)
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

        public List<QuestionViewModel> EntityIEnumerableToViewModelList(IEnumerable<TQuestion> entityList)
        {
            try
            {
                var questionsList = new List<QuestionViewModel>();

                foreach (var entity in entityList)
                {
                    var question = new QuestionViewModel();

                    question.ID = entity.ID;
                    question.Question = entity.Question;
                    question.Image_url = entity.Image_url;
                    question.Thumb_url = entity.Thumb_url;
                    question.Published_at = entity.Published_at;

                    foreach (var item in entity.TChoices.ToList())
                        question.Choices.Add(new ChoiceModel(item.Choice, item.Votes));

                    questionsList.Add(question);
                }

                return questionsList;
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new List<QuestionViewModel>();
            }
        }
    }
}