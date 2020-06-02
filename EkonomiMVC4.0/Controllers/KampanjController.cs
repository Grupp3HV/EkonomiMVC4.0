using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkonomiMVC4._0.Models;
using System.Net.Http;

namespace EkonomiMVC4._0.Controllers
{
    [Authorize]
    public class KampanjController : Controller
    {
        // GET: Kampanj
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult Index()

        {
            IEnumerable<KampanjClass> kampList;
            HttpResponseMessage Svar = GlobalVariables3.client3.GetAsync("Kampanj").Result;
            kampList = Svar.Content.ReadAsAsync<IEnumerable<KampanjClass>>().Result;

            return View(kampList);
        }
        public ActionResult SUkampanj(int Id=0)
        {
            if(Id==0)
                return View(new KampanjClass());
            else
            {
                HttpResponseMessage Svar = GlobalVariables3.client3.GetAsync("Kampanj/" + Id.ToString()).Result;
                return View(Svar.Content.ReadAsAsync<KampanjClass>().Result);
            }
            
        }
        [HttpPost]
        public ActionResult SUkampanj(KampanjClass kamp)

        {
            
            if(kamp.Id == 0)
            {
                HttpResponseMessage Svar = GlobalVariables3.client3.PostAsJsonAsync("Kampanj", kamp).Result;

                
            }
            else
            {
                HttpResponseMessage Svar = GlobalVariables3.client3.PutAsJsonAsync("Kampanj/" + kamp.Id , kamp).Result;
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Radera (int id)
        {
            HttpResponseMessage Svar = GlobalVariables3.client3.DeleteAsync("Kampanj/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
    
}