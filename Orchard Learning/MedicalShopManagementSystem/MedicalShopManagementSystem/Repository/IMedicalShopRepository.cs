using MedicalShopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Repository
{
    public interface IMedicalShopRepository
    {
        public Task<MedicalShopModel> AddMedicalShop(MedicalShopModel newMedicalShop);
        public Task<MedicalShopModel> UpdateMedicalShop(MedicalShopModel medicalShop);
        public Task<List<MedicalShopModel>> GetMedicalShops();
        public Task<MedicalShopModel> GetMedicalShop(int shopId);
        public Task DeleteMedicalShop(int shopId);
    }
}
