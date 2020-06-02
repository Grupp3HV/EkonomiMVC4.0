using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkonomiMVC4._0.Models
{
    public class KampanjClass
    {   
        public int Id { get; set; }
        [Required]
        public string VardeKod { get; set; }
        [Required]
        public int Bonuspoang { get; set; }
        public System.DateTime StartDatum { get; set; }
        public System.DateTime SlutDatum { get; set; }
    }
}