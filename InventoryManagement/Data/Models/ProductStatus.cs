using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Data.Models
{
    public class ProductStatus
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "status is required")]
        public string? status { get; set; }
    }
}
