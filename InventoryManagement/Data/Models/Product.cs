using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Data.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int? Price { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ProductCategory? Category { get; set; }

        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ProductStatus? Status { get; set; }

        public int? NozzleFlows { get; set; }
        public string? Mechanism { get; set; }
        public string? Type { get; set; }
        public string? ThreadSize { get; set; }
    }
}
