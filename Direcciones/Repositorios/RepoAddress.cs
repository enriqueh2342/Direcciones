using Direcciones.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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

        public SelectList SelectListCity()
        {
            List<string> ciudades = (from a in contexto.Address orderby a.City select a.City).Distinct().ToList();
            IQueryable resultado = ciudades.AsQueryable().Select(a => new { Valor = a, Nombre = a });
            SelectList model = new SelectList(resultado, "Valor", "Nombre");

            return model;
        }

        public SelectList SelectListStateProvince()
        {
            List<string> states = (from a in contexto.Address orderby a.StateProvince select a.StateProvince).Distinct().ToList();
            IQueryable resultado = states.AsQueryable().Select(a => new { Valor = a, Nombre = a });
            SelectList model = new SelectList(resultado, "Valor", "Nombre");

            return model;
        }

    }
}