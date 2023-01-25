using M1092242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Repository.FoodShop
{
    public interface IFoodShopRepository
    {
        Task<FastFoodShopModel> AddShop(FastFoodShopModel foodShop);
        Task<FastFoodShopModel> UpdateShop(FastFoodShopModel foodShop);
        Task<List<FastFoodShopModel>> GetFoodShops();
        Task<FastFoodShopModel> GetFoodShop(int id);
        Task DeleteShop(int id);

    }
}
