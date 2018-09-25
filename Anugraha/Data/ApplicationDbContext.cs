using Anugraha.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name = ANU_Connection_String") { }


        public DbSet<Anu_User> Anu_Users { get; set; }
        public DbSet<Anu_Log_History> Anu_Log_Histories { get; set; }
        public DbSet<Anu_Company_Detail> Anu_Company_Details { get; set; }
        public DbSet<Anu_Category_Detail> Anu_Category_Details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Anu_Vendor_Detail> Anu_Vendor_Detail { get; set; }
        public DbSet<Anu_Purchase> Anu_Purchases { get; set; }
        public DbSet<Anu_Purchase_Detail> Anu_Purchase_Details { get; set; }
        public DbSet<Anu_Purchase_Cart> Anu_Purchase_Cart { get; set; }
        public DbSet<Anu_Stock> Anu_Stocks { get; set; }
        public DbSet<Anu_Stock_Detail> Anu_Stock_Detail { get; set; }
        public DbSet<Anu_Order> Anu_Orders { get; set; }
        public DbSet<Anu_Order_Detail> Anu_Order_Details { get; set; }
        public DbSet<Anu_Cart> Anu_Carts { get; set; }

    }
}
