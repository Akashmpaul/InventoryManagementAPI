namespace InventoryManagement.Services.Contracts
{
    public interface IServiceManager
    {
        IProductCategoryService Category { get; }

        IProductStatusService Status { get; }

        IMechanismService Mechanism { get; }

        INozzleFlowService NozzleFlow { get; }

        IProductService Product { get; }
    }
}
