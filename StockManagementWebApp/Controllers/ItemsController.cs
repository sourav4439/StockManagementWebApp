using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockManagementWebApp.Models;

namespace StockManagementWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db;

        public ItemsController()
        {
            db=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category).ToList();
            return View(items);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.category = db.Categories.Select(category => new SelectListItem()
            {
                Value = category.Id.ToString(),
                Text = category.Name
            }).ToList();
            return View();
        }   
        [HttpPost]
        public ActionResult Create(Item item)
        {
            ViewBag.category = db.Categories.Select(category => new SelectListItem()
            {
                Value = category.Id.ToString(),
                Text = category.Name
            }).ToList();

            db.Items.Add(item);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public JsonResult GetcompanyBycategoryId(int categoryId)
        {
            var companies = new List<Company>();
            foreach (var c in db.Companies.Where(c=>c.CategoryId==categoryId).ToList())
            {
               Company company=new Company();
                company.Id = c.Id;
                company.Name = c.Name;

                companies.Add(company);
            }
            return Json(companies);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item==null)
            {
                return HttpNotFound();
            }

            ViewBag.category = db.Categories.Select(category => new SelectListItem()
            {
                Value = category.Id.ToString(),
                Text = category.Name
            }).ToList();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            return View();
        }



    }
}