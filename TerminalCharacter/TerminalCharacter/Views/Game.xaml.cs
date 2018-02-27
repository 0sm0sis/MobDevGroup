using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TerminalCharacter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Game : ContentPage
	{
		public Game ()
		{
			InitializeComponent ();
		}
        async void OpenScore(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoresPage());
        }
        async void OpenCharacters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }
        async void OpenInventory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inventory());
        }
        async void OpenMonsters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MonstersPage());
        }
        async void OpenItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }
        async void OpenBattle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Battle());
        }

    }
}