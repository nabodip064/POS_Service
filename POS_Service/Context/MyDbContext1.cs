using POS_Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace POS_Service.Context
{
    public class MyDbContext1 : DbContext
    {
        public DbSet<StockData> stocks { get; set; }
        public DbSet<LogInData> login { get; set; }
        public DbSet<ChosenProduct> chosenProducts { get; set; }
        public DbSet<CustomerData> customers { get; set; }
        public MyDbContext1()
        {

        }
    }
}