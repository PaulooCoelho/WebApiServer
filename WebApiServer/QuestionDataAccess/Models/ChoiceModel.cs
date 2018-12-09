using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This class was created to simulate a table model in order to test the API without a real database connection.
/// It's deprecated now since the connections were already made with sql server.
/// </summary>
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
