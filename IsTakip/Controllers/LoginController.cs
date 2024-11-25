using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsTakip.Models; 

namespace IsTakip.Controllers
{
    public class LoginController : Controller
    {
        DBIstakipEntities entity = new DBIstakipEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
            ViewBag.mesaj = null;
        }
        [HttpPost]
        public ActionResult Index(string kullaniciAd, string parola)
        {

            var personel =(from p in entity.T_PERSONEL where p.PERSONELKULLANICIAD == kullaniciAd &&
                           p.PERSONELPAROLA==parola select p ).FirstOrDefault();
            if (personel != null)
            {

                Session["PERSONELADSOYAD"] = personel.PERSONELADSOYAD;
                Session["PERSONELID"] = personel.PERSONELID;
                Session["PERSONELBIRIMID"] = personel.PERSONELBIRIMID;
                Session["PERSONELYETKIID"] = personel.PERSONELYETKIID;

                switch (personel.PERSONELYETKIID)
                {
                    case 1:
                        return RedirectToAction("Index","Yonetici");
                        case 2:
                        return RedirectToAction("Index", "Calisan");
                    default:
                        return View();
                }  
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı Adı ya da parola yanlış";
                return View();
            }
        }

    }
}