using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository= new ProductRepository();
        public bool Save(Product product)
        {
            return _productRepository.Save(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool Delete(Product product)
        {
            return _productRepository.Delete(product);
        }

        public List<Category> GetAllCategoy()
        {
            return _productRepository.GetAllCategory();
        }

        public Product IsCodeExist(string code)
        {
            return _productRepository.IsCodeExist(code);
        }
    }
}