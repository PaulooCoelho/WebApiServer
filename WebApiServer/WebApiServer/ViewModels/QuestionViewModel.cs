using QuestionDataAccess;
using QuestionDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServer.ViewModels
{
    public class QuestionViewModel
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Image_url { get; set; }
        public string Thumb_url { get; set; }
        public DateTime Published_at { get; set; }
        public List<ChoiceModel> Choices { get; set; }

        public QuestionViewModel()
        {
            Choices = new List<ChoiceModel>();
        }
    }
}