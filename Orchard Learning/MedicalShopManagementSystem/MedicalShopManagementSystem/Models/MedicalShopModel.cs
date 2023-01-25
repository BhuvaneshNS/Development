using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalShopManagementSystem.Models
{
    public class MedicalShopModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //public List<UserModel> Users { get; set; }
    }
}
