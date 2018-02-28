using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TerminalCharacter.Models.Characters;
using SQLite;

namespace TerminalCharacter.Models
{
    public class Monster : ICharacter
    {
        [PrimaryKey]
        public string Id { get; set; }
        
        //// total amount of experience given
        //public int MaxExp { get; set; }
        //// amount of experience remaining to be given out
        //public int RemainingExp { get; set; }

        // this is the item that will always be dropped by the monster when killed
        [Ignore]
        public Item Drops { get; set; }
        // hold a reference to its ID to put in database
        public int DropsId { get; set; }
        // the unique item drop for this monster, if it has one
        [Ignore]
        public Item UniqueDrop { get; set; }
        // hold a reference to its ID to put in database
        public int UniqueDropId { get; set; }

        public Monster()
        {
            Name = "New Monster";
            Description = "A newly created default monster.";
            PlayerType = CharacterType.Unknown;
            Stats = new Attributes();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // update the monster with new data
        public void Update(Monster newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            Description = newData.Description;
        }

    }
}
