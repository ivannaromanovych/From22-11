using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeWorkCRUD.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnect")
        {
        }
        public DbSet<ProductModel> ProductModels { get; set; }
    }
}