using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class Currency
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Currency Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Symbol")]
        public string Symbol { get; set; }

        [Display(Name = "ISO Code")]
        public string ISOCode { get; set; }
        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}