using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TerminalCharacter.Models.Characters
{
    public class Inventory
    {
        // This class contains the worn items for a player

        [PrimaryKey]
        public int ID { get; set; }
        // item in the head slot
        public Item Head { get; set; }
        // item in the left hand slot
        public Item LeftHand { get; set; }
        // item in the right hand slot
        public Item RightHand { get; set; }
        // item in the left ring slot
        public Item LeftRing { get; set; }
        // item in the right right slot
        public Item RightRing { get; set; }
        // item in the feet slot
        public Item Feet { get; set; }
    }
}
