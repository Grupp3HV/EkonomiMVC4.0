using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkonomiMVC4._0.Models
{
    public class personalModel
    {

        public int Id { get; set; }
        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public string Roll { get; set; }
        public string AnvandarNamn { get; set; }
        public string Losenord { get; set; }
        public int Behorighetniva { get; set; }
        public int RefId { get; set; }
       

    }
}