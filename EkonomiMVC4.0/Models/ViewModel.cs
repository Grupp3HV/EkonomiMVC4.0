using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkonomiMVC4._0.Models
{
    public class ViewModel
    {
       public List<personalModel> personal { get; set; }
       public List<schemaModel> schema { get; set; }



        public int Id { get; set; }
        public string Måndag { get; set; }
        public string Tisdag { get; set; }
        public string Onsdag { get; set; }
        public string Torsdag { get; set; }
        public string Fredag { get; set; }
        public string Lördag { get; set; }
        public string Söndag { get; set; }

        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public string Roll { get; set; }

       
    }
}