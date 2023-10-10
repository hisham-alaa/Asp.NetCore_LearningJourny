using Microsoft.AspNetCore.Mvc;

namespace Asp.netCore02.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult GetMovie(int id)
        {
            return Content($"Hello +{id}");
        } 

    }
}
 