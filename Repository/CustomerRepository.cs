using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll().OrderBy(x => x.CustomerId).ToList();
        }
    }
}
