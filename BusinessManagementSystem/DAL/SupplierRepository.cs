using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DatabaseContext;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.DAL
{
    public class SupplierRepository
    {
        BusinessManagementSystemDbContext db = new BusinessManagementSystemDbContext();
        public bool Save(Supplier Supplier)
        {
            bool isSaved = false;

            db.Suppliers.Add(Supplier);

            int rowAfected = db.SaveChanges();

            if (rowAfected > 0)
                isSaved = true;

            return isSaved;

        }
        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool Update(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
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

        public Supplier GetsupplierById(int id)
        {
            Supplier supplier = db.Suppliers.Where(s=>s.Id == id).FirstOrDefault();
            return supplier;
        }

        public bool Delete(Supplier supplier)
        {
            db.Suppliers.Remove(supplier);
            int rowAfected = db.SaveChanges();
            if (rowAfected > 0)
            {
                return true;
            }
            return false;
        }
    }
}