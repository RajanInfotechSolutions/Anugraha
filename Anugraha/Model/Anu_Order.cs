using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Order
    {
        public Anu_Order()
        {
            this.orderdetail = new HashSet<Anu_Order_Detail>();
        }
        [Key]
        public string Anu_Order_Id { get; set; }
        public DateTime Anu_Order_OrderDate { get; set; }
        public decimal Anu_Order_TotalAmount { get; set; }
        public int Anu_Order_TotalQty { get; set; }
        public Mode Anu_Order_Mode { get; set; }
        public Status Anu_Order_Status { get; set; }
        public bool Anu_Order_IsActive { get; set; }
        public string Anu_Order_Createdby { get; set; }
        public DateTime Anu_Order_CreatedDate { get; set; }
        public string Anu_Order_ModifiedBy { get; set; }
        public DateTime? Anu_Order_ModifiedDate { get; set; }


        public virtual ICollection<Anu_Order_Detail> orderdetail { get; set; }
    }

    public enum Mode
    {
        Cash,
        Credit,
        Card
    }
}
