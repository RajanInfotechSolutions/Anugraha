using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Purchase_Cart
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_CartId { get; set; }
        public string Anu_Product_Id { get; set; }
        public int Qty { get; set; }
        public Type Anu_Cart_type { get; set; }
        public decimal Rate { get; set; }

        [ForeignKey("Anu_Product_Id")]
        public virtual Product prdouct { get; set; }
    }
}
