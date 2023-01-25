using MedicalShopManagementSystem.Common.CustomException;
using MedicalShopManagementSystem.DataAccess;
using MedicalShopManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Repository
{
    public class MedicalShopRepository : IMedicalShopRepository
    {
        private readonly AppDbContext appDbContext;

        public MedicalShopRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<MedicalShopModel> AddMedicalShop(MedicalShopModel newMedicalShop)
        {
            var addedMedicalShop = await appDbContext.MedicalShops.AddAsync(newMedicalShop);
            await appDbContext.SaveChangesAsync();
            return addedMedicalShop.Entity;
        }

        public async Task DeleteMedicalShop(int shopId)
        {
            var shop = await appDbContext.MedicalShops.FirstOrDefaultAsync(m => m.Id == shopId);
            if (shop != null)
            {
                appDbContext.MedicalShops.Remove(shop);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<MedicalShopModel> GetMedicalShop(int shopId)
        {
            return await appDbContext.MedicalShops.FirstOrDefaultAsync(m => m.Id == shopId);
        }

        public async Task<List<MedicalShopModel>> GetMedicalShops()
        {
            try
            {
                var result = await appDbContext.MedicalShops.ToListAsync();
                if (result == null)
                {
                    throw new EmptyException("The result is empty nigga");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MedicalShopModel> UpdateMedicalShop(MedicalShopModel medicalShop)
        {
            var shop = await appDbContext.MedicalShops.FirstOrDefaultAsync(m => m.Id == medicalShop.Id);
            if (shop != null)
            {
                shop.Name = medicalShop.Name;
                shop.Location = medicalShop.Location;
            }
            await appDbContext.SaveChangesAsync();
            return shop;
        }
    }
}
