using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace EkonomiMVC4._0
{
    public static class GlobalVariables
    {
        public static HttpClient client = new HttpClient();

       static GlobalVariables()
        {
            client.BaseAddress = new Uri("http://193.10.202.73/EkonomiStatistik/Schema");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
       
    }
    

    public static class GlobalVariables2

    {
        public static HttpClient client2 = new HttpClient();
        static GlobalVariables2()
        {
            client2.BaseAddress = new Uri("http://193.10.202.74/personal/personal");

            client2.DefaultRequestHeaders.Clear();
            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
    public static class GlobalVariables3

    {
        public static HttpClient client3 = new HttpClient();
        static GlobalVariables3()
        {
            client3.BaseAddress = new Uri("http://193.10.202.73/Kampanj/Kampanj");

            client3.DefaultRequestHeaders.Clear();
            client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
    //public static class GlobalVariables4

    //{
    //    public static HttpClient client4 = new HttpClient();
    //    static GlobalVariables4()
    //    {
    //        client4.BaseAddress = new Uri("http://193.10.202.72/BiljettService/VisningsSchema");

    //        client4.DefaultRequestHeaders.Clear();
    //        client4.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //    }
    //}

}
