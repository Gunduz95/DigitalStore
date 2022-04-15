using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DigitalStore.Models;

namespace DigitalStore.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private DigitalStoreContext _context;

        public CategoryRepository()
        {
            _context = new DigitalStoreContext();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }
        public void Update(Category item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Category c = _context.Categories.Find(id);
            if (c != null)
                _context.Categories.Remove(c);
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