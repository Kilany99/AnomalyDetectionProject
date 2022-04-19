using AnomalyDetectionProject.Data;
using AnomalyDetectionProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnomalyDetectionProject.Controllers
{
    public class ActionsController : Controller
    {
        DatabaseContext dbContext = new DatabaseContext();
        public IActionResult Index()
        {
            List<Models.Action> actions = dbContext.Actions.ToList();
            return View(actions);
        }
    }
}
