using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.tbluyeler.FirstOrDefault(z => z.mail == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(tbluyeler p) 
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.tbluyeler.FirstOrDefault(x => x.mail == kullanici);
            uye.sifre = p.sifre;
            uye.ad = p.ad;
            uye.fotograf = p.fotograf;
            uye.okul = p.okul;
            uye.kullaniciadi = p.kullaniciadi;
            db.SaveChanges();
            return View();
        }

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.tbluyeler.Where(x => x.mail == kullanici.ToString()).Select(z => z.id).FirstOrDefault();
            var degerler = db.tblhareket.Where(x => x.uye == id).ToList();
            return View(degerler);
        }
    }
}