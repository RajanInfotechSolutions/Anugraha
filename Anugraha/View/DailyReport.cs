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

namespace Anugraha.View
{
    public partial class DailyReport : UserControl
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        private static DailyReport _instance;
        public static DailyReport Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DailyReport();
                return _instance;
            }
        }

        public DailyReport()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome" + SessionMgr.UserId;

            DateTime StartDate = dateTimePicker1.Value.Date;
            DateTime EndDate = dateTimePicker1.Value.Date.AddDays(1).AddTicks(-1);

            var grd = from a in _context.Anu_Orders
                      where (a.Anu_Order_CreatedDate > StartDate && a.Anu_Order_CreatedDate <= EndDate && a.Anu_Order_IsActive == true && a.Anu_Order_Status == Model.Status.Paid)
                      select new
                      {
                          InvoiceNo = a.Anu_Order_Id,
                          InvoiceDate = a.Anu_Order_OrderDate,
                          BillAmount = a.Anu_Order_TotalAmount,
                          Status = a.Anu_Order_Status.ToString()
                      };

            dsrgrid.DataSource = grd.OrderBy(a=>a.InvoiceNo).ToList();

            var today = _context.Anu_Orders.Where(a => a.Anu_Order_CreatedDate > StartDate && a.Anu_Order_CreatedDate <= EndDate && a.Anu_Order_IsActive == true && a.Anu_Order_IsActive == true && a.Anu_Order_Status == Model.Status.Paid).Count();
            if(today != 0)
            {

                var amt = _context.Anu_Orders.Where(a => a.Anu_Order_CreatedDate > StartDate && a.Anu_Order_CreatedDate <= EndDate && a.Anu_Order_IsActive == true && a.Anu_Order_IsActive == true && a.Anu_Order_Status == Model.Status.Paid).Sum(a => a.Anu_Order_TotalAmount);
                lblTotal.Text = Convert.ToDecimal(amt).ToString();
            }
            else
            {
                lblTotal.Text = "0.00";
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime StartDate = dateTimePicker1.Value.Date;
                DateTime EndDate = dateTimePicker1.Value.Date.AddDays(1).AddTicks(-1);

                var grd = from a in _context.Anu_Orders
                          where (a.Anu_Order_CreatedDate > StartDate && a.Anu_Order_CreatedDate <= EndDate && a.Anu_Order_IsActive == true && a.Anu_Order_Status == Model.Status.Paid)
                          select new
                          {
                              InvoiceNo = a.Anu_Order_Id,
                              InvoiceDate = a.Anu_Order_OrderDate,
                              BillAmount = a.Anu_Order_TotalAmount,
                              Status = a.Anu_Order_Status.ToString()
                          };

                dsrgrid.DataSource = grd.OrderBy(a => a.InvoiceNo).ToList();

                var amt = _context.Anu_Orders.Where(a => a.Anu_Order_CreatedDate > StartDate && a.Anu_Order_CreatedDate <= EndDate && a.Anu_Order_IsActive == true && a.Anu_Order_IsActive == true && a.Anu_Order_Status == Model.Status.Paid).Sum(a => a.Anu_Order_TotalAmount);
                lblTotal.Text = Convert.ToDecimal(amt).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
