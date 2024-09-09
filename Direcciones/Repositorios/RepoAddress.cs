using Direcciones.Models;
using System;
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

        public bool Update(Address modelo)
        {
            try
            {
                modelo.ModifiedDate = DateTime.Now;
                contexto.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public SelectList SelectListCity(string city)
        {
            List<string> ciudades = (from a in contexto.Address orderby a.City select a.City).Distinct().ToList();
            IQueryable resultado = ciudades.AsQueryable().Select(a => new { Valor = a, Nombre = a });
            SelectList model = new SelectList(resultado, "Valor", "Nombre", selectedValue: city);
            return model;
        }

        public SelectList SelectListStateProvince(string stateProvince)
        {
            List<string> states = (from a in contexto.Address orderby a.StateProvince select a.StateProvince).Distinct().ToList();
            IQueryable resultado = states.AsQueryable().Select(a => new { Valor = a, Nombre = a });
            SelectList model = new SelectList(resultado, "Valor", "Nombre", selectedValue: stateProvince);
            return model;
        }

        public List<string> StateProvinceByCity(string city, Boolean enCascada)
        {
            List<string> states = null;

            if (enCascada)
            {
                states = (from a in contexto.Address where a.City == city orderby a.StateProvince select a.StateProvince).Distinct().ToList();
                return states;
            }

            states = (from a in contexto.Address orderby a.StateProvince select a.StateProvince).Distinct().ToList();

            return states;
        }

        public List<string> CityByStateProvince(string stateProvince, Boolean enCascada)
        {
            List<string> cities = new List<string>();

            if (enCascada)
            {
                cities = (from a in contexto.Address where a.StateProvince == stateProvince orderby a.City select a.City).Distinct().ToList();
                return cities;
            }

            cities = (from a in contexto.Address orderby a.City select a.City).Distinct().ToList();

            return cities;
        }

        public string setPais(string city, string stateProvince, string countryRegion)
        {
            Address direccion = new Address();
            direccion = contexto.Address.Where(x => x.City == city && x.StateProvince == stateProvince).FirstOrDefault();
            return direccion == null ? countryRegion : direccion.CountryRegion;
        }

    }
}