using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalShopManagementSystem.Models
{
    public class UserModel : ResponseModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public GenderModel? Gender { get; set; }
        public DateTime? DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        //[JsonIgnore]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        //[JsonIgnore]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRoleModel UserRole { get; set; }
        public int? MedicalShopId { get; set; }
        public MedicalShopModel MedicalShop { get; set; }

    }
}
