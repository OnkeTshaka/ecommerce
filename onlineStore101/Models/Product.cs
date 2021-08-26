using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public enum Condition
    {
        Good,
        decent,
        excellent
    }
    public class Product
    {
        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Enter Price.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }

        [Display(Name = "Posting Time")]
        public DateTime PostingTime { get; set; }

        [Required(ErrorMessage = "Operating System is required.")]
        [Display(Name = "Operating System")]
        public string OperatingSystem { get; set; }

        [Required(ErrorMessage = "Ram is required.")]
        [Display(Name = "Ram")]
        public string Ram { get; set; }

        [Required(ErrorMessage = "Processor is required.")]
        [Display(Name = "Processor")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Hard Disk is required.")]
        [Display(Name = "Hard Disk")]
        public string HardDisk { get; set; }
        public Condition Condition { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }


        [ForeignKey("Category")]
        public int catId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Currency")]
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City")]
        public int CityID { get; set; }
        public virtual City City { get; set; }

        [ForeignKey("State")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public virtual State State { get; set; }


        [ForeignKey("Country")]
        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey("AccessoryBrand")]
        [Display(Name = "Accessory Brand")]
        public int AccessoryBrandID { get; set; }
        public virtual AccessoryBrand AccessoryBrand { get; set; }


        [ForeignKey("Seller")]
        [Display(Name = "Seller")]
        public string SellerID { get; set; }
        public virtual ApplicationUser Seller { get; set; }
    }
}