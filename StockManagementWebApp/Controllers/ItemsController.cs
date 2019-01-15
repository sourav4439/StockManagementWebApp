using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            var items = db.Items.Include(i => i.Category).Include(i=>i.Company).ToList();
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
            var companies =db.Companies.Where(c => c.CategoryId == categoryId).ToList();
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
            ViewBag.category = db.Categories.Select(category => new SelectListItem()
            {
                Value = category.Id.ToString(),
                Text = category.Name
            }).ToList();

            db.Items.AddOrUpdate(item);
            db.SaveChanges();


            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var item = db.Items.Find(id);           
            return View(item);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            if (item != null) db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}