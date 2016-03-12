using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAS.Resources;

namespace WebAS.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AddressId { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public string City { get; set; }

        //[Index]
        //[Required]
        //public string State { get; set; }

        [Required]
        [Display(Name = "Country", ResourceType = typeof(EnumResource))]
        public Country Country { get; set; }

        // TODO: 
        // public virtual LocationId {get;set;}
        // public virtual AccoutId {get;set}
    }
}