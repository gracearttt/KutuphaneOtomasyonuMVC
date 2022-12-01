using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.tblhareket.Where(x => x.islemdurum == true).ToList();
            return View(degerler);
        }
    }
}