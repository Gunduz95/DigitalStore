using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DigitalStore.Models;

namespace DigitalStore.Repository
{
    public class ManufacturersRepository : IRepository<Manufacturer>
    {
        private DigitalStoreContext _context;

        public ManufacturersRepository()
        {
            _context = new DigitalStoreContext();
        }

        public List<Manufacturer> GetAll()
        {
            return _context.Manufacturers.ToList();
        }
        public Manufacturer GetById(int id)
        {
            return _context.Manufacturers.FirstOrDefault(c => c.Id == id);
        }
        public void Create(Manufacturer item)
        {
            _context.Manufacturers.Add(item);
        }
        public void Update(Manufacturer item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Manufacturer m = _context.Manufacturers.Find(id);
            if (m != null)
                _context.Manufacturers.Remove(m);
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