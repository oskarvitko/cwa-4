using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.Repozitory;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ItemRepository repository = new ItemRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomeModel(
                repository.GetAll(),
                null
                ));
        }

        [HttpGet("/{id}")]
        public IActionResult Index(string id)
        {
            return View(new HomeModel(
                repository.GetAll(),
                repository.GetById(int.Parse(id))
            ));
        }

        [HttpPost]
        public IActionResult Index(string name, string age)
        {
            int id = 0;
            List<Item> items = repository.GetAll();
            if (items.Count > 0)
            {
                id = items.Last().Id + 1;
            }
            Item newItem = new Item(
                id,
                name,
                int.Parse(age)
            );
            repository.Save(newItem);

            return Redirect("/");
        }

        [HttpPost("/update")]
        public IActionResult Index(string id, string name, string age)
        {
            Item updatedItem = new Item(
                int.Parse(id),
                name,
                int.Parse(age)
            );
            repository.Update(updatedItem);

            return Redirect("/");
        }

        [HttpPost("/delete")]
        public IActionResult Index(string id, double _)
        {
            repository.Delete(int.Parse(id));

            return Redirect("/");
        }
    }
}
