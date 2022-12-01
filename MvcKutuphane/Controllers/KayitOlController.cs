using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        // GET: KayitOl

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(tbluyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.tbluyeler.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}