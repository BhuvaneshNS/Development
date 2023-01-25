using M1092242.Common.CustomException;
using M1092242.DataAccess;
using M1092242.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.Item
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ItemModel> AddItem(ItemModel newItem)
        {
            try
            {
                if (newItem == null)
                {
                    throw new RequestEmptyException("Request contains no data");
                }
                var addedItem = await appDbContext.Items.AddAsync(newItem);
                await appDbContext.SaveChangesAsync();
                if (addedItem.Entity == null)
                {
                    throw new DbInsertException("Something went wrong. Failed to add item");
                }
                return addedItem.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<List<ItemModel>> GetItems()
        {
            try
            {
                var items = await appDbContext.Items.Include(i => i.FastFoodShop).ToListAsync();
                if (items.Count == 0)
                {
                    throw new NoResultException("No items available at the moment");
                }
                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ItemModel>> GetItemsByType(string itemType)
        {
            try
            {
                itemType = itemType.ToLower();
                if (itemType.Equals("veg") || itemType.Equals("nonveg"))
                {
                    var items = await appDbContext.Items.Include(i => i.FastFoodShop).Where(i => i.ItemType == itemType).ToListAsync();
                    if (items.Count == 0)
                    {
                        throw new NoResultException("No items available at the moment");
                    }
                    return items;
                }
                else
                {
                    throw new InvalidCredentialException("Only type veg or nonveg should be inputted");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ItemModel>> UpdatePrice(int shopId)
        {
            try
            {
                var shop = await appDbContext.FoodShops.FirstOrDefaultAsync(s => s.FastFoodShopId == shopId);
                if (shop == null)
                {
                    throw new NoResultException($"No shop with id:{shopId} present");
                }

                var items = await appDbContext.Items.Include(i => i.FastFoodShop).Where(i => i.FastFoodShop.FastFoodShopId == shopId).ToListAsync();
                if (items.Count == 0)
                {
                    throw new NoResultException("No items in the shop");
                }

                foreach (var item in items)
                {
                    item.Price = ((float)((float)item.Price + (item.Price * .10)));
                }
                await appDbContext.SaveChangesAsync();
                return items;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
