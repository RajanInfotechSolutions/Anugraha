using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_User
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_USERID { get; set; }
        public int Anu_Company_Id { get; set; }
        public string Anu_USERNAME { get; set; }
        public string Anu_PASSWORD { get; set; }
        public string Anu_CONFIRM_PASSWORD { get; set; }
        public string Anu_MAC_ADDRESS { get; set; }
        public int Anu_LogID { get; set; }
        public string Anu_ISACTIVE { get; set; }

        [ForeignKey("Anu_LogID")]
        public virtual Anu_Log_History history { get; set; }

        [ForeignKey("Anu_Company_Id")]
        public virtual Anu_Company_Detail company { get; set; }
    }
}
