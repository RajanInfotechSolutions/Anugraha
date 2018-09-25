using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Order_Detail
    {
        [Key]
        public string Anu_Order_Detail_Id { get; set; }
        public string Anu_Order_Id { get; set; }
        public string Anu_Product_Id { get; set; }
        public string Anu_Order_Detail_Qty { get; set; }
        public Type Anu_Order_Detail_Type { get; set; }
        public decimal Anu_Order_Detail_Rate { get; set; }
        public decimal Anu_Order_Detail_Subtotal { get; set; }
        public decimal Anu_Order_Detail_Discount { get; set; }
        public decimal Anu_Order_Detail_ReceivedAmount { get; set; }
        public decimal Anu_Order_Detail_RemainingAmount { get; set; }


        [ForeignKey("Anu_Order_Id")]
        public virtual Anu_Order order { get; set; }

        [ForeignKey("Anu_Product_Id")]
        public virtual Product product { get; set; }


    }
}
