using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCharacter.Models.Characters
{
    public enum CharacterStatus { Alive, Dead };

    public class Attributes
    {
        // Whether player is alive or dead
        public CharacterStatus SystemStatus { get; set; }
        // level of the player
        public int CharacterLevel { get; set; }
        // Maximum Health
        public int OptimalDataIntegrity { get; set; }
        // Current Health
        public int DataIntegrity { get; set; }
        // Attack strength
        public int ProcessingPower { get; set; }
        // Defense
        public int FireWallStrength { get; set; }
        // Speed
        public int ProcessorSpeed { get; set; }
        // Mana
        public int PhysicalMemory { get; set; }
        // Magic Attack
        public int UploadBandwidth { get; set; }
        // Magic Defense
        public int AntivirusStrength { get; set; }
    }
}
