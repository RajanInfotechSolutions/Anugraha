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
using Anugraha.Model;

namespace Anugraha.View
{
    public partial class Anu_Purchase_Entry : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Purchase_Entry _instance;
        public static Anu_Purchase_Entry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Purchase_Entry();
                return _instance;
            }
        }

        public string ProductId;
        public string VendorId;
        public string PurchseNo;
        public decimal TotalAmount;
        public string PDetailId;

        public Anu_Purchase_Entry()
        {
            InitializeComponent();
            Init();


        }
        public void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome" + SessionMgr.UserId;
            txtsrc.Focus();

            TypeCombo.DisplayMember = "Text";
            TypeCombo.ValueMember = "Value";


            var items = new[]
            {

                 new {Text = "SP", Value="0"},
                new {Text = "GM", Value="1"},
                new {Text = "KG", Value="2"},
                new {Text = "LR", Value="3"}

            };

            TypeCombo.DataSource = items;

            TypeCombo.SelectedIndex = 0;

            lblitem.Text = "0";
            lblamount.Text = "0.00";
            lblQty.Text = "0";

            var prdid = "";

            var IsHave = _context.Anu_Purchases.Where(a => a.Anu_Purchase_IsActive == true && a.Anu_Purchase_Id != null).Count();
            if (IsHave != 0)
            {
                long urn = 1;
                var MaxURN = (from a in _context.Anu_Purchases select a).AsEnumerable().Max(p => p.Anu_Purchase_Id.Split('-')[1]);
                if (MaxURN != null)
                {
                    urn = Convert.ToInt64(MaxURN) + 1;
                }
                prdid = "AGPPURINV" + DateTime.Now.Year + "-" + urn.ToString("0000");
                PurchseNo = "AGPPUR" + "-" + urn.ToString("0000");
            }
            else
            {
                long urn = 1;
                PurchseNo = "AGPPUR" + "-" + urn.ToString("0000");
                prdid = "AGPPURINV" +DateTime.Now.Year + "-" + urn.ToString("0000");
            }
            lblInvoice.Text = prdid;

            vendCombo.DataSource = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true).ToList();
            vendCombo.DisplayMember = "Anu_Vendor_Company_Name";
            vendCombo.ValueMember = "Anu_Vendor_Id";
            prdgrid.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void vendCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = vendCombo.SelectedValue.ToString();
            var comb = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true && a.Anu_Vendor_Id == id).SingleOrDefault();
            lblvenId.Text = comb.Anu_Vendor_Id.ToUpper();
            lblvenMob.Text = comb.Anu_Vendor_Company_MobileNo.ToUpper();
            lblvenGst.Text = comb.Anu_Vendor_Company_GST;
        }

        private void txtsrc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsrc.Text.Trim()))
            {
                prdgrid.Visible = true;
                var grd = from a in _context.Products.Include(b => b.detail)
                          where (a.Anu_Product_Id.Contains(txtsrc.Text.Trim()) && a.Anu_Product_IsActive == true || a.Anu_Product_Code.Contains(txtsrc.Text.Trim()) && a.Anu_Product_IsActive == true || a.Anu_Product_Name.Contains(txtsrc.Text.Trim()) && a.Anu_Product_IsActive == true)
                          select new
                          {
                              Id = a.Anu_Product_Id,
                              Category = a.detail.Anu_Category_Name,
                              Code = a.Anu_Product_Code,
                              Name = a.Anu_Product_Name,
                              Type = a.type.ToString(),
                              Rate = a.Anu_Product_Rate
                          };

                prdgrid.DataSource = grd.ToList();

                prdgrid.Columns[0].Visible = false;
            }
            else
            {
                prdgrid.Visible = false;
            }
        }

        private void prdgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var prdgrid = (DataGridView)sender;
                ProductId = prdgrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                prdgrid.Visible = false;
                var prd = _context.Products.Include(a => a.detail).Where(b => b.Anu_Product_IsActive == true && b.Anu_Product_Id.Contains(ProductId)).SingleOrDefault();
                lblPrdName.Text = prd.Anu_Product_Name;
                lblcat.Text = prd.detail.Anu_Category_Name;

                txtsrc.Text = "";
                txtsrc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQty.Text.Trim()) && string.IsNullOrEmpty(txtAmt.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtQty.Text.Trim()))
                {
                    errorProvider1.SetError(txtQty, "Quantity is Empty");
                    txtQty.Focus();
                }
                if (string.IsNullOrEmpty(txtAmt.Text.Trim()))
                {
                    errorProvider1.SetError(txtAmt, "Quantity is Empty");
                    txtAmt.Focus();
                }
            }
            else
            {
                var IsHave = _context.Anu_Purchase_Cart.Where(a => a.Anu_Product_Id.Contains(ProductId)).SingleOrDefault();
                if (IsHave != null)
                {
                    IsHave.Qty = IsHave.Qty + Convert.ToInt32(txtQty.Text.Trim());
                    IsHave.Rate = IsHave.Rate + Convert.ToInt32(txtAmt.Text.Trim());
                    _context.SaveChanges();

                }
                else
                {
                    Anu_Purchase_Cart cart = new Anu_Purchase_Cart();
                    cart.Anu_Product_Id = ProductId;
                    cart.Qty = Convert.ToInt32(txtQty.Text.Trim());
                    cart.Rate = Convert.ToInt32(txtAmt.Text.Trim());
                    if (TypeCombo.SelectedValue.ToString() == "0")
                    {
                        cart.Anu_Cart_type = Model.Type.SP;
                    }
                    else if (TypeCombo.SelectedValue.ToString() == "1")
                    {
                        cart.Anu_Cart_type = Model.Type.GM;
                    }
                    else if (TypeCombo.SelectedValue.ToString() == "2")
                    {
                        cart.Anu_Cart_type = Model.Type.KG;
                    }
                    else
                    {
                        cart.Anu_Cart_type = Model.Type.LR;
                    }

                    _context.Anu_Purchase_Cart.Add(cart);
                    _context.SaveChanges();



                }
                var grd = from a in _context.Anu_Purchase_Cart.Include(b => b.prdouct)
                          select new
                          {
                              Product_Name = a.prdouct.Anu_Product_Name,
                              Quantity = a.Qty + " " + a.Anu_Cart_type.ToString(),
                              Amount = a.Rate
                          };
                cartGrd.DataSource = grd.ToList();

                txtQty.Text = "";
                txtAmt.Text = "";
                lblPrdName.Text = "";
                lblcat.Text = "";
                TypeCombo.SelectedIndex = 0;
                txtsrc.Focus();

                int itemCount = _context.Anu_Purchase_Cart.Count();
                decimal total = _context.Anu_Purchase_Cart.Sum(a => a.Rate);
                TotalAmount = total;

                lblitem.Text = itemCount.ToString();
                lblamount.Text = total.ToString();
                lblQty.Text = _context.Anu_Purchase_Cart.Sum(a => a.Qty).ToString() + " " + Model.Type.KG.ToString();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Init();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblvenId.Text) && string.IsNullOrEmpty(lblvenMob.Text))
            {
                errorProvider1.SetError(vendCombo, "Please Select Vedor Name");
            }
            else
            {
                try
                {
                    Anu_Purchase pur = new Anu_Purchase();
                    pur.Anu_Purchase_Id = PurchseNo;
                    pur.Anu_Purchase_InvoiceNo = lblInvoice.Text.Trim();
                    pur.Anu_Purchase_Invoice_Date = dateTimePicker1.Value.Date;
                    pur.Anu_Vendor_Id = vendCombo.SelectedValue.ToString();
                    pur.Anu_Purchase_Amount = TotalAmount;
                    pur.Status = Status.UnPaid;
                    pur.Anu_Purchase_IsActive = true;
                    pur.Anu_Purchase_CreatedBy =  SessionMgr.UserId;
                    pur.Anu_Purchase_CreatedDate = DateTime.Now;
                    _context.Anu_Purchases.Add(pur);
                    _context.SaveChanges();

                    var crt = _context.Anu_Purchase_Cart.ToList();

                    foreach(var item in crt)
                    {
                        var detid="";
                        long urn = 1;
                        var MaxURN = (from a in _context.Anu_Purchase_Details select a).AsEnumerable().Max(p => p.Anu_Purchase_Detail_Id.Split('-')[1]);
                        if (MaxURN != null)
                        {
                            urn = Convert.ToInt64(MaxURN) + 1;
                        }
                        detid = "AGPPURDET" + "-" + urn.ToString("0000");

                        Anu_Purchase_Detail pd = new Anu_Purchase_Detail();
                        pd.Anu_Purchase_Detail_Id = detid;
                        pd.Anu_Purchase_Id = pur.Anu_Purchase_Id;
                        pd.Anu_Product_Id = item.Anu_Product_Id;
                        pd.Anu_Purchase_Detail_Qty = item.Qty.ToString();
                        pd.Anu_Purchase_Detail_Rate = item.Rate;
                        pd.Anu_Purchase_Detail_type = item.Anu_Cart_type;
                        _context.Anu_Purchase_Details.Add(pd);
                        _context.SaveChanges();

                    }

                    foreach(var items in crt)
                    {
                        if(items != null)
                        {
                            Anu_Purchase_Cart ct = _context.Anu_Purchase_Cart.Find(items.Anu_CartId);
                            _context.Anu_Purchase_Cart.Remove(ct);
                            _context.SaveChanges();
                        }
                    }


                    var grd = from a in _context.Anu_Purchase_Cart.Include(b => b.prdouct)
                              select new
                              {
                                  Product_Name = a.prdouct.Anu_Product_Name,
                                  Quantity = a.Qty + " " + a.Anu_Cart_type.ToString(),
                                  Amount = a.Rate
                              };
                    cartGrd.DataSource = grd.ToList();


                    lblitem.Text = "0";
                    lblamount.Text ="0.00";
                    lblQty.Text = "0";


                    lblvenGst.Text = "";
                    lblvenId.Text = "";
                    lblvenMob.Text = "";
                    vendCombo.SelectedIndex = 0;

                    txtsrc.Focus();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
