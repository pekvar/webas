using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAS.Resources;

namespace WebAS.Models
{
    [Authorize]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "LocationId", ResourceType=typeof(ModelResource))]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Latitude", ResourceType = typeof(ModelResource))]
        public string Latitude { get; set; }

        [Required]
        [Display(Name = "Longitude", ResourceType = typeof(ModelResource))]
        public string Longitude { get; set; }

        [Required]
        [Display(Name = "Altitude", ResourceType = typeof(ModelResource))]
        public string Altitude { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(ModelResource))]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ModelResource))]
        public string Description { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }

        public Address Address { get; set; }
    }
}