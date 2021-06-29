using System;
using System.Collections.Generic;

namespace Painter_cur.Models
{
    interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetList();
        T Get(int id);
        void Create(T el);
        void Update(T el);
        void Delete(int id);
        void Save();
    }
}
