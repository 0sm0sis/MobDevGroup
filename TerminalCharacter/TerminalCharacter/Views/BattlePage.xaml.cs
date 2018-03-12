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
using TerminalCharacter.ViewModels;

namespace TerminalCharacter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattlePage : ContentPage
	{
        public BattleController ctrl;
        private BattleViewModel battleViewModel;
        
        public Player p1;
        public Monster myMon1;

        public BattlePage()
        {
            ctrl = new BattleController();
            battleViewModel = new BattleViewModel(ctrl);
            InitializeComponent();
            BindingContext = battleViewModel;
        }

        void StartClick(object sender, EventArgs e)
        {
            ctrl.BeginBattle(battleViewModel.StartingPlayers);
        }
    }
}