using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class City
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "City ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "City Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [ForeignKey("State")]
        public int StateID { get; set; }
        public virtual State State { get; set; }
    }
}