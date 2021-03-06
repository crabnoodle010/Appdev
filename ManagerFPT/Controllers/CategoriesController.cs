using ManagerFPT.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ManagerFPT.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Categories
        public ActionResult Index(string searchString)
        {
            var categories = _context.Categories.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                categories = categories.Where(t => t.Name.Contains(searchString)).ToList();
            }
            return View(categories);
        }
        public ActionResult Details(int id)
        {
            var category = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (category == null) return HttpNotFound();
            return View(category);

        }
        public ActionResult Delete (int id)
        {
            var category = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (category == null) return HttpNotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (category == null) return HttpNotFound();
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);
            if (categoryInDb == null) return HttpNotFound();

            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}