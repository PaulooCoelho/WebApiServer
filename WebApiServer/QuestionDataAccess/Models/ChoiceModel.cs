using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionDataAccess.Models
{
    public class ChoiceModel
    {
        public string Choice { get; set; }
        public int Votes { get; set; }

        public ChoiceModel(string choice, int votes)
        {
            this.Choice = choice;
            this.Votes = votes;
        }
    }
}
