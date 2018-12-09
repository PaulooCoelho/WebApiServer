using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionDataAccess;
using QuestionDataAccess.Models;
using System.Data.Entity;
using log4net;

namespace WebApiServer.Repositories
{
    /// <summary>
    /// This class represents the database communication layer. It is here where all the communication with the sql server database is done.
    /// When the service layer needs data to work with, calls the respective method from this class, passing all the information needed. 
    /// The called method (here in this class) works on the data and returns the values to the service.
    /// </summary>
    public class QuestionRepository
    {
        private ILog log = LogManager.GetLogger(typeof(QuestionRepository));

        public int GetTotal()
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    return dbContext.TQuestions.Count();
                }
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return -1;
            }
        }

        public IEnumerable<TQuestion> GetQuestions(int limit, int offset, string filter)
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    return dbContext.TQuestions.Include(x => x.TChoices)
                        .Where(x => x.Question.ToLower().Contains(filter) || x.TChoices.Any(y => y.Choice.ToLower().Contains(filter)))
                        .OrderBy(x => x.ID).Skip(offset).Take(limit).ToList();
                }
            }
            catch (Exception exception)
            {
                return new List<TQuestion>();
            }
        }

        public TQuestion GetQuestion(int id)
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    return dbContext.TQuestions.Include(x => x.TChoices).SingleOrDefault(x => x.ID == id);
                }
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return new TQuestion();
            }
        }

        public int CreateQuestion(TQuestion model)
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    dbContext.TQuestions.Add(model);
                    dbContext.SaveChanges();

                    return model.ID;
                }
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return -1;
            }
        }

        public void EditQuestion(TQuestion model)
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    var modelToUpdate = dbContext.TQuestions.Include(x => x.TChoices).SingleOrDefault(x => x.ID == model.ID);

                    modelToUpdate.Question = model.Question;
                    modelToUpdate.Image_url = model.Image_url;
                    modelToUpdate.Thumb_url = model.Thumb_url;
                    modelToUpdate.Published_at = model.Published_at;

                    var index = Math.Min(model.TChoices.Count(), modelToUpdate.TChoices.Count());
                    for (int i = 0; i < index; i++)
                    {
                        modelToUpdate.TChoices.ElementAt(i).Choice = model.TChoices.ElementAt(i).Choice;
                        modelToUpdate.TChoices.ElementAt(i).Votes = model.TChoices.ElementAt(i).Votes;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                log.Error(exception);
            }
        }

        public bool Exists(int id)
        {
            try
            {
                using (var dbContext = new QuestionsDBEntities())
                {
                    return dbContext.TQuestions.Any(x => x.ID == id);
                }
            }
            catch (Exception exception)
            {
                log.Error(exception);
                return false;
            }
        }
    }
}