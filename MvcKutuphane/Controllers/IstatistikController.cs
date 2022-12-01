using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.tbluyeler.Count();
            var deger2 = db.tblkitap.Count();
            var deger3 = db.tblkitap.Where(x => x.durum == false).Count();
            var deger4 = db.tblcezalar.Sum(x => x.para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }


    }
}