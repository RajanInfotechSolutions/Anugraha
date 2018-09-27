using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Log_History
    {
        //public Anu_Log_History()
        //{
        //    this.user = new HashSet<Anu_User>();
        //}


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_LogID { get; set; }
        public DateTime Anu_LAST_LOGGED_In { get; set; }
        public DateTime? Anu_LAST_LOGGED_Out { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }


        //public virtual ICollection<Anu_User> user { get; set; }



    }
}
