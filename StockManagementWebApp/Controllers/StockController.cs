using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using StockManagementWebApp.Models;

namespace StockManagementWebApp.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext db;

        public StockController()
        {
            db = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
           
            return View(db.StockIns.Include(s=>s.Company).Include(s=>s.Item).ToList());
        }

        [HttpGet]
        public ActionResult Stockin()
        {
            ViewBag.Company = db.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Stockin(StockIn stockIn)
        {
            ViewBag.Company = db.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            var exist = db.StockIns.Count(s => s.ItemId == stockIn.ItemId);
            if (exist > 0)
            {
                var stock = db.StockIns.SingleOrDefault(s => s.ItemId == stockIn.ItemId);
                stock.CompanyId = stockIn.CompanyId;
                stock.ItemId = stockIn.ItemId;
                stock.TotalQuantity =stock.TotalQuantity+ stockIn.TotalQuantity;


            }
            else
            {
                db.StockIns.Add(stockIn);
                
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult GetItemByCompanyId(int companyId)
        {
            var items = db.Items.Where(i => i.CompanyId == companyId).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.ItemName }).ToList();
            return Json(items);
        }

        public JsonResult GetdataByItemId(int iId)
        {
            var exist = db.StockIns.Count(s => s.ItemId==iId);
            if (exist>0)
            {
                var stockin = db.StockIns.Include(s => s.Item).SingleOrDefault(s => s.ItemId == iId);
                return Json(stockin);
            }
            var stockIn = new StockIn();
            stockIn.TotalQuantity = 0;
            stockIn.Item = db.Items.SingleOrDefault(i=>i.Id==iId);



            return Json(stockIn);
        }

        [HttpGet]
        public ActionResult StockOut()
        {
            ViewBag.Company = db.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult StockOut(List<StockOut> stockOuts )
        {
            ViewBag.Company = db.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            return View();
        }








    }
}