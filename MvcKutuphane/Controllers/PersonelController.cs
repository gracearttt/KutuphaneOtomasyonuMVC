using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.tblpersonel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(tblpersonel p)
        {
            db.tblpersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.tblpersonel.Find(id);
            db.tblpersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var ktg = db.tblpersonel.Find(id);
            return View("PersonelGetir", ktg);
        }

        public ActionResult PersonelGuncelle(tblpersonel p)
        {
            var prs = db.tblpersonel.Find(p.id);
            prs.personel = p.personel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}