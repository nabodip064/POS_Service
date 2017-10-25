using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS_Service.Models
{
    public class LogInData
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }


        [Required]
        [DisplayName("First Name")]
        public string fName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime dateOfBrt { get; set; }

        [Required]
        [DisplayName("Username")]
        public string username { get; set; }

        [Required]
        [PasswordPropertyText]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [PasswordPropertyText]
        [DisplayName("Confirm Password")]
        public string cfmPass { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Required]
        [DisplayName("Designation")]
        public string designation { get; set; }
        
        [Required]
        [DisplayName("IsGraduate ?")]
        public bool isGradute { get; set; }

        [Required]
        [DisplayName("Address")]
        public string address { get; set; }

        [Required]
        [DisplayName("Email")]
        public string email { get; set; }
    }
}
