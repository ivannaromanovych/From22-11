using HomeWorkCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWorkCRUD.Controllers
{
    public class HomeController : Controller
    {
        MyContext _context = new MyContext();
        private static List<ProductModel> models = new List<ProductModel>();
        public ActionResult Index()
        {
            return View(models);
        }
        public ActionResult Update()
        {
            models.Clear();
            var prod = _context.ProductModels.ToList();
            if (prod != null)
            {
                models.AddRange(prod);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductAddModel model)
        {
            ProductModel item = new ProductModel();
            item.Name = model.Name;
            item.Image = model.Image;
            _context.ProductModels.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var product = _context.ProductModels.SingleOrDefault(x => x.Id == id);
            if (product != null)
                return View(product);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var prod = _context.ProductModels.SingleOrDefault(x => x.Id == id);
            _context.ProductModels.Remove(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var product = _context.ProductModels.SingleOrDefault(x => x.Id == id);
            if (product != null)
                return View(product);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductAddModel model)
        {
            if (model.Name != null)
                _context.ProductModels.FirstOrDefault(x => x.Id == id).Name = model.Name;
            if (model.Image != null)
                _context.ProductModels.FirstOrDefault(x => x.Id == id).Image = model.Image;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}