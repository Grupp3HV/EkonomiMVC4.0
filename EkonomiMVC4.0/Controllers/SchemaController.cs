using EkonomiMVC4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EkonomiMVC4._0.Controllers
{
    [Authorize]
    public class SchemaController : Controller
    {
        //[HttpPost]
        //public ActionResult Visa(personalModel personal)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        personalModel p = new personalModel { Namn = personal.Namn, Efternamn = personal.Efternamn, Roll = personal.Roll };
        //        client.BaseAddress = new Uri("http://193.10.202.74/personal/personal");

        //        var PostPers = client.PostAsJsonAsync("personal", personal).Id;

        //        if(PostPers != 0)
        //        {
        //            personal.Id = PostPers;

        //            personalModel k = new personalModel { Namn = personal.Namn, Efternamn = personal.Efternamn, Roll = personal.Roll };

        //            return RedirectToAction("Index","Schema");
                    
        //        }
        //        return View(personal);
        //    }
            
        //}
        // GET: Schema
        public ActionResult Index()
        {
           
            List<schemaModel> schemaList;
            HttpResponseMessage svar = GlobalVariables.client.GetAsync("Schema/").Result;
            schemaList = svar.Content.ReadAsAsync<List<schemaModel>>().Result;


            List<personalModel> personalList;
            HttpResponseMessage svar2 = GlobalVariables2.client2.GetAsync("personal/").Result;
            personalList = svar2.Content.ReadAsAsync<List<personalModel>>().Result;

            ViewModel model = new ViewModel();
            model.personal = personalList;
            model.schema = schemaList;


            return View(model);
        }

        public ActionResult SkapaLrUppdatera(int id =0)
        {

            if(id == 0)
            
                return View(new schemaModel());
            
            else
            {
                HttpResponseMessage svar = GlobalVariables.client.GetAsync("Schema/" + id.ToString()).Result;
                return View(svar.Content.ReadAsAsync<schemaModel>().Result);
            }
            
          
        }
        [HttpPost]
        public ActionResult SkapaLrUppdatera(schemaModel temp)

        {
            if(temp.Id == 0)
            {
                HttpResponseMessage svar = GlobalVariables.client.PostAsJsonAsync("Schema/", temp).Result;
            }
            else
            {
                HttpResponseMessage svar = GlobalVariables.client.PutAsJsonAsync("Schema/"+temp.Id, temp).Result;
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Radera (int id)
        {
            HttpResponseMessage svar = GlobalVariables.client.DeleteAsync("Schema/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

        
    }



}








//using (var client = new HttpClient())
//            {
//                personalModel P = new personalModel { Id = id, Roll = roll, Namn = namn, Efternamn = efternamn };
//client.BaseAddress = new Uri("http://193.10.202.74/personal/personal");
//var response = client.PostAsJsonAsync("personal", P).Id;
//            }



//            return View(Response);