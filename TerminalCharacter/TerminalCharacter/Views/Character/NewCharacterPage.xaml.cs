using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TerminalCharacter.Models;


namespace TerminalCharacter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCharacterPage : ContentPage
    {
        public Player Data { get; set; }

        public NewCharacterPage()
        {
            InitializeComponent();

            Data = new Player
            {
                Name = "Character Name",
                Description = "This is a Character description.",
                Id = Guid.NewGuid().ToString()
            };

            BindingContext = this;
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddData", Data);
            await Navigation.PopAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}