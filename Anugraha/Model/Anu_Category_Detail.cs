using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anugraha.Model
{
    public class Anu_Category_Detail
    {
        public Anu_Category_Detail()
        {
            this.product = new HashSet<Product>();
        }

        [Key]
        public string Anu_Category_Id { get; set; }
        public string Anu_Category_Name { get; set; }
        public string Anu_Category_Code { get; set; }
        public bool Anu_Category_IsActive { get; set; }
        public string Anu_Category_CreatedBy { get; set; }
        public DateTime Anu_Category_CreatedDate { get; set; }
        public string Anu_Category_ModifiedBy { get; set; }
        public DateTime? Anu_Category_ModifiedDate { get; set; }

        public virtual ICollection<Product> product { get; set; }
    }
}
