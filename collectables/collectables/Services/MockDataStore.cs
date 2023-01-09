using collectables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collectables.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Verzameling> verzameling;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item {ItemId = 1, ItemNaam = "gele banaan", ItemTeKoop = "ja"},
                new Item { ItemId = 2, ItemNaam = "blauwe banaan", ItemTeKoop="nee" },
                new Item { ItemId = 3, ItemNaam = "rode banaan", ItemTeKoop="nee" },
                new Item { ItemId = 4, ItemNaam = "groene banaan", ItemTeKoop="nee" },
                new Item { ItemId = 5, ItemNaam = "roze banaan", ItemTeKoop="ja" },
                new Item { ItemId = 6, ItemNaam = "regenboog banaan", ItemTeKoop="ja" }
            };

            verzameling = new List<Verzameling>()
            {
                new Verzameling {VerzamelingID = 1, VerzamelingNaam = "bananen",  }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.ItemId == item.ItemId).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.ItemId == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ItemId == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}