using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class Country
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Country ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Country Name is must required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}