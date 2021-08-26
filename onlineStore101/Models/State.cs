using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class State
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "State ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "State Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}