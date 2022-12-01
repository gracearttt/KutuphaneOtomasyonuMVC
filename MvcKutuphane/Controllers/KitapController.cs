using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var kitaplar = db.tblkitap.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.tblkategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.tblyazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        
        [HttpPost]
        public ActionResult KitapEkle(tblkitap p)
        {
            var ktg = db.tblkategori.Where(k => k.id == p.tblkategori.id).FirstOrDefault();
            var yzr = db.tblyazar.Where(y => y.id == p.tblyazar.id).FirstOrDefault();
            p.tblkategori = ktg;
            p.tblyazar = yzr;
            db.tblkitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.tblkitap.Find(id);
            db.tblkitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id = 0)
        {
            var ktp = db.tblkitap.Find(id);

            List<SelectListItem> deger1 = (from i in db.tblkategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.tblyazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }

        public ActionResult KitapGuncelle(tblkitap p)
        {
            var kitap = db.tblkitap.Find(p.id);
            kitap.ad = p.ad;
            kitap.basimyili = p.basimyili;
            kitap.yayinevi = p.yayinevi;
            kitap.sayfa = p.sayfa;
            var ktg = db.tblkategori.Where(k => k.id == p.tblkategori.id).FirstOrDefault();
            var yzr = db.tblyazar.Where(k => k.id == p.tblyazar.id).FirstOrDefault();
            kitap.kategori = ktg.id;
            kitap.yazar = yzr.id;
            kitap.durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}