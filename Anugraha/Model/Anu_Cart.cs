using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Cart
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_Cart_Id { get; set; }
        public string Anu_Product_Id { get; set; }
        public string Anu_cart_Qty { get; set; }
        public Type Anu_cart_Type { get; set; }
        public decimal Anu_cart_Rate { get; set; }

        [ForeignKey("Anu_Product_Id")]
        public virtual Product product { get; set; }
    }
}
