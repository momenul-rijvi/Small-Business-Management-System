using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class CustomerRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
        public bool Save(Customer customer)
        {
            bool isSaved = false;

            db.Customers.Add(customer);

            int rowAfected = db.SaveChanges();

            if (rowAfected > 0)
                isSaved = true;

            return isSaved;

        }
        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public bool Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            int isUpdate = db.SaveChanges();
            if (isUpdate > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = db.Customers.Where(s => s.Id == id).FirstOrDefault();
            return customer;
        }

        public bool Delete(Customer customer)
        {
            db.Customers.Remove(customer);
            int rowAfected = db.SaveChanges();
            if (rowAfected > 0)
            {
                return true;
            }
            return false;
        }
    }
}