using System;
using System.Linq;
using System.Web.Mvc;
using Direcciones.Models;
using Direcciones.Repositorios;

namespace Direcciones.Controllers
{
    public class DireccionesController : Controller
    {

        private RepoAddress repositorio = new RepoAddress();

        public ActionResult Index()
        {
            IQueryable<Address> direcciones = repositorio.Get();

            return View(direcciones);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Address direccion = repositorio.Get(id);
            ViewBag.City = repositorio.SelectListCity(direccion.City);
            ViewBag.StateProvince = repositorio.SelectListStateProvince(direccion.StateProvince);

            return View(direccion);
        }

        [HttpPost]
        public ActionResult Edit(int id, string City, string StateProvince, int[] cascada)
        {
            Address direccion = repositorio.Get(id);
            direccion.City = City;
            direccion.StateProvince = StateProvince;
            if (cascada[0] == 1)
            {
                direccion.CountryRegion = repositorio.setPais(City, StateProvince, direccion.CountryRegion);
            }
            ViewBag.City = repositorio.SelectListCity(City);
            ViewBag.StateProvince = repositorio.SelectListStateProvince(StateProvince);
            ViewBag.Status = repositorio.Update(direccion);
            return View(direccion);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult ValidarEstado(string city, Boolean enCascada)
        {
            var estados = repositorio.StateProvinceByCity(city, enCascada);

            return Json(estados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarCiudad(string stateProvince, Boolean enCascada)
        {
            var cities = repositorio.CityByStateProvince(stateProvince, enCascada);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}