using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.Data
{
    public interface IRepository<T,E> where T:class
    {
        T GetById(E id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
