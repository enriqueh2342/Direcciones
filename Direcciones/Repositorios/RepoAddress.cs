using Direcciones.Models;
using System.Linq;

namespace Direcciones.Repositorios
{
    public class RepoAddress : ICrud<Address>
    {
        private SQLContext contexto = new SQLContext();

        public bool Create()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Address> Get()
        {
            IQueryable<Address> direcciones = from a in contexto.Address orderby a.City select a;
            return direcciones.AsQueryable();
        }

        public Address Get(int id)
        {
            Address direccion = contexto.Address.Where(x => x.AddressID == id).FirstOrDefault();
            return direccion;
        }

        public bool Update(int id)
        {

            throw new System.NotImplementedException();
        }
    }
}