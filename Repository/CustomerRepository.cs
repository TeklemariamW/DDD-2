using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public Customer GetCustomerById(string Id)
        {
            return FindByCondition(customer => customer.CustomerId == Id)
                 .FirstOrDefault();
        }
        public Customer GetCustomerWithDetail(string Id)
        {
            return FindByCondition(customer => customer.CustomerId.Equals(Id))
                .FirstOrDefault();
        }
    }
}
