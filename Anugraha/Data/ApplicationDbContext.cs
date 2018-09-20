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
    }
}
