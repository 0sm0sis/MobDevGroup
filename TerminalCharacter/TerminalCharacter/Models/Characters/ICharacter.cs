using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Models.Characters;

namespace TerminalCharacter.Models
{
    public class ICharacter
    {
        // the type of character
        public CharacterType PlayerType;
        // the stats of the character
        public Attributes Stats;
        // the name of the character
        public String Name;
        // the level of the character
        public int Level;
        // the description of the character
        public String Description;
    }
}
