using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace onlineStore101.Models
{
    public class Review
    {

        [Key, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MinLength(50)]
        [RegularExpression(@"^[\s\S]{50,}$", ErrorMessage = "Minimum 50 Characters required for the review.")]
        [Required]
        [Display(Name = "Review.")]
        public string Content { get; set; }

        [Required]
        public DateTime PostingTime { get; set; }

        [Display(Name = "Review Stars.")]
        public int ReviewStars { get; set; }

        [ForeignKey("Seller")]
        [Display(Name = "Reviewer is Required.")]
        public string SellerID { get; set; }
        //I know it should be UserID but on our website whoever is registered is a Seller

        [ForeignKey("Product")]
        [Display(Name = "Ad Details are Required.")]
        public int productID { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser Seller { get; set; }
    }
}