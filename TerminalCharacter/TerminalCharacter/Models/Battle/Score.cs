using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TerminalCharacter.Models
{
    public class Score
    {
        [PrimaryKey]
        public string Id { get; set; }
        // the name of this score
        public string Name { get; set; }
        // the total score
        public int ScoreTotal { get; set; }

        // other stats to keep track of

        // number of turns taken in the game
        public int Turns { get; set; }
        // number of monsters killed in the game
        public int MonstersKilled { get; set; }
        // total experience gained in the game
        public int ExperienceGained { get; set; }
        // list of all the items dropped in the game (string for now for database purposes
        [Ignore]
        public String ItemsDropped { get; set; }
        // flag for if score is for an auto battle or not
        public bool AutoBattle { get; set; }
        // day the score is from
        public DateTime Date { get; set; }

        // update the score's data
        public void Update(Score newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            ScoreTotal = ScoreTotal;
        }

    }
}
