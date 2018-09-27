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
    public partial class Anu_Stock_Entry : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Stock_Entry _instance;
        public static Anu_Stock_Entry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Stock_Entry();
                return _instance;
            }
        }
        public string InvoiceNo;
        public string ProductId;

        public Anu_Stock_Entry()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome" + SessionMgr.UserId;
            txtQty.Visible = false;

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            var items = new[]
            {

                 new {Text = "PURCHASE INVOICE", Value="0"},
                new {Text = "OWN PRODUCT", Value="1"},
            };

            comboBox1.DataSource = items;

            comboBox1.SelectedIndex = 0;

            prdgrid.Visible = false;

            TypeCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TypeCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

            TypeCombo.DisplayMember = "Text";
            TypeCombo.ValueMember = "Value";


            var item = new[]
            {

                 new {Text = "SP", Value="0"},
                new {Text = "GM", Value="1"},
                new {Text = "KG", Value="2"},
                new {Text = "LR", Value="3"}

            };

            TypeCombo.DataSource = item;

            TypeCombo.SelectedIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue.ToString() == "0")
                {
                    lblName.Text = "Select Invoice No";
                    listCombo.DataSource = _context.Anu_Purchases.Include(a => a.purdetail).Where(a => a.Anu_Purchase_IsActive == true && a.Status == Model.Status.UnPaid).ToList();
                    listCombo.DisplayMember = "Anu_Purchase_InvoiceNo";
                    listCombo.ValueMember = "Anu_Purchase_Id";
                    InvoiceNo = listCombo.SelectedValue.ToString();
                    ProductId = "";
                    txtQty.Visible = false;



                }
                else if (comboBox1.SelectedValue.ToString() == "1")
                {
                    InvoiceNo = "";
                    lblName.Text = "Select Product";
                    listCombo.DataSource = _context.Products.Where(a => a.Anu_Product_IsActive == true).ToList();
                    listCombo.DisplayMember = "Anu_Product_Name";
                    listCombo.ValueMember = "Anu_Product_Id";
                    ProductId = listCombo.SelectedValue.ToString();
                    txtQty.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void listCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue.ToString() == "0")
                {
                    InvoiceNo = listCombo.SelectedValue.ToString();
                    ProductId = "";
                }
                else
                {
                    ProductId = listCombo.SelectedValue.ToString();
                    InvoiceNo = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                prdgrid.Visible = true;
                if (InvoiceNo != "")
                {
                    var grd = from a in _context.Anu_Purchase_Details.Include(ab => ab.anuPurchase).Include(dd => dd.product)
                              where (a.Anu_Purchase_Id.Contains(InvoiceNo))
                              select new
                              {
                                  Id = a.Anu_Purchase_Detail_Id,
                                  ProductId = a.Anu_Product_Id,
                                  Product = a.product.Anu_Product_Name,
                                  Quantity = a.Anu_Purchase_Detail_Qty,
                                  Type = a.Anu_Purchase_Detail_type.ToString(),
                                  Rate = a.Anu_Purchase_Detail_Rate
                              };
                    prdgrid.DataSource = grd.OrderBy(a => a.Product).ToList();
                    var lstitem = grd.ToList();

                    prdgrid.Columns[0].Visible = false;
                    prdgrid.Columns[1].Visible = false;

                    foreach (var item in lstitem)
                    {

                        var IsHave = _context.Anu_Purchase_Cart.Where(a => a.Anu_Product_Id.Contains(item.ProductId)).SingleOrDefault();

                        if (IsHave != null)
                        {
                            IsHave.Qty = IsHave.Qty + Convert.ToInt32(item.Quantity);
                            _context.SaveChanges();
                        }
                        else
                        {
                            Anu_Purchase_Cart crt = new Anu_Purchase_Cart();
                            crt.Anu_Product_Id = item.ProductId;
                            crt.Qty = Convert.ToInt32(item.Quantity);
                            if (TypeCombo.SelectedValue.ToString() == "0")
                            {
                                crt.Anu_Cart_type = Model.Type.SP;
                            }
                            else if (TypeCombo.SelectedValue.ToString() == "1")
                            {
                                crt.Anu_Cart_type = Model.Type.GM;
                            }
                            else if (TypeCombo.SelectedValue.ToString() == "2")
                            {
                                crt.Anu_Cart_type = Model.Type.KG;
                            }
                            else
                            {
                                crt.Anu_Cart_type = Model.Type.LR;
                            }
                            crt.Rate = Convert.ToDecimal("0.00");
                            _context.Anu_Purchase_Cart.Add(crt);
                            _context.SaveChanges();
                        }


                    }
                }
                else
                {
                    var IsHave = _context.Anu_Purchase_Cart.Where(a => a.Anu_Product_Id.Contains(ProductId)).SingleOrDefault();

                    if (IsHave != null)
                    {
                        IsHave.Qty = IsHave.Qty + Convert.ToInt32(txtQty.Text.Trim());
                        _context.SaveChanges();
                    }
                    else
                    {
                        Anu_Purchase_Cart crt = new Anu_Purchase_Cart();
                        crt.Anu_Product_Id = ProductId;
                        crt.Qty = Convert.ToInt32(txtQty.Text.Trim());
                        crt.Anu_Cart_type = Model.Type.KG;
                        crt.Rate = Convert.ToDecimal("0.00");
                        _context.Anu_Purchase_Cart.Add(crt);
                        _context.SaveChanges();
                    }




                    var grd = from a in _context.Anu_Purchase_Cart.Include(b => b.prdouct)
                              select new
                              {
                                  Id = a.Anu_CartId,
                                  Product = a.prdouct.Anu_Product_Name,
                                  Quantity = a.Qty + " " + a.Anu_Cart_type.ToString(),
                                  Rate = a.Rate
                              };
                    prdgrid.DataSource = grd.OrderBy(a => a.Product).ToList();
                    prdgrid.Columns[0].Visible = false;

                    txtQty.Text = "";
                    listCombo.SelectedIndex = 0;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var cart = _context.Anu_Purchase_Cart.Include(bb => bb.prdouct).ToList();
                int id = 0;

                foreach (var item in cart)
                {
                    var IsHave = _context.Anu_Stocks.Where(a => a.Anu_Product_Id.Contains(item.Anu_Product_Id)).SingleOrDefault();
                    if (IsHave != null)
                    {
                        if (InvoiceNo != null)
                        {
                            IsHave.Anu_Stock_Qty = IsHave.Anu_Stock_Qty + item.Qty;
                            _context.SaveChanges();
                        }
                        else
                        {
                            IsHave.Anu_Stock_Qty = IsHave.Anu_Stock_Qty + Convert.ToInt32(txtQty.Text.Trim());
                            _context.SaveChanges();
                        }


                        var st = _context.Anu_Stock_Detail.Where(a => a.Anu_Stock_Detail_Id == IsHave.Anu_StockId).SingleOrDefault();
                        st.ModifiedBy =  SessionMgr.UserId;
                        st.ModifiedDate = DateTime.Now;
                    }
                    else
                    {
                        Anu_Stock stock = new Anu_Stock();
                        stock.Anu_Product_Id = item.Anu_Product_Id;
                        stock.Anu_Stock_Product_Code = item.prdouct.Anu_Product_Code;
                        stock.Anu_Stock_Qty = item.Qty;
                        stock.Anu_Stock_Type = item.Anu_Cart_type;
                        _context.Anu_Stocks.Add(stock);
                        _context.SaveChanges();
                        id = stock.Anu_StockId;

                        Anu_Stock_Detail details = new Anu_Stock_Detail();
                        details.Anu_StockId = id;
                        details.CreatedBy = SessionMgr.UserId;
                        details.CreatedDate = DateTime.Now;
                        _context.Anu_Stock_Detail.Add(details);
                        _context.SaveChanges();

                        Anu_Purchase_Cart crt = _context.Anu_Purchase_Cart.Find(item.Anu_CartId);
                        _context.Anu_Purchase_Cart.Remove(crt);
                        _context.SaveChanges();

                    }

                }

                Init();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
