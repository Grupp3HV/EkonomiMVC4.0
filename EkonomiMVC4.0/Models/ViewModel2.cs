using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkonomiMVC4._0.Models
{
    public class ViewModel2
    {
        public List<filmModell> film { get; set; }
        public List<platserModell> platser { get; set; }


        public int Id { get; set; }
        public string FilmTitel { get; set; }
        public string SalongsNamn { get; set; }



        public string AntalBokadePlatser { get; set; }
        public int VisningsSchemaId { get; set; }
    }
}