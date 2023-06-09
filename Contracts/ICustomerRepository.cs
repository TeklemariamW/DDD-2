﻿using Entities.Models;

namespace Contracts
{
    public interface ICustomerRepository
    {
        //IEnumerable<Customer> GetAllCustomers(CustomerParameters customerParameters);
        PagedList<Customer> GetAllCustomers(CustomerParameters customerParameters);
        Customer GetCustomerById(string Id);
        Customer GetCustomerWithDetail(string CustomerId);

    }
}
