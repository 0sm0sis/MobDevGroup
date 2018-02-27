using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Models.Characters;

namespace TerminalCharacter.Models.Characters.Monsters
{
    class MonsterController : ICharacterController<Monster>
    {
        
        // Uses brute force attack
        // Equivalent of physical attack in most dungeon crawlers
        public int BruteForceAttack(Monster monster)
        {
            if(monster.Stats.SystemStatus.Equals("Dead")) {
                return 0;
            }
            var BaseDamage = monster.Level;
            var Scalar = monster.Stats.ProcessingPower;
            
            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            var DamageOutput = ((BaseDamage * Scalar) * Luck);

            // calculate damage based on level of monster
            return DamageOutput;
        }

        // uses program
        // equivalent of magic in most dungeon crawlers
        public int UseProgram(Monster monster)
        {
            var BaseDamage = monster.Level;
            var Scalar = monster.Stats.UploadBandwidth;


            Random rando = new Random();
            int Luck = rando.Next(0, 12);
            //var ExtraDmg = BaseDamage + Luck;
            var DamageOutput = ((BaseDamage * Scalar) * Luck);
            
            // calculate damage based on level of monster
            return DamageOutput;
        }

        // Applies the given damage to the given monster
        // returns amount of experience given to attacker
        public int TakeDamage(Monster monster, int damage, int damType)
        {
            double defense;
            int FinalDamage;
            // brute force
            if (damType == 0) {
                defense = monster.Stats.FireWallStrength;
            }
            else {
                defense = monster.Stats.AntivirusStrength;
            }
            defense *= .01;
            int DamageBlocked = (int)Math.Ceiling(defense * damage);
            if (DamageBlocked >= damage) {
                FinalDamage = 1;
            }
            else {
                FinalDamage = damage - DamageBlocked;
            }
            monster.Stats.DataIntegrity -= FinalDamage;
            if (monster.Stats.DataIntegrity <= 0) {
                monster.Stats.SystemStatus = CharacterStatus.Dead;
            }
            return FinalDamage;
        }

        // Drops all Items on Monster
        // Must pass in monster 
        public List<Item> DropItem(Monster monster)
        {
            return new List<Item>();
        }

    }
}
