using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalCharacter.Models.Characters.Players
{
    class PlayerController : ICharacterController<Player>
    {
        // increases experience, checks if character has leveled up
        public void IncreaseExperience(int newExp, Player userCharacter)
        {
            userCharacter.CurrentExp += newExp;
            if (userCharacter.CurrentExp >= userCharacter.NextLevel) {
                userCharacter.CurrentExp -= userCharacter.NextLevel;
                LevelUp(userCharacter);
            }

        }
                

        // levels up character
        public void LevelUp(Player userCharacter)
        {
            if (userCharacter.Stats.CharacterLevel < 20)
                ++userCharacter.Stats.CharacterLevel;
            // handle stat increases here
        }

        // Uses brute force attack
        // Equivalent of physical attack in most dungeon crawlers
        public int BruteForceAttack(Player userCharacter)
        {
            if (userCharacter.Stats.SystemStatus.Equals("Dead")) {
                return 0;
            }
            var BaseDamage = userCharacter.Level;
            int Scalar = (int)userCharacter.Stats.ProcessingPower;

            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            int DamageOutput = ((BaseDamage * Scalar) * Luck);

            // calculate damage based on level of monster
            return DamageOutput;
        }
        // uses program
        // equivalent of magic in most dungeon crawlers
        public int UseProgram(Player userCharacter)
        {
            var BaseDamage = userCharacter.Level;
            var Scalar = (int)userCharacter.Stats.UploadBandwidth;


            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            var DamageOutput = ((BaseDamage * Scalar) * Luck);

            // calculate damage based on level of monster
            return DamageOutput;
        }
        // applies damage to the given character
        // returns 0 if still alive, -1 if the character died
        public int TakeDamage(Player userCharacter, int damage, int damType)
        {
            double defense;
            int FinalDamage;
            // brute force
            if (damType == 0) {
                defense = userCharacter.Stats.FireWallStrength;
            }
            else {
                defense = userCharacter.Stats.AntivirusStrength;
            }
            defense *= .01;
            int DamageBlocked = (int)Math.Ceiling(defense * damage);
            if(DamageBlocked >= damage) {
                FinalDamage = 1;
            }
            else {
                FinalDamage = damage - DamageBlocked;
            }
            userCharacter.Stats.DataIntegrity -= FinalDamage;
            if(userCharacter.Stats.DataIntegrity <= 0) {
                userCharacter.Stats.SystemStatus = CharacterStatus.Dead;
            }
            return FinalDamage;
        }

       

        // Equips Item on Character
        // takes must pass in Item and Player
        public bool EquipItem(Player userCharacter, Item equipment)
        {
            return true;
        }

        // Drops all Items on Character
        // Must pass in character 
        public List<Item> DropItem(Player userCharacter)
        {
            return new List<Item>();
        }
    }
}
