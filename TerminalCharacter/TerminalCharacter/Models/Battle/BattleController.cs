using System;
using System.Collections.Generic;
using System.Text;
using TerminalCharacter.Services;
using TerminalCharacter.Models.Characters;
using TerminalCharacter.Models.Characters.Monsters;
using TerminalCharacter.Models.Characters.Players;
using System.Linq;

namespace TerminalCharacter.Models
{
    public class BattleController
    {
        PlayerController ControllerPlayer = new PlayerController();
        MonsterController ControllerMonster = new MonsterController();
        

        static int MAX_MONSTERS = 4;
        // Battle model
        //Battle BattleModel;
        MockDataStore dbContext;
        
        List<Player> Players;
        List<Monster> Monsters = new List<Monster>();
        ICharacter[] OrderList = new ICharacter[5];
        bool gameOver = false;
        int currentAttacker = 0;
        // Begin Game with the given players and monsters
        public void BeginBattle(List<Player> players)
        {

            // next two lines just basically hack mock data into something that can use linq queries
            Players = players;
            //BattleModel = new Battle {
            //    Monsters = GetMonsters(),
            //    Players = players,

            //};
            GetMonsters();
            StartNextRound();
        }

        public void GetMonsters()
        {
            var myMon1 = new Monster();
            myMon1.Stats = new Attributes();
            myMon1.Level = 2;
            //myMon1.MaxExp = 5;
            myMon1.Name = "Monster";
            myMon1.Stats.DataIntegrity = 100;
            myMon1.Stats.ProcessorSpeed = 3;
            myMon1.Stats.AntivirusStrength = 5;
            myMon1.Stats.FireWallStrength = 10;
            myMon1.Stats.PhysicalMemory = 10;
            myMon1.Stats.SystemStatus = CharacterStatus.Alive;
            myMon1.Stats.UploadBandwidth = 10;
            Monsters.Add(myMon1);

        }

        // Manage beginning of a round
        public void StartNextRound()
        {

            // calculate turn order
            int index = 0;
            foreach(Monster mon in Monsters) {
                OrderList[index] = mon;
                index++;
            }
            foreach (Player p in Players) {
                OrderList[index] = p;
                index++;
            }
            OrderList.OrderByDescending(o => o.Stats.ProcessorSpeed)
                      .OrderByDescending(o => o.Stats.CharacterLevel);

            // everything else
            TurnManager();
        }

        // Manage the taking of each characters turns
        public void TurnManager()
        {
            Random rnd = new Random();

            // figure out target
            var MyTurn = OrderList[currentAttacker];
            var myType = MyTurn.GetType();
            ICharacter target;
            if(MyTurn.GetType() == typeof(Player)) {
                target = Monsters.Where(m => m.Stats.SystemStatus == CharacterStatus.Alive).FirstOrDefault();
            }
            else {
                target = Players.Where(m => m.Stats.SystemStatus == CharacterStatus.Alive).FirstOrDefault();
            }
            // attack
            Attack(MyTurn, target);
            // find next character up, or start next round or end game if needed
            var deadMonsters = Monsters.Where(m => m.Stats.SystemStatus == CharacterStatus.Dead).Count();
            var deadHeroes = Players.Where(p => p.Stats.SystemStatus == CharacterStatus.Dead).Count();
            if(deadHeroes == Players.Count) {
                EndGame();
                return;
            }
            if(deadMonsters == Monsters.Count) {
                currentAttacker++;
                TurnManager();
            }
        }

        // Attacks, Calculations, Damage

        // Have the attacker attack the target character
        // returns true if attack was successful, false otherwise.
        public bool Attack(ICharacter attacker, ICharacter target)
        {

            // find damage
            int damage = CalculateDamage(attacker, target);

            // apply damage
            int damageTaken = target.TakeDamage(target, damage, 0);
            // apply experience if player attacked
            if(attacker.GetType() == typeof(Player)) {
                int exp = (int)Math.Ceiling(damage * .01);
            }
            // check for death
            bool IsDead = CharacterKilled(target);
            return true;
        }
        // calculate whether the attacker hit the target or not
        private bool CalculateHit(ICharacter attacker, ICharacter target)
        {
            // calculate hit/miss
            return true;
        }
        // Calculate damage
        private int CalculateDamage(ICharacter attacker, ICharacter target)
        {
            var damOutput = attacker.BruteForceAttack(target);
            return damOutput;
        }

        // handle death of a character
        // return true if battle is over, false otherwise
        private bool CharacterKilled(ICharacter deceased)
        {
            if(deceased.Stats.SystemStatus == CharacterStatus.Dead) {
                return true;
            }

            return false;
        }

        // End Game
        public void EndGame()
        {
            // handle the end of the game here
            gameOver = true;
            // drop/manage items
        }

        // Auto Play
        public void AutoPlay()
        {
            // put code here to handle auto play
        }
    }
}
