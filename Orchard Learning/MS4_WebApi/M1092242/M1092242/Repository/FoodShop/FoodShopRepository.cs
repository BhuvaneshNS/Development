using M1092242.Common.CustomException;
using M1092242.DataAccess;
using M1092242.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.FoodShop
{
    public class FoodShopRepository : IFoodShopRepository
    {
        private readonly AppDbContext appDbContext;

        public FoodShopRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<FastFoodShopModel> AddShop(FastFoodShopModel foodShop)
        {
            try
            {
                if (foodShop == null)
                {
                    throw new RequestEmptyException("Request contains no data");
                }
                var addedShop = await appDbContext.FoodShops.AddAsync(foodShop);
                await appDbContext.SaveChangesAsync();
                if (addedShop.Entity == null)
                {
                    throw new DbInsertException("Something went wrong. Failed to add food shop");
                }
                return addedShop.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteShop(int id)
        {
            try
            {
                var shop = await GetFoodShop(id);
                appDbContext.FoodShops.Remove(shop);
                await appDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FastFoodShopModel> GetFoodShop(int id)
        {
            try
            {
                var shop = await appDbContext.FoodShops.FirstOrDefaultAsync(f => f.FastFoodShopId == id);
                if (shop == null)
                {
                    throw new NoResultException($"No shop with id: {id} present");
                }
                return shop;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FastFoodShopModel>> GetFoodShops()
        {
            try
            {
                var foodShops = await appDbContext.FoodShops.ToListAsync();
                if (foodShops.Count == 0)
                {
                    throw new NoResultException("No shops to display");
                }
                return foodShops;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FastFoodShopModel> UpdateShop(FastFoodShopModel foodShop)
        {
            try
            {
                if (foodShop == null)
                {
                    throw new RequestEmptyException("Request body contains no data");
                }

                var shop = await GetFoodShop(foodShop.FastFoodShopId);

                shop.FastFoodShopName = foodShop.FastFoodShopName;
                shop.City = foodShop.City;
                shop.PhoneNumber = foodShop.PhoneNumber;

                await appDbContext.SaveChangesAsync();
                return shop;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
