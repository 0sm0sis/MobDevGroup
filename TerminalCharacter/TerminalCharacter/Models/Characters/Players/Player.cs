using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TerminalCharacter.Models.Characters;
using SQLite;

namespace TerminalCharacter.Models
{
    
    public enum CharacterType
    {
        Unknown = 0,
        DDos = 1,
        TrojanHorse = 2,
        InternalProcess = 3,
        EmbeddedSystem = 4,
        Worm = 5
    }
    public class Player  : ICharacter
    {
        [PrimaryKey]
        public string Id { get; set; }
        // Name of the player
        public string Name { get; set; }
        // description of the player
        public string Description { get; set; }
        // level of the player
        public int Level { get; set; }
        // specify what type the character is
        public CharacterType PlayerType { get; set; }
        // how much experince points the player has
        public int CurrentExp { get; set; }
        // how many experience points needed for the next level
        public int NextLevel { get; set; }

        // this class holds the player's inventory, hold a reference to its ID to put in database
        public int InventoryID { get; set; }
        [Ignore]
        public Inventory Items { get; set; }
        // this class holds all the player's attributes, hold a reference to its ID to put in database
        [Ignore]
        public Attributes Stats { get; set; }
        public int StatsID { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // update the players data
        public void Update(Player newData)
        {
            if (newData == null)
            {
                return;
            }

            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
        }


    }

}
