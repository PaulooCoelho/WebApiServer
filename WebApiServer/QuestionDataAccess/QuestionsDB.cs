using QuestionDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDataAccess
{
    /// <summary>
    /// This class was created to simulate a database in order to test the API without a real database connection. 
    /// It's deprecated now since the connections were already made with sql server.
    /// </summary>
    public class QuestionsDB : IDisposable
    {
        public static List<QuestionModel> QuestionsEntities = new List<QuestionModel>()
        {
            new QuestionModel(1,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(2,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(3,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(4,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

           new QuestionModel(5,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

           new QuestionModel(6,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

           new QuestionModel(7,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(8,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(9,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),

            new QuestionModel(10,
                "Favourite programming language?",
                "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                DateTime.Parse("2015-08-05T08:40:51.620Z"),
                new List<ChoiceModel>() {
                    new ChoiceModel("Swift", 2048),
                    new ChoiceModel("Python", 1024),
                    new ChoiceModel("Objective-C", 512),
                    new ChoiceModel("Ruby", 256)
                }),
        };

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
        }
    }
}
