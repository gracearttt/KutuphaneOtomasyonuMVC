using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.tbluyeler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(tbluyeler p)
        {
            db.tbluyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.tbluyeler.Find(id);
            db.tbluyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id = 0)
        {
            var uye = db.tbluyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(tbluyeler p)
        {
            var uye = db.tbluyeler.Find(p.id);
            uye.ad = p.ad;
            uye.soyad = p.soyad;
            uye.mail = p.mail;
            uye.kullaniciadi = p.kullaniciadi;
            uye.sifre = p.sifre;
            uye.telefon = p.telefon;
            uye.okul = p.okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGecmis(int ID = 0)
        {
            var kitapgecmis = db.tblhareket.Where(x => x.uye == ID).ToList();
            var uyekitap = db.tbluyeler.Where(y => y.id == ID).Select(z => z.ad + " " + z.soyad).FirstOrDefault();
            ViewBag.k1 = uyekitap;
            return View(kitapgecmis);
        }
    }
}