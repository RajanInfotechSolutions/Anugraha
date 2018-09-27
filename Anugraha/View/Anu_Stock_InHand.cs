using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anugraha.Data;
using System.Data.Entity;

namespace Anugraha.View
{
    public partial class Anu_Stock_InHand : UserControl
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Stock_InHand _instance;
        public static Anu_Stock_InHand Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Stock_InHand();
                return _instance;
            }
        }


        public Anu_Stock_InHand()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome" + SessionMgr.UserId;

            var grd = from a in _context.Anu_Stocks.Include(vv => vv.product)
                      select new
                      {
                          Id = a.Anu_StockId,
                          Prouct_Name = a.product.Anu_Product_Name,
                          Product_Code = a.Anu_Stock_Product_Code,
                          Quantity = a.Anu_Stock_Qty + " " + Model.Type.KG
                      };

            stockGrid.DataSource = grd.OrderBy(a => a.Prouct_Name).ToList();

            stockGrid.Columns[0].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtsrc_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtsrc.Text.Trim()))
            {
                var txt = txtsrc.Text.Trim().ToString();
                var grd = from a in _context.Anu_Stocks.Include(vv => vv.product)
                          where(a.Anu_Stock_Product_Code.Contains(txtsrc.Text.Trim()) || a.product.Anu_Product_Name.Contains(txtsrc.Text.Trim()) || a.Anu_Stock_Qty.ToString().Contains(txtsrc.Text.Trim()))
                          select new
                          {
                              Id = a.Anu_StockId,
                              Prouct_Name = a.product.Anu_Product_Name,
                              Product_Code = a.Anu_Stock_Product_Code,
                              Quantity = a.Anu_Stock_Qty + " " + Model.Type.KG
                          };

                stockGrid.DataSource = grd.OrderBy(a => a.Prouct_Name).ToList();
            }
            else
            {
                var grd = from a in _context.Anu_Stocks.Include(vv => vv.product)
                          select new
                          {
                              Id = a.Anu_StockId,
                              Prouct_Name = a.product.Anu_Product_Name,
                              Product_Code = a.Anu_Stock_Product_Code,
                              Quantity = a.Anu_Stock_Qty + " " + Model.Type.KG
                          };

                stockGrid.DataSource = grd.OrderBy(a => a.Prouct_Name).ToList();
            }
        }
    }
}
