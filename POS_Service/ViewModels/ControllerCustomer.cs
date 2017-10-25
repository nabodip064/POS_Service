using POS_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Service.ViewModels
{
    public class ControllerCustomer
    {
        public CustomerData customerdata { get; set; }
        public List<ChosenProduct> choseList { get; set; }
    }
}