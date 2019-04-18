using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class ProductRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
        public bool Save(Product product)
        {
            db.Products.Add(product);
            int rowAfected = db.SaveChanges();
            if (rowAfected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            Product product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            return product;
        }

        public bool Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
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

        public bool Delete(Product product)
        {
            db.Products.Remove(product);
            int rowAfected = db.SaveChanges();
            if (rowAfected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategory()
        {
            return db.Categories.ToList();
        }
    }
}