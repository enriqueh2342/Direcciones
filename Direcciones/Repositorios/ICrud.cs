using System;
using System.Linq;

namespace Direcciones.Repositorios
{
    public interface ICrud<T>
    {
        Boolean Create();
        IQueryable<T> Get();
        T Get(int id);
        IQueryable<T> Get(string text);
        Boolean Update(T item);
        Boolean Delete(int id);
    }
}