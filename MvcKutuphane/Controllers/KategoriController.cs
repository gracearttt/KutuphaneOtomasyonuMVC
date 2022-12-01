using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.tblkategori.Where(x => x.durum == true).ToList() ;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(tblkategori p)
        {
            db.tblkategori.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.tblkategori.Find(id);
            //   db.tblkategori.Remove(kategori);
            kategori.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.tblkategori.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(tblkategori p)
        {
            var ktg = db.tblkategori.Find(p.id);
          //  ktg.id = p.id;
            ktg.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}