using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.tblkitap.ToList();
            cs.Deger2 = db.tblhakkimizda.ToList();
            //var degerler = db.tblkitap.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(tbliletisim t)
        {
            db.tbliletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}