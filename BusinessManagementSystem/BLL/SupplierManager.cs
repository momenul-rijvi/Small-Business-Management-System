using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessManagementSystem.DAL;
using BusinessManagementSystem.Models;

namespace BusinessManagementSystem.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();
        public bool Save(Supplier Supplier)
        {
            bool isSaved = _supplierRepository.Save(Supplier);
            return isSaved;
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public bool Update(Supplier suppliers)
        {
            return _supplierRepository.Update(suppliers);
        }

        public Supplier GetsupplierById(int id)
        {
            return _supplierRepository.GetsupplierById(id);
        }

        public bool Delete(Supplier supplier)
        {
            return _supplierRepository.Delete(supplier);
        }
    }
}