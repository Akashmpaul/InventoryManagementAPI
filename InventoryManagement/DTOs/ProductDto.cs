namespace InventoryManagement.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? StatusId { get; set; }
        public virtual int? NozzleFlows { get; set; }
        public virtual string? Mechanism { get; set; }
        public virtual ProductCategoryDto? Category { get; set; }
        public virtual ProductStatusDto? Status { get; set; }
        public virtual string? Type { get; set; }
        public virtual string? ThreadSize { get; set; }
    }
}
