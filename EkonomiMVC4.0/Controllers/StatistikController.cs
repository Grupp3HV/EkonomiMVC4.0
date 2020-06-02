using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EkonomiMVC4._0.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EkonomiMVC4._0.Controllers
{
    [Authorize]
    public class StatistikController : Controller
    {
        // GET: Statistik
        
        
            //Hosted web API REST Service base url  
            string Baseurl = "http://193.10.202.72/";
            public async Task<ActionResult> Index()
            {
                List<platserModell> StatInfo = new List<platserModell>();
                List<filmModell> FilmInfo = new List<filmModell>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("BiljettService/Bokadeplatser");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var StatResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    StatInfo = JsonConvert.DeserializeObject<List<platserModell>>(StatResponse);

                }
            

            }
            //returning the employee list to view  

            using (var client = new HttpClient())
            {
             

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res2 = await client.GetAsync("BiljettService/VisningsSchema");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var FilmResponse = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    FilmInfo = JsonConvert.DeserializeObject<List<filmModell>>(FilmResponse);

                }


                   
            }

            //returning the employee list to view  


            ViewModel2 model2 = new ViewModel2();
            model2.platser = StatInfo;
            model2.film = FilmInfo;
            return View(model2);
        }  
        
    }
}
//visningsSchema = JsonConvert.DeserializeObject<List<filmModell>>

//     List<filmModell> visningsSchema;
//HttpResponseMessage svar3 = GlobalVariables3.client3.GetAsync("BiljettService").Result;
//visningsSchema = svar3.Content.ReadAsAsync<List<filmModell>>().Result;


//            List<platserModell> bokadeplatser;
//HttpResponseMessage svar4 = GlobalVariables4.client4.GetAsync("BiljettService").Result;
//bokadeplatser = svar4.Content.ReadAsAsync<List<platserModell>>().Result;
