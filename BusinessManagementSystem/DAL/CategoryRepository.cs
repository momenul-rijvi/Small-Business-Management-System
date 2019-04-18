using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class CategoryRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
        public bool Save(Category category)
        {
            db.Categories.Add(category);
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

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            Category nCatagory = db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return nCatagory;
        }
        public bool Delete(Category category)
        {
            bool isDelete = false;

            db.Categories.Remove(category);
            int roAffacted = db.SaveChanges();
            if (roAffacted > 0)
            {
                isDelete = true;
            }
            return isDelete;
        }

        public bool Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
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
    }
}