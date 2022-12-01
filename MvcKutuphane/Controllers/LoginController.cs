using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(tbluyeler p)
        {
            var bilgiler = db.tbluyeler.FirstOrDefault(x => x.mail == p.mail && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.mail, false);
                Session["Mail"] = bilgiler.mail.ToString();
            //    TempData["Ad"] = bilgiler.ad.ToString();
            //    TempData["ID"] = bilgiler.id.ToString();
            //    TempData["Soyad"] = bilgiler.soyad.ToString();
            //    TempData["KullanıcıAdı"] = bilgiler.kullaniciadi.ToString();
            //    TempData["Sifre"] = bilgiler.sifre.ToString();
            //    TempData["Okul"] = bilgiler.okul.ToString();
                
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
            
        }
    }
}