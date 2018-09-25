using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Purchase_Detail
    {
        [Key]
        public string Anu_Purchase_Detail_Id { get; set; }
        public string Anu_Purchase_Id { get; set; }
        public string Anu_Product_Id { get; set; }
        public string Anu_Purchase_Detail_Qty { get; set; }
        public Type Anu_Purchase_Detail_type { get; set; }
        public decimal Anu_Purchase_Detail_Rate { get; set; }

        [ForeignKey("Anu_Purchase_Id")]
        public virtual Anu_Purchase anuPurchase { get; set; }
        [ForeignKey("Anu_Product_Id")]
        public virtual Product product { get; set; }

    }
}
