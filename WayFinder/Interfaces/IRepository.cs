using System.Collections.Generic;

namespace WayFinder.Interfaces
{
    public interface IRepository<T, Tid>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T data);
        void Edit(T data);
        string Delete(Tid id);
    }
}