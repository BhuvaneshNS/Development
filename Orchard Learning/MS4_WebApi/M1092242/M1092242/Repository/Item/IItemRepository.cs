using M1092242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.Item
{
    public interface IItemRepository
    {

        Task<ItemModel> AddItem(ItemModel newItem);
        Task<List<ItemModel>> UpdatePrice(int shopId);
        Task<List<ItemModel>> GetItems();
        Task<List<ItemModel>> GetItemsByType(string itemType);
    }
}
