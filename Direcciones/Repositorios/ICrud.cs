using System;
using System.Linq;

namespace Direcciones.Repositorios
{
    public interface ICrud<T>
    {
        Boolean Create();
        IQueryable<T> Get();
        T Get(int id);
        Boolean Update(int id);
        Boolean Delete(int id);
    }
}