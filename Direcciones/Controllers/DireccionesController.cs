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

        public ActionResult Edit(int id)
        {
            Address direccion = repositorio.Get(id);
            ViewBag.City = repositorio.SelectListCity();
            ViewBag.StateProvince = repositorio.SelectListStateProvince();

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