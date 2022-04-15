using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DigitalStore.Models;

namespace DigitalStore.Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        private DigitalStoreContext _context;

        public ProductsRepository()
        {
            _context = new DigitalStoreContext();
        }

        public List<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.Category).ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }
        public void Create(Product item)
        {
            _context.Products.Add(item);
        }
        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Product p = _context.Products.Find(id);
            if (p != null)
                _context.Products.Remove(p);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}