﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerBaza
{
    public class ItemDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public ItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.Id != 0)
                return _database.UpdateAsync(item);
            else
                return _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Item item)
        {
            return await _database.DeleteAsync(item);
        }
    }
}
