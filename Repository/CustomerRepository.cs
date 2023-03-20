using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<Customer>> GetAllOwnersAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.ContactName)
                .ToListAsync();
        }

        public async Task<Customer> GetOwnerByIdAsync(Guid ownerid)
        {
            return await FindByCondition(x => x.CustomerId.Equals(ownerid))
                .FirstOrDefaultAsync();
        }

        public Customer GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(owner => owner.CustomerId.Equals(ownerId))
                .Include(ac => ac.Orders)
                .FirstOrDefault();
        }
    }
}
