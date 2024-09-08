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
            ViewBag.StateProvince = repositorio.SelectListCity();

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

    }
}