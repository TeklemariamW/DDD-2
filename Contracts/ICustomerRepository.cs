using Entities.Models;

namespace Contracts
{
    public interface ICustomerRepository : IRepositoryBas<Customer>
    {

        Task<IEnumerable<Customer>> GetAllOwnersAsync();
        Task<Customer> GetOwnerByIdAsync(Guid ownerId);
        Customer GetOwnerWithDetails(Guid ownerId);
    }
}
