using System.Collections.Generic;

namespace Services
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert (T entidade);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();
    }
}