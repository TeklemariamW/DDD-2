namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        void Save();
    }
}
