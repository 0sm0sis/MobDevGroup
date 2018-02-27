using System;

using TerminalCharacter.Views;
using Xamarin.Forms;
using SQLite;

namespace TerminalCharacter
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();


            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        // database stuff
        static SQLiteAsyncConnection _database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("CRUDiDatabase.db3"));
                }
                return _database;
            }
        }

    }
}
