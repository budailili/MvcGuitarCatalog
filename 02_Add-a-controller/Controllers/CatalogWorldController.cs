using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcGuitarCatalog.Controllers
{
    public class CatalogWorldController : Controller
    {
        // GET: /CatalogWorld/
        public string Index()
        {
            return "This is my default action...";
        }

        // GET: /CatalogWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
    }
}