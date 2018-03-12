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
        
        public List<Player> Players = new List<Player>();
        public List<Monster> Monsters = new List<Monster>();
        ICharacter[] OrderList = new ICharacter[5];
        bool gameOver = false;
        int currentAttacker = 0;

        public BattleController()
        {
            GetMonsters();

            
            // since crudi not working rn :(
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            var player4 = new Player();
            var player5 = new Player();
            var player6 = new Player();
            player1.Name = "Player1";
            player2.Name = "Player2";
            player3.Name = "Player3";
            player4.Name = "Player4";
            player5.Name = "Player5";
            player6.Name = "Player6";
            Players.Add(player1);
            Players.Add(player2);
            Players.Add(player3);
            Players.Add(player4);
            Players.Add(player5);
            Players.Add(player6);
        }

        // Begin Game with the given players and monsters
        public void BeginBattle(List<Player> players)
        {

            // next two lines just basically hack mock data into something that can use linq queries

            // crdui not working so temp change here
            // Players = players;


            //BattleModel = new Battle {
            //    Monsters = GetMonsters(),
            //    Players = players,

            //};
            StartNextRound();
        }

        public void GetMonsters()
        {
            var myMon1 = new Monster();
            var myMon2 = new Monster();
            var myMon3 = new Monster();
            var myMon4 = new Monster();
            var myMon5 = new Monster();
            var myMon6 = new Monster();
            myMon1.Name = "Monster1";
            myMon2.Name = "Monster2";
            myMon3.Name = "Monster3";
            myMon4.Name = "Monster4";
            myMon5.Name = "Monster5";
            myMon6.Name = "Monster6";
            Monsters.Add(myMon1);
            Monsters.Add(myMon2);
            Monsters.Add(myMon3);
            Monsters.Add(myMon4);
            Monsters.Add(myMon5);
            Monsters.Add(myMon6);
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
