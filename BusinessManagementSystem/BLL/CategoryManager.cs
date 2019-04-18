using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Save(Category category)
        {
            return _categoryRepository.Save(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
        public bool Delete(Category category)
        {
            return _categoryRepository.Delete(category);
        }
        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}