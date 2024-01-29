using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Repositories.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task Create(T model);
        void Update(T model);
        void Delete(T model);
        Task<IList<T>> GetAll();

        Task<bool> SaveChangesAsync();
        void SaveChanges();

    }
}
