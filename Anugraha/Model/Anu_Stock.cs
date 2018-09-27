using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Stock
    {
        public Anu_Stock()
        {
            this.stdetail = new HashSet<Anu_Stock_Detail>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Anu_StockId { get; set; }
        public string Anu_Product_Id { get; set; }
        public string Anu_Stock_Product_Code { get; set; }
        public decimal Anu_Stock_Qty { get; set; }
        public Type Anu_Stock_Type { get; set; }

        [ForeignKey("Anu_Product_Id")]
        public virtual Product product { get; set; }

        public virtual ICollection<Anu_Stock_Detail> stdetail { get; set; }
    }
}
