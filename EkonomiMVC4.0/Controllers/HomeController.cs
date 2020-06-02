using EkonomiMVC4._0.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace EkonomiMVC4._0.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            
            if (login.AnvandarNamn == null || login.Losenord == null)
            {

                Logger.Info("Du måste fylla i både användarnamn och lösenord");
                ModelState.AddModelError ("","Du måste fylla i både användarnamn och lösenord");
                return View();
            }

            bool validUser = false;

            
            validUser = CheckUser(login.AnvandarNamn, login.Losenord);

            if (validUser == true)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(login.AnvandarNamn, false);
               Logger.Info("Inloggningen lyckades");
            }


            else
            {
                Logger.Error("Inloggningen ej godkänd");
                ModelState.AddModelError("", "Inloggningen misslyckades");
            }
             

            return View();

        }

        private bool CheckUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
               
                LoginModel anvandareAttKolla = new LoginModel { AnvandarNamn = username, Losenord = password };
                
                client.BaseAddress = new Uri("http://193.10.202.74/inlogg/personals");
                
                var response = client.PostAsJsonAsync("Login", anvandareAttKolla).Result;
                if (response.IsSuccessStatusCode)
                {

                    string svarFrånInloggning = response.Content.ReadAsStringAsync().Result;



                    if (svarFrånInloggning != "" && svarFrånInloggning != "0" && svarFrånInloggning != null)
                    {
                        return true;
                    }
                    else
                        return false; Logger.Info("Misslyckad inloggning");

                    
                 
                    personalModel objektFrånWS = JsonConvert.DeserializeObject<personalModel>(svarFrånInloggning);
                    if (objektFrånWS != null)
                    {
                        if (objektFrånWS.Behorighetniva == 2 || objektFrånWS.Behorighetniva == 3) 

                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false; 
                
                //Om  svaret inte är IsSuccessStatusCode så kan vi inte godkänna inloggningen
            }

            //public personalModel hamtaUser(string AnvNamn, string Losenord)
            //{
            //    personalModel svarAnv = new personalModel();

            //    svarAnv.AnvandarNamn = AnvNamn;
            //    svarAnv.Losenord = Losenord;

            //    using (var client = new HttpClient()) {

            //        client.BaseAddress = new Uri("http://193.10.202.74/inlogg/personals");
            //        var svar = client.PostAsJsonAsync("Login", svarAnv).Result;

            //        if (svar.IsSuccessStatusCode)
            //        {
            //            var personalSvar = svar.Content.ReadAsStringAsync().Result;
            //            svarAnv.Behorighetsniva = JsonConvert.DeserializeObject<personalModel>(personalSvar).Behorighetsniva;
            //        }
            //        return (svarAnv);
            //    }
        }
       
        



    }
}