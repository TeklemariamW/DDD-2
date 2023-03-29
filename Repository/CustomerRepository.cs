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

        //public IEnumerable<Customer> GetAllCustomers(CustomerParameters customerParameters)
        //{
        //    return FindAll()
        //        .OrderBy(x => x.CustomerId)
        //        .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
        //        .Take(customerParameters.PageSize)
        //        .ToList();
        //}
        public PagedList<Customer> GetAllCustomers(CustomerParameters customerParameters)
        {
            return PagedList<Customer>.ToPagedList(FindAll().OrderBy(id => id.CustomerId),
                customerParameters.PageNumber,
                customerParameters.PageSize);
        }
    }
}
