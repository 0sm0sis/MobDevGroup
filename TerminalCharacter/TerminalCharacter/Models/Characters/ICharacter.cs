using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Models.Characters;

namespace TerminalCharacter.Models
{
    public class ICharacter : ICharacterController<ICharacter>
    {
        // the type of character
        public CharacterType PlayerType;
        // the character.Stats of the character
        public Attributes Stats = new Attributes();
        // the name of the character
        public String Name;
        // the level of the character
        public int Level;
        // the description of the character
        public String Description;

        public int BruteForceAttack(ICharacter character)
        {

            if (character.Stats.SystemStatus == CharacterStatus.Dead) {
                return 0;
            }
            var BaseDamage = Level;
            var Scalar = character.Stats.ProcessingPower;

            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            var DamageOutput = ((BaseDamage * Scalar) * Luck);

            // calculate damage based on level of monster
            return DamageOutput;
        }

        public List<Item> DropItem()
        {
            return null;   
        }

        public int TakeDamage(ICharacter character, int damage, int damType)
        {
            double defense;
            int FinalDamage;
            // brute force
            if (damType == 0) {
                defense = character.Stats.FireWallStrength;
            }
            else {
                defense = character.Stats.AntivirusStrength;
            }
            defense *= .01;
            int DamageBlocked = (int)Math.Ceiling(defense * damage);
            if (DamageBlocked >= damage) {
                FinalDamage = 1;
            }
            else {
                FinalDamage = damage - DamageBlocked;
            }
            character.Stats.DataIntegrity -= FinalDamage;
            if (character.Stats.DataIntegrity <= 0) {
                character.Stats.SystemStatus = CharacterStatus.Dead;
            }
            return FinalDamage;
        }

        public int UseProgram(ICharacter character)
        {
            var BaseDamage = Level;
            var Scalar = character.Stats.UploadBandwidth;


            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            var DamageOutput = ((BaseDamage * Scalar) * Luck);

            // calculate damage based on level of character
            return DamageOutput;
            throw new NotImplementedException();
        }
    }
}
