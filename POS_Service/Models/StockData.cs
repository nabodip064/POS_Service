using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Service.Models
{
    public class StockData
    {
        [Key]
        [Required]
        [DisplayName("Product Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public decimal ProductPrice { get; set; }

        [Required]
        [DisplayName("Quantity of Stock")]
        public int ProductQuantity { get; set; }

        [Required]
        [DisplayName("Image of Product")]
        public string ProductImage { get; set; }
    }
}