using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Data.Models
{
    public class Mechanism
    {

        [Key]
        [Required(ErrorMessage = "id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mechanism_Name is required")]
        public string? Mechanism_Name { get; set; }
    }
}
