using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS_Service.Models
{
    public class ChosenProduct
    {
        [Key]
        [DisplayName("Id")]
        public int? Id { get; set; }

        [DisplayName("Guid")]
        public string guid { get; set; }

        [DisplayName("Product Id")]
        public int productId { get; set; }

        [DisplayName("Product Quantity")]
        public int quantity { get; set; }
        
        [DisplayName("Product Name")]
        public string productName { get; set; }
    
        [DisplayName("Product Price")]
        public decimal productPrice { get; set; }
    }
}