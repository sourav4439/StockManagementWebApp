using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementWebApp.Models;

namespace StockManagementWebApp.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationDbContext db;

        public CompanyController()
        {
            db=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           db.Dispose();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (company.Id==0)
            {
                db.Companies.Add(company);
            }
            else
            {
                var companyInDb = db.Companies.Single(c => c.Id == company.Id);
                companyInDb.Name = company.Name;
                companyInDb.RegistrationCode = company.RegistrationCode;

            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
           List<Company> companies= db.Companies.ToList();
            return View(companies);
        }

        public ActionResult Edit(int id)
        {
            var company = db.Companies.SingleOrDefault(c => c.Id == id);
            if (company==null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        public ActionResult Delete(int id)
        {
            var company=db.Companies.SingleOrDefault(c => c.Id == id);
            if (company != null) db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}