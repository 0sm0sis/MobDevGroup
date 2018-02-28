using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerminalCharacter.Models;
using Xamarin.Forms;
using TerminalCharacter.Models.Characters;
using TerminalCharacter.Services;
using Xamarin.Forms.Xaml;

namespace TerminalCharacter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Battle : ContentPage
	{
        public BattleController ctrl = new BattleController();
        public List<Player> players = new List<Player>();
        public Player p1;
        public Monster myMon1;

		public Battle ()
		{
            //var p1 = new Player { Id = Guid.NewGuid().ToString(), Name = "First Character", Description = "This is an Character description.", Level = 1 };
            //var p2 = new Player { Id = Guid.NewGuid().ToString(), Name = "Second Character", Description = "This is an Character description.", Level = 1 };
            //var p3 = new Player { Id = Guid.NewGuid().ToString(), Name = "Third Character", Description = "This is an Character description.", Level = 2 };
            //var p4 = new Player { Id = Guid.NewGuid().ToString(), Name = "Fourth Character", Description = "This is an Character description.", Level = 2 };
            p1 = new Player();
            p1.Stats = new Attributes();
            p1.Level = 2;
            p1.Name = "Player";
            p1.Stats.DataIntegrity = 100;
            p1.Stats.ProcessorSpeed = 3;
            p1.Stats.AntivirusStrength = 5;
            p1.Stats.FireWallStrength = 10;
            p1.Stats.PhysicalMemory = 10;
            p1.Stats.SystemStatus = CharacterStatus.Alive;
            p1.Stats.UploadBandwidth = 10;
            players.Add(p1);

            myMon1 = new Monster();
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
            var MonsterHealth = myMon1.Stats.DataIntegrity;
            InitializeComponent();

        }

        void StartClick(object sender, EventArgs e)
        {
            ctrl.BeginBattle(players);
            var health = myMon1.Stats.OptimalDataIntegrity;
        }
    }
}