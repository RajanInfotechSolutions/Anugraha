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
using System.Globalization;
using Anugraha.Model;
using PrinterUtility;
using System.IO;
using System.Collections;
using System.Drawing.Printing;

namespace Anugraha.View
{
    public partial class Anu_Sales_Entry : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Sales_Entry _instance;
        public static Anu_Sales_Entry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Sales_Entry();
                return _instance;
            }
        }
        public decimal Rate;
        public decimal Qty;
        public decimal Amount;
        public decimal Total;
        public string ProductId;
        public decimal SubTotal;
        public int TotalQty;
        private PrintDocument printDocument = new PrintDocument();
        private static String RECEIPT = Environment.CurrentDirectory + @"\comprovantes\comprovante.txt";
        private String stringToPrint = "";
        public Anu_Sales_Entry()
        {
            InitializeComponent();
            Init();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Init()
        {
            btnAdd.Enabled = false;
            btnPrint.Enabled = false;
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome" + SessionMgr.UserId;


            var odid = "";
            var IsHave = _context.Anu_Orders.Where(a => a.Anu_Order_IsActive == true && a.Anu_Order_Id != null).Count();
            if (IsHave != 0)
            {
                long urn = 1;
                var MaxURN = (from a in _context.Anu_Orders select a).AsEnumerable().Max(p => p.Anu_Order_Id.Split('-')[1]);
                if (MaxURN != null)
                {
                    urn = Convert.ToInt64(MaxURN) + 1;
                }
                odid = "AGPINV/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "-" + urn.ToString("0000");
            }
            else
            {
                long urn = 1;
                odid = "AGPINV/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "-" + urn.ToString("0000");
            }
            lblBillNo.Text = odid;
            lblBillDate.Text = DateTime.Now.ToShortDateString();


            prdCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            prdCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

            prdCombo.DataSource = _context.Products.Where(a => a.Anu_Product_IsActive == true).ToList();
            prdCombo.ValueMember = "Anu_Product_Id";
            prdCombo.DisplayMember = "Anu_Product_Name";


            TypeCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            TypeCombo.AutoCompleteSource = AutoCompleteSource.ListItems;

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
        }
        #region Validation
        private void prdCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                TypeCombo.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                TypeCombo.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                TypeCombo.Focus();
            }
        }

        private void TypeCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtRate.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                prdCombo.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtQty.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                TypeCombo.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnAdd.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtRate.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnAdd.Focus();
            }
        }
        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtReceived.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtReceived.Focus();
            }
        }
        private void txtReceived_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnPrint.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                btnAdd.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnPrint.Focus();
            }
        }


        #endregion

        private void prdCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var cat = _context.Products.Include(c => c.detail).Where(a => a.Anu_Product_IsActive == true && a.Anu_Product_Id.Contains(prdCombo.SelectedValue.ToString())).SingleOrDefault();
                txtCat.Text = cat.detail.Anu_Category_Name;
                txtRate.Text = cat.Anu_Product_Rate.ToString();
                var stock = _context.Anu_Stocks.Include(df => df.product).Where(a => a.Anu_Product_Id.Contains(prdCombo.SelectedValue.ToString())).SingleOrDefault();
                lblStock.Text = stock.Anu_Stock_Qty.ToString() + stock.product.type.ToString();
                Rate = cat.Anu_Product_Rate;
                ProductId = prdCombo.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQty.Text.Trim()))
                {
                    btnAdd.Enabled = false;
                    //MessageBox.Show("Please Enter The Quantity");
                }
                else
                {
                    btnAdd.Enabled = true;
                    var qty = "";
                    if (TypeCombo.SelectedValue.ToString() == "1")
                    {
                        qty = Convert.ToString(Convert.ToDouble(txtQty.Text.Trim()) * 0.001);
                    }
                    else if (TypeCombo.SelectedValue.ToString() == "0")
                    {
                        qty = txtQty.Text.Trim();
                    }
                    else
                    {
                        var wt = float.Parse(txtQty.Text.Trim().ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        var kg = TonnesToKilograms(wt);
                        qty = Convert.ToString(Convert.ToDouble(kg) * 0.001);
                    }
                    decimal amt = Rate * Convert.ToDecimal(qty);
                    Qty = Convert.ToDecimal(qty);
                    Amount = amt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        float TonnesToKilograms(float tonnes)
        {
            return tonnes * 1000;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var IsHave = _context.Anu_Carts.Where(a => a.Anu_Product_Id.Contains(ProductId)).SingleOrDefault();
                if (IsHave != null)
                {
                    IsHave.Anu_cart_Qty = (Convert.ToInt32(IsHave.Anu_cart_Qty) + Convert.ToInt32(Qty)).ToString();
                    IsHave.Anu_cart_Rate = IsHave.Anu_cart_Rate + Amount;
                    _context.SaveChanges();
                }
                else
                {
                    Anu_Cart cart = new Anu_Cart();
                    cart.Anu_Product_Id = ProductId;
                    cart.Anu_cart_Qty = Qty.ToString();
                    cart.Anu_cart_Rate = Amount;
                    if (TypeCombo.SelectedValue.ToString() == "0")
                    {
                        cart.Anu_cart_Type = Model.Type.SP;
                    }
                    else if (TypeCombo.SelectedValue.ToString() == "1")
                    {
                        cart.Anu_cart_Type = Model.Type.GM;
                    }
                    else if (TypeCombo.SelectedValue.ToString() == "2")
                    {
                        cart.Anu_cart_Type = Model.Type.KG;
                    }
                    else
                    {
                        cart.Anu_cart_Type = Model.Type.LR;
                    }
                    _context.Anu_Carts.Add(cart);
                    _context.SaveChanges();
                }
                var ct = _context.Anu_Carts.ToList();

                var grd = from a in _context.Anu_Carts.Include(s => s.product)
                          select new
                          {
                              Id = a.Anu_Cart_Id,
                              Product = a.product.Anu_Product_Name,
                              Quantity = a.Anu_cart_Qty + " " + a.Anu_cart_Type.ToString(),
                              Rate = a.Anu_cart_Rate
                          };
                cartGrid.DataSource = grd.OrderBy(a=>a.Product).ToList();

                cartGrid.Columns[0].Visible = false;


                var total = _context.Anu_Carts.Sum(a => a.Anu_cart_Rate);
                SubTotal = Convert.ToDecimal(total);
                Total = Convert.ToDecimal(total);
                //lblSub.Text = SubTotal.ToString();
                lblGSt.Text = "0.00";
                lblDiscount.Text = "0.00";
                lblRoundOff.Text = "0.00";
                GrandTotal.Text = Total.ToString();
                ProductId = "";
                prdCombo.SelectedIndex = 0;
                TypeCombo.SelectedIndex = 0;
                txtCat.Text = "";
                txtRate.Text = "";
                txtQty.Text = "";
                lblStock.Text = "";
                prdCombo.Focus();
                TotalQty = _context.Anu_Carts.Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtReceived.Text.Trim()))
                {
                    btnPrint.Enabled = true;
                    decimal balance = Convert.ToDecimal(txtReceived.Text.Trim()) - Total;
                    lblRemain.Text = balance.ToString();
                }
                else
                {
                    lblRemain.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {


                Anu_Order order = new Anu_Order();
                order.Anu_Order_Id = lblBillNo.Text;
                order.Anu_Order_OrderDate = Convert.ToDateTime(lblBillDate.Text);

                var uurn = "";
                long unique = 1;
                var MaxUNIQUE = (from a in _context.Anu_Orders select a).AsEnumerable().Max(p => p.Anu_Order_URNNo);
                if (MaxUNIQUE != 0)
                {
                    unique = Convert.ToInt64(MaxUNIQUE) + 1;
                }
                uurn = unique.ToString("00000");
                order.Anu_Order_URNNo = Convert.ToInt32(uurn);
                order.Anu_Order_TotalQty = TotalQty;
                order.Anu_Order_Status = Status.Paid;
                order.Anu_Order_TotalAmount = Total;
                order.Anu_Order_Mode = Mode.Cash;
                order.Anu_Order_IsActive = true;
                order.Anu_Order_Createdby = SessionMgr.UserId;
                order.Anu_Order_CreatedDate = DateTime.Now;
                _context.Anu_Orders.Add(order);
                _context.SaveChanges();


                var cart = _context.Anu_Carts.ToList();

                foreach (var item in cart)
                {
                    var odid = "";

                    long urn = 1;
                    var MaxURN = (from a in _context.Anu_Order_Details select a).AsEnumerable().Max(p => p.Anu_Order_Detail_Id.Split('-')[1]);
                    if (MaxURN != null)
                    {
                        urn = Convert.ToInt64(MaxURN) + 1;
                    }
                    odid = "AGPODD/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "-" + urn.ToString("0000");

                   



                    Anu_Order_Detail orderdetail = new Anu_Order_Detail();
                    orderdetail.Anu_Order_Detail_Id = odid;
                    orderdetail.Anu_Order_Id = order.Anu_Order_Id;
                    orderdetail.Anu_Order_Detail_Discount = Convert.ToDecimal(lblDiscount.Text);
                    orderdetail.Anu_Order_Detail_Qty = item.Anu_cart_Qty;
                    orderdetail.Anu_Order_Detail_Rate = item.Anu_cart_Rate;
                    orderdetail.Anu_Product_Id = item.Anu_Product_Id;
                    orderdetail.Anu_Order_Detail_Type = item.Anu_cart_Type;
                    orderdetail.Anu_Order_Detail_Subtotal = SubTotal;
                    orderdetail.Anu_Order_Detail_ReceivedAmount = Convert.ToDecimal(txtReceived.Text.Trim());
                    orderdetail.Anu_Order_Detail_RemainingAmount = Convert.ToDecimal(lblRemain.Text);
                    _context.Anu_Order_Details.Add(orderdetail);
                    _context.SaveChanges();


                    var stock = _context.Anu_Stocks.Include(a=>a.stdetail).Where(a => a.Anu_Product_Id.Contains(item.Anu_Product_Id)).SingleOrDefault();
                    stock.Anu_Stock_Qty = stock.Anu_Stock_Qty - Convert.ToDecimal(item.Anu_cart_Qty);
                    _context.SaveChanges();
                    

                    Anu_Cart crt = _context.Anu_Carts.Find(item.Anu_Cart_Id);
                    _context.Anu_Carts.Remove(crt);
                    _context.SaveChanges();
                }

                prdCombo.SelectedIndex = 0;
                txtCat.Text = "";
                txtQty.Text = "";
                txtRate.Text = "";
                lblStock.Text = "";
                lblGSt.Text = "";
                TypeCombo.SelectedIndex = 0;
                ////PrintReceipt(lblBillNo.Text);
                ////printTest();
                //Printdoc();

                var orderdetails = from a in _context.Anu_Order_Details.Include(aaa => aaa.order).Include(ad => ad.product)
                                  where (a.Anu_Order_Id.Contains(lblBillNo.Text))
                                  select a;

                decimal TotalAmt = _context.Anu_Orders.Where(a => a.Anu_Order_Id == lblBillNo.Text).Select(a => a.Anu_Order_TotalAmount).SingleOrDefault();

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
                var BytesValue = GetLogo(@"C:\Banner.png");

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Cash Bill\n"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Invoice no.'" + lblBillNo.Text));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Date.'" + orderdetails.FirstOrDefault().order.Anu_Order_OrderDate));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Item             Qty             Amount"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40},{1,6},{2,9},{3,9:N2}\n", "item 1", 12, 11, 144.00));
                //BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40},{1,6},{2,9},{3,9:N2}\n", "item 1", 12, 11, 144.00));

                foreach (var item in orderdetails)
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0,-40}{1,6}{2,9}{3,9:N2}\n", item.product.Anu_Product_Name, item.Anu_Order_Detail_Qty, item.Anu_Order_Detail_Rate));
                }
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Right());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Total"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes(TotalAmt.ToString()));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128("12345"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, "-------------------Thanking you------------------\n");
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Cutpage());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Anugraha.Properties.Settings.Default.PrinterName);

                Init();

                //printTest();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public byte[] Cutpage()
        {
            List<byte> oby = new List<byte>();
            oby.Add(Convert.ToByte(Convert.ToChar(0x1D)));
            oby.Add(Convert.ToByte('V'));
            oby.Add((byte)66);
            oby.Add((byte)3);
            return oby.ToArray();

        }

        public byte[] GetLogo(string LogoPath)
        {
            List<byte> byteList = new List<byte>();
            if (!File.Exists(LogoPath))
                return null;
            BitmapData data = GetBitmapData(LogoPath);
            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            MemoryStream stream = new MemoryStream();
            // BinaryWriter bw = new BinaryWriter(stream);
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //bw.Write((char));
            byteList.Add(Convert.ToByte('@'));
            //bw.Write('@');
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            // bw.Write((char)0x1B);
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            //bw.Write((byte)24);
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                //bw.Write((char)0x1B);
                //bw.Write('*');         // bit-image mode
                byteList.Add((byte)33);
                //bw.Write((byte)33);    // 24-dot double-density
                byteList.Add(width[0]);
                byteList.Add(width[1]);
                //bw.Write(width[0]);  // width low byte
                //bw.Write(width[1]);  // width high byte

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            // Calculate the location of the pixel we want in the bit array.
                            // It'll be at (y * width) + x.
                            int i = (y * data.Width) + x;

                            // If the image is shorter than 24 dots, pad with zero.
                            bool v = false;
                            if (i < dots.Length)
                            {
                                v = dots[i];
                            }
                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                        //bw.Write(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
                //bw.Write((char));
            }
            // Restore the line spacing to the default of 30 dots.
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            //bw.Write('3');
            byteList.Add((byte)30);
            return byteList.ToArray();
            //bw.Flush();
            //byte[] bytes = stream.ToArray();
            //return logo + Encoding.Default.GetString(bytes);
        }

        public BitmapData GetBitmapData(string bmpFileName)
        {
            using (var bitmap = (Bitmap)Bitmap.FromFile(bmpFileName))
            {
                var threshold = 127;
                var index = 0;
                double multiplier = 570; // this depends on your printer model. for Beiyang you should use 1000
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }

        public class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }

        private void Printdoc()
        {
            FileStream fs = new FileStream(@"C:\print.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            stringToPrint = sr.ReadToEnd();
            var Printers = System.Drawing.Printing.PrinterSettings.InstalledPrinters;
            printDocument.PrinterSettings.PrinterName = "EPSON TM-T82 Receipt";
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
            sr.Close();
            fs.Close();


        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font regular = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Regular);
            Font Title = new Font(FontFamily.GenericSerif, 9.0f, FontStyle.Bold);
            Font Head = new Font(FontFamily.GenericSerif, 11.0f, FontStyle.Bold);
            Font Head1 = new Font(FontFamily.GenericSerif, 12.0f, FontStyle.Bold);
            Font Normal = new Font(FontFamily.GenericSerif, 10.0f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Bold);


            graphics.DrawString("ANUGRAHA PAZHAMUTHIRSOLAI", Head1, Brushes.Black, 5, 10);
            graphics.DrawString("Railway Main Road,Near Mamallan Nagar,", Normal, Brushes.Black, 15, 30);
            graphics.DrawString("Kanchipuram - 631 501.", Normal, Brushes.Black, 15, 50);
            graphics.DrawString("Mobile: +91 - 9444075429 , 9698112138 ", regular, Brushes.Black, 15, 70);
            graphics.DrawString("........................................................................................................ ", regular, Brushes.Black, 10, 90);
            graphics.DrawString("CASH BILL", Head, Brushes.Black, 90, 110);
            graphics.DrawString("........................................................................................................ ", regular, Brushes.Black, 10, 130);

            var orders = _context.Anu_Order_Details.Include(c => c.order).Include(d=>d.product).Where(a => a.Anu_Order_Id == lblBillNo.Text).ToList();
            graphics.DrawString("BILL No:" + lblBillNo.Text, Normal, Brushes.Black, 10, 150);
            graphics.DrawString("Date:" + lblBillDate.Text, Normal, Brushes.Black, 10, 170);

            graphics.DrawString("PRODUCT               QTY          AMOUNT", Normal, Brushes.Black, 10, 190);

            float m = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                m = 210 + i * 20;
                graphics.DrawString(orders[i].product.Anu_Product_Name + "            "+ orders[i].Anu_Order_Detail_Qty + "             " + orders[i].Anu_Order_Detail_Rate, Normal, Brushes.Black, 10, m);
            }

            var ord = _context.Anu_Orders.Where(a => a.Anu_Order_Id == lblBillNo.Text).SingleOrDefault();
            graphics.DrawString("Total Amount:" + ord.Anu_Order_TotalAmount, Normal, Brushes.Black, 90, m);

            ord.Anu_Order_Status = Status.Paid;
            _context.SaveChanges();

           


            regular.Dispose();
            bold.Dispose();

            // Check to see if more pages are to be printed.
            //e.HasMorePages = (orderdetails.Count > 20);
        }

        

        



    }
}
