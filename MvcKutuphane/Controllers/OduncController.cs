using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.tblhareket.Where(x => x.islemdurum == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.tbluyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ad + " " + x.soyad,
                                               Value = x.id.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from y in db.tblkitap.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.ad,
                                               Value = y.id.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from z in db.tblpersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.personel,
                                               Value = z.id.ToString()
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(tblhareket p)
        {
            var d1 = db.tbluyeler.Where(x => x.id == p.tbluyeler.id).FirstOrDefault();
            var d2 = db.tblkitap.Where(y => y.id == p.tblkitap.id).FirstOrDefault();
            var d3 = db.tblpersonel.Where(z => z.id == p.tblpersonel.id).FirstOrDefault();
            p.tbluyeler = d1;
            p.tblkitap = d2;
            p.tblpersonel = d3;
            db.tblhareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Odunciade(tblhareket p)
        {
            var odn = db.tblhareket.Find(p.id);
            DateTime d1 = DateTime.Parse(odn.iadetarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade", odn);
        }

        public ActionResult OduncGuncelle(tblhareket p)
        {
            var hrk = db.tblhareket.Find(p.id);
            hrk.uyegetirtarih = p.uyegetirtarih;
            hrk.islemdurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}      