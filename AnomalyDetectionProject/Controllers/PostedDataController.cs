using AnomalyDetectionProject.Data;
using AnomalyDetectionProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnomalyDetectionProject.Controllers
{
    public class PostedDataController : Controller
    {
        DatabaseContext dbContext = new DatabaseContext();
        public IActionResult Index()
        {
            List<PostedData> posteddatas = dbContext.postedDatas.ToList();
            return View(posteddatas);
        }
    }
}
