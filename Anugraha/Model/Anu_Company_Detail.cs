using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Company_Detail
    {

        //public Anu_Company_Detail()
        //{
        //    this.user = new HashSet<Anu_User>();
        //}


        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_Company_Id { get; set; }
        public string Anu_Company_Name { get; set; }
        public string Anu_Company_Owner { get; set; }
        public string Anu_Company_Address1 { get; set; }
        public string Anu_Company_Address2 { get; set; }
        public string Anu_Company_City { get; set; }
        public string Anu_Company_State { get; set; }
        public string Anu_Company_PinCode { get; set; }
        public string Anu_Company_MobileNo { get; set; }
        public string Anu_Company_Landline { get; set; }
        public string Anu_Company_Email { get; set; }
        public bool Anu_Company_IsActive { get; set; }
        public string Anu_Company_CreatedBy { get; set; }
        public DateTime Anu_Company_CreatedDate { get; set; }
        public string Anu_Company_ModifiedBy { get; set; }
        public DateTime? Anu_Company_ModifiedDate { get; set; }

        //public virtual ICollection<Anu_User> user { get; set; }
    }
}
