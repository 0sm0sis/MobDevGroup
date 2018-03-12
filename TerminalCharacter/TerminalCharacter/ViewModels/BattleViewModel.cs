using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TerminalCharacter.Models;
using TerminalCharacter.Views;
using System.Linq;

namespace TerminalCharacter.ViewModels
{
    class BattleViewModel : BaseViewModel
    {
        public List<Player> StartingPlayers;
        public ObservableCollection<Player> CharacterDataset { get; set; }
        public ObservableCollection<Monster> MonsterDataset { get; set; }
        public Command LoadDataCommand { get; set; }
        public BattleController ctrl;

        private bool _needsRefresh;
        private bool first = true;

        public BattleViewModel(BattleController ctrl)
        {
            StartingPlayers = new List<Player>();
            this.ctrl = ctrl;
            Title = "Battle";
            CharacterDataset = new ObservableCollection<Player>();
            MonsterDataset = new ObservableCollection<Monster>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<BattlePage, Player>(this, "DeletePlayer", async (obj, data) =>
            {
                CharacterDataset.Remove(data);
            });

            MessagingCenter.Subscribe<BattlePage, Monster>(this, "DeleteMonster", async (obj, data) =>
            {
                MonsterDataset.Remove(data);
            });
        }

        // Return True if a refresh is needed
        // It sets the refresh flag to false
        public bool NeedsRefresh()
        {
            if (_needsRefresh)
            {
                _needsRefresh = false;
                return true;
            }

            return false;
        }

        // Sets the need to refresh
        public void SetNeedsRefresh(bool value)
        {
            _needsRefresh = value;
        }

        private async Task InitalLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CharacterDataset.Clear();
                var cData = await DataStore.GetAllAsync_Character(true);
                foreach (var data in cData)
                {
                    StartingPlayers.Add(data);
                    CharacterDataset.Add(data);
                }
                MonsterDataset.Clear();
                var mData = ctrl.Monsters;
                foreach (var data in mData)
                {
                    MonsterDataset.Add(data);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            finally
            {
                // temp cause crudi not working
                

                IsBusy = false;
            }
        }

        private async Task ExecuteLoadDataCommand()
        {
            // uncomment once crudi works i think
            //if(first)
            //{
            //    first = false;
            //    InitalLoadDataCommand();
            //}
            //else
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                try
                {
                    CharacterDataset.Clear();
                    StartingPlayers.Clear();
                    var cData = ctrl.Players;
                    foreach (var data in cData)
                    {
                        StartingPlayers.Add(data);
                        CharacterDataset.Add(data);
                    }
                    MonsterDataset.Clear();
                    var mData = ctrl.Monsters;
                    foreach (var data in mData)
                    {
                        MonsterDataset.Add(data);
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                finally
                {
                    IsBusy = false;
                }
            }            
        }
    }

}