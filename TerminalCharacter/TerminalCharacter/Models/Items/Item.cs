using System;
using SQLite;

namespace TerminalCharacter.Models
{
    // enum to hold the location of the item
    public enum ItemLocations
        {
            Unknown = 0,
            Head = 1,
            LeftHand = 2,
            RightHand = 3,
            LeftRight = 4,
            RightRight = 5,
            Feet = 6
        }
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; }
        // the name of the item
        public string Name { get; set; }
        // Where the item is worn
        public ItemLocations Location { get; set; }
        // the attribute that the item will boost
        public String Attribute { get; set; }
        // the amount to boost the attribute
        public int Value { get; set; }
        // item description
        public String Description { get; set; }

        // update the item data
        public void Update(Item newData)
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