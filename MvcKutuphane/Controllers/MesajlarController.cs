using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        // GET: Mesajlar
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.tblmesajlar.Where(x => x.alici == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.tblmesajlar.Where(x => x.gonderen == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(tblmesajlar p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.gonderen = uyemail.ToString();
            p.tarih = DateTime.Parse( DateTime.Now.ToShortDateString());
            db.tblmesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesajlar");
        }


    }
}