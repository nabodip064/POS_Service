using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Service.Models
{
    public class RegisterData
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Id")]
        public string fName { get; set; }

        [Required]
        [DisplayName("Id")]
        public string lName { get; set; }

        [Required]
        [DisplayName("Id")]
        public int MyProperty { get; set; }
    }
}