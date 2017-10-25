using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Service.Models
{
    public class CustomerData
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Customer Address")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Customer mobile number")]
        public string FnNumber { get; set; }

        [Required]
        [DisplayName("Customer Type")]
        public int CustomerType { get; set; }

        [DisplayName("Guid")]
        public String guid { get; set; }

        public bool IsDeliveried { get; set; }
    }
}