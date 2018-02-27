using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Services;

namespace TerminalCharacter.Models
{
    public class Battle
    {
        
        // array of monsters in the fight
        public List<Monster>Monsters { get; set; }
        // array of players in the fight
        public List<Player>Players { get; set; }

        // score object to hold the score of the game
        public Score GameScore { get; set; }

        // the turn order for all characters in the battle
        public List<ICharacter> TurnOrder { get; set; }

        // the character whos turn it is
        public ICharacter NextUp { get; set; }

        // items that dropped during the battle
        public List<Item> Items { get; set; }

        // returns whether the battle is over or not
        bool BattleOver { get; set; }




    }
}
