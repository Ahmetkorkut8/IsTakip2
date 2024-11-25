using IsTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakip.Controllers
{
    public class YoneticiController : Controller
    {
        DBIstakipEntities  entity= new DBIstakipEntities();
        // GET: Yonetici
        public ActionResult Index()
        {
            int yetkiTurId = Convert.ToInt32(Session["PERSONELYETKIID"]);
            if (yetkiTurId == 1)
            {
                int birimId = Convert.ToInt32(Session["PERSONELBIRIMID"]);
                var birim =(from b in entity.BIRIMLER where b.BIRIMID == birimId select b).FirstOrDefault();
                ViewBag.birimad = birim.BIRIMAD;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        public ActionResult Ata()
        {
            int yetkiTurId = Convert.ToInt32(Session["PERSONELYETKIID"]);
            if (yetkiTurId == 1)
            {
                int birimId = Convert.ToInt32(Session["PERSONELBIRIMID"]);
                var calisanlar = (from p in entity.T_PERSONEL where p.PERSONELBIRIMID == birimId && p.PERSONELYETKIID == 2
                                  select p).ToList(); 
                ViewBag.personeller= calisanlar;
                var birim = (from b in entity.BIRIMLER where b.BIRIMID == birimId select b).FirstOrDefault();
                ViewBag.birimad = birim.BIRIMAD;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult Ata(FormCollection formCollection)
        {
            string isBaslik = formCollection["isBaslik"];
            string isAciklama = formCollection["isAciklama"];
            int secilenPersonelId = Convert.ToInt32(formCollection["selectPer"]);

            ISLER yeniIs = new ISLER();
            yeniIs.ISBASLIK = isBaslik;
            yeniIs.ISACIKLAMA = isAciklama;
            yeniIs.ILETILENTARIH = DateTime.Now;
            yeniIs.ISDURUMID = 1;

            entity.ISLER.Add(yeniIs);
            entity.SaveChanges();

         return RedirectToAction("Takip", "Yonetici");
        }
        public ActionResult Takip()
        {
            int yetkiTurId = Convert.ToInt32(Session["PERSONELYETKIID"]);
            if (yetkiTurId == 1)
            {
                int birimId = Convert.ToInt32(Session["PERSONELBIRIMID"]);
                var birim = (from b in entity.BIRIMLER where b.BIRIMID == birimId select b).FirstOrDefault();
                ViewBag.birimad = birim.BIRIMAD;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}