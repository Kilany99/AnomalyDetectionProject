
using Microsoft.AspNetCore.Mvc;
using AnomalyDetectionProject.Data;
using AnomalyDetectionProject.Models;
namespace AnomalyDetectionProject.Controllers
{
    public class ClientController : Controller
    {
        DatabaseContext dbContext = new DatabaseContext();
        public IActionResult Index()
        {
            List<Client> clients = dbContext.Clients.ToList();
            return View(clients);
        }
        public IActionResult Add()
        {
            ViewBag.Camera = this.dbContext.cameras.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Client model)
        {
            ModelState.Remove("Camera");
            ModelState.Remove("ClientID");
            if (ModelState.IsValid)
            {
                dbContext.Clients.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Camera = this.dbContext.cameras.ToList();
            return View();

        }
        public IActionResult Edit(int ID)
        {
            Client data = this.dbContext.Clients.Where(e => e.ClientId == ID).FirstOrDefault();
            ViewBag.Camera = this.dbContext.cameras.ToList();
            return View("Add", data);
        }
    }

}
