using Microsoft.AspNetCore.Mvc;

namespace AnomalyDetectionProject.Controllers
{
    public class CamerasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
