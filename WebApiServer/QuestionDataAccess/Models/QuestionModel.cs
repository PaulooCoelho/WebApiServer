using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDataAccess.Models
{
    /// <summary>
    /// This class was created to simulate a table model in order to test the API without a real database connection.
    /// It's deprecated now since the connections were already made with sql server.
    /// </summary>
    public class QuestionModel
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public DateTime Published_at { get; set; }
        public List<ChoiceModel> Choices { get; set; }

        public QuestionModel()
        { }

        public QuestionModel(int id, string question, string image_url, string thumb_url, DateTime published_at, List<ChoiceModel> choices)
        {
            this.ID = id;
            this.Question = question;
            this.Image_url = image_url;
            this.Thumb_url = thumb_url;
            this.Published_at = published_at;
            this.Choices = choices;
        }
    }
}
