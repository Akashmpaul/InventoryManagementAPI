using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Data.Models
{
    public class NozzleFlow
    {
        [Key]
        [Required(ErrorMessage = "Id is required")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "No_of_flows is required")]
        public int No_of_flows { get; set; }
    }
}
