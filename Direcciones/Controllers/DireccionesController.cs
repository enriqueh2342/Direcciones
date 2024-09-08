using System.Linq;
using System.Web.Mvc;
using Direcciones.Models;

namespace Direcciones.Controllers
{
    public class DireccionesController : Controller
    {
        private SQLContext contexto = new SQLContext();

        public ActionResult Index()
        {
            IQueryable<Address> direcciones = from a in contexto.Address orderby a.City select a;

            return View(direcciones);
        }

        public ActionResult Edit(int id)
        {
            Address direccion = contexto.Address.Where(x => x.AddressID == id).FirstOrDefault();

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

        //public void ValidarConexion()
        //{
        //    //string conexion = ConfigurationManager.ConnectionStrings["DireccionesDB"].ConnectionString;
        //    //// Intentar abrir la conexión
        //    //using (SqlConnection connection = new SqlConnection(conexion))
        //    //{
        //    //    try
        //    //    {
        //    //        connection.Open();
        //    //        Console.WriteLine("La conexión a la base de datos fue exitosa.");
        //    //    }
        //    //    catch (SqlException ex)
        //    //    {
        //    //        Console.WriteLine($"Error al conectarse a la base de datos: {ex.Message}");
        //    //    }
        //    //}
        //}
    }
}