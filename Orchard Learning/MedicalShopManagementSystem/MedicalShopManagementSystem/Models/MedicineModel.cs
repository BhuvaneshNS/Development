using System.Collections.Generic;

namespace MedicalShopManagementSystem.Models
{
    public class MedicineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public MedicalShopModel MedicalShop { get; set; }
    }
}
