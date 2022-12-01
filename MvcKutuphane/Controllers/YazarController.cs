using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.tblyazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(tblyazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
           
            db.tblyazar.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.tblyazar.Find(id);
            db.tblyazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YazarGetir(int id)
        {
            var yzr = db.tblyazar.Find(id);
            return View("YazarGetir", yzr);
        }

        public ActionResult YazarGuncelle(tblyazar p)
        {
            var yzr = db.tblyazar.Find(p.id);
            
            yzr.ad = p.ad;
            yzr.soyad = p.soyad;
            yzr.detay = p.detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult YazarKitaplar(int ID=0) {

            var yazar = db.tblkitap.Where(x => x.yazar == ID).ToList();
            var yazarad = db.tblyazar.Where(y => y.id == ID).Select(z => z.ad + " " + z.soyad).FirstOrDefault();
            ViewBag.y1 = yazarad;
            return View(yazar);
        }
    }
}