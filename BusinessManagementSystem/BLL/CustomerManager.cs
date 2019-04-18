using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Save(Customer customer)
        {
            bool isSaved = _customerRepository.Save(customer);
            return isSaved;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public bool Delete(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }
    }
}