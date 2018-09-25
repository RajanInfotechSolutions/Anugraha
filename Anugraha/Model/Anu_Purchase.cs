using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Purchase
    {
        public Anu_Purchase()
        {
            this.purdetail = new HashSet<Anu_Purchase_Detail>();
        }

        [Key]
        public string Anu_Purchase_Id { get; set; }
        public string Anu_Purchase_InvoiceNo { get; set; }
        public string Anu_Vendor_Id { get; set; }
        public DateTime Anu_Purchase_Invoice_Date { get; set; }
        public int Anu_Purchase_Quantity { get; set; }
        public decimal Anu_Purchase_Amount { get; set; }
        public Status Status { get; set; }
        public bool Anu_Purchase_IsActive { get; set; }
        public string Anu_Purchase_CreatedBy { get; set; }
        public DateTime Anu_Purchase_CreatedDate { get; set; }
        public string Anu_Purchase_ModifiedBy { get; set; }
        public DateTime? Anu_Purchase_ModifiedDate { get; set; }

        [ForeignKey("Anu_Vendor_Id")]
        public virtual Anu_Vendor_Detail vddetail { get; set; }
        public virtual ICollection<Anu_Purchase_Detail> purdetail { get; set; }



    }

    public enum Status
    {
        Paid,
        UnPaid
    }
}
