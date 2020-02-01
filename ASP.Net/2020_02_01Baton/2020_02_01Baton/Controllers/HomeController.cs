using _2020_02_01Baton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2020_02_01Baton.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private static List<ProductModel> models = new List<ProductModel>()
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Borodynsky bread",
                    Image = "https://e0.edimdoma.ru/data/recipes/0010/4258/104258-ed4_wide.jpg?1504767598"
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Croissant",
                    Image = "https://img.delicious.com.au/RzgR3kXD/w1200/del/2015/12/cornetti-italian-croissants-24713-1.jpg"
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Baget",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQ0aqLgAng2IFhFZI93UBdiYnDNNtCTaNwGDw2IBYjeDl8g_Btz"
                }
            };
        public ActionResult Index()
        {
            return View(models);
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductAddModel model)
        {
            ProductModel product = new ProductModel()
            {
                Id = models.Count + 1,
                Name = model.Name,
                Image = model.Image
            };
            models.Add(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ProductModel product = models.FirstOrDefault(x => x.Id == id);
            if (product != null)
                models.Remove(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ProductModel product = models.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
    }
}