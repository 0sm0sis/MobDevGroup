using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerminalCharacter.Models;
using TerminalCharacter.ViewModels;


namespace TerminalCharacter.Services
{
    public sealed class SQLDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }

        private SQLDataStore()
        {
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<Player>().Wait();
            App.Database.CreateTableAsync<Monster>().Wait();
            App.Database.CreateTableAsync<Score>().Wait();
        }

        // restart the databases
        public void InitializeDatabaseNewTables()
        {
            DeleteTables();
            CreateTables();
            InitilizeSeedData();
            NotifyViewModelsOfDataChange();
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            MonstersViewModel.Instance.SetNeedsRefresh(true);
            CharacterViewModel.Instance.SetNeedsRefresh(true);
            ScoresViewModel.Instance.SetNeedsRefresh(true);
        }

        // Create the Database Tables
        private void CreateTables()
        {
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<Player>().Wait();
            App.Database.CreateTableAsync<Monster>().Wait();
            App.Database.CreateTableAsync<Score>().Wait();
        }

        // Delete the Datbase Tables by dropping them
        private void DeleteTables()
        {
            App.Database.DropTableAsync<Item>().Wait();
            App.Database.DropTableAsync<Player>().Wait();
            App.Database.DropTableAsync<Monster>().Wait();
            App.Database.DropTableAsync<Score>().Wait();
        }

        // put new data into databases
        private async void InitilizeSeedData()
        {
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Item 1", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Item 2", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Item 3", Description = "This is an item description." });


            await AddAsync_Character(new Player { Id = Guid.NewGuid().ToString(), Name = "Character 1", Description = "This is an Character description."});
            await AddAsync_Character(new Player { Id = Guid.NewGuid().ToString(), Name = "Character 2", Description = "This is an Character description."});
            await AddAsync_Character(new Player { Id = Guid.NewGuid().ToString(), Name = "Character 3", Description = "This is an Character description."});

            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Monster 1", Description = "This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Monster 2", Description = "This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Monster 3", Description = "This is an Monster description." });

            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Score 1", ScoreTotal = 1 });
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Score 2", ScoreTotal = 2 });
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Score 3", ScoreTotal = 3 });
        }

        // Item
        public async Task<bool> AddAsync_Item(Item data)
        {
            var result = await App.Database.InsertAsync(data);

            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            Item result = await App.Database.GetAsync<Item>(id);
            return result;
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            List<Item> result = await App.Database.Table<Item>().ToListAsync();
            return result;
        }


        // Character
        public async Task<bool> AddAsync_Character(Player data)
        {
            var result = await App.Database.InsertAsync(data);

            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> UpdateAsync_Character(Player data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync_Character(Player data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<Player> GetAsync_Character(string id)
        {
            Player result = await App.Database.GetAsync<Player>(id);
            return result;
        }

        public async Task<IEnumerable<Player>> GetAllAsync_Character(bool forceRefresh = false)
        {
            List<Player> result = await App.Database.Table<Player>().ToListAsync();
            return result;
        }


        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            var result = await App.Database.InsertAsync(data);

            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            Monster result = await App.Database.GetAsync<Monster>(id);
            return result;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            List<Monster> result = await App.Database.Table<Monster>().ToListAsync();
            return result;
        }

        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            var result = await App.Database.InsertAsync(data);

            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
                return true;

            return false;
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            Score result = await App.Database.GetAsync<Score>(id);
            return result;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            List<Score> result = await App.Database.Table<Score>().ToListAsync();
            return result;
        }

    }

}
