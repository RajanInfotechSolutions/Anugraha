using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Product
    {
        [Key]
        public string Anu_Product_Id { get; set; }
        public string Anu_Category_Id { get; set; }
        public string Anu_Product_Code { get; set; }
        public string Anu_Product_Name { get; set; }
        public decimal Anu_Product_Rate { get; set; }
        public Type type { get; set; }
        public bool Anu_Product_IsActive { get; set; }
        public string Anu_Product_CreatedBy { get; set; }
        public DateTime Anu_Product_CreatedDate { get; set; }
        public string Anu_Product_ModifiedBy { get; set; }
        public DateTime? Anu_Product_ModifiedDate { get; set; }


        [ForeignKey("Anu_Category_Id")]
        public virtual Anu_Category_Detail detail { get; set; }

    }

    public enum Type
    {
        SP,
        GM,
        KG,
        LR
    }
}
