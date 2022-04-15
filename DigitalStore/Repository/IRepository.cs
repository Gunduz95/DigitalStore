using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalStore.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}