using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcGuitarCatalog.Controllers
{
    public class CatalogWorldController : Controller
    {
        // GET: /CatalogWorld/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /CatalogWorld/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}