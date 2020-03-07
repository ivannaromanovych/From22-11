using _2020_02_15Hello.Enitites;
using _2020_02_15Hello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2020_02_15Hello.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<CategoryItemViewModel> list = context.Categories.Select(x => new CategoryItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UrlSlug = x.UrlSlug
            }).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //CategoryCreateViewModel model = new CategoryCreateViewModel();
            //model.Name = "Humor";
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Category category = new Category()
                {
                    Name = model.Name,
                    UrlSlug = model.UrlSlug,
                    Description = model.Description
                };
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
    }
}