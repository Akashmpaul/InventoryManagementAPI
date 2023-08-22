namespace InventoryManagement.Repository.Contracts
{
    public interface IIMDbRepository
    {
        IProductRepository products { get; }
        IProductCategoryRepository category { get; }
        IProductStatusRepository status { get; }
        IMechanismRepository mechanism { get; }
        INozzleFlowRepository nozzle { get; }
        Task Save();
    }
}
