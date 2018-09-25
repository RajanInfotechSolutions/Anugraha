using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Vendor_Detail
    {
        public Anu_Vendor_Detail()
        {
            this.purchase = new HashSet<Anu_Purchase>();
        }

        [Key]
        public string Anu_Vendor_Id { get; set; }
        public string Anu_Vendor_Company_Name { get; set; }
        public string Anu_Vendor_Company_Owner { get; set; }
        public string Anu_Vendor_Company_Address1 { get; set; }
        public string Anu_Vendor_Company_Address2 { get; set; }
        public string Anu_Vendor_Company_City { get; set; }
        public string Anu_Vendor_Company_State { get; set; }
        public string Anu_Vendor_Company_PinCode { get; set; }
        public string Anu_Vendor_Company_MobileNo { get; set; }
        public string Anu_Vendor_Company_Landline { get; set; }
        public string Anu_Vendor_Company_Email { get; set; }
        public string Anu_Vendor_Company_GST { get; set; }
        public string Anu_Vendor_Company_ACNO { get; set; }
        public string Anu_Vendor_Company_IFSC { get; set; }
        public bool Anu_Vendor_IsActive { get; set; }
        public string Anu_Vendor_CreatedBy { get; set; }
        public DateTime Anu_Vendor_CreatedDate { get; set; }
        public string Anu_Vendor_ModifiedBy { get; set; }
        public DateTime? Anu_Vendor_ModifiedDate { get; set; }


        public virtual ICollection<Anu_Purchase> purchase { get; set; }

    }
}
