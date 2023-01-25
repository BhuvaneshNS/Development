using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalShopManagementSystem.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public string RoleType { get; set; }
        //public List<UserModel> Users { get; set; }
    }
}
