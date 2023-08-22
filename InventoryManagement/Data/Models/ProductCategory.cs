using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Data.Models
{
    public class ProductCategory
    {
        [Key]
        [Required(ErrorMessage = "id is required")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }
    }
}
