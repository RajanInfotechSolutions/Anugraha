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
using Anugraha.Model;

namespace Anugraha.View
{
    public partial class Anu_Vendor : UserControl
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Vendor _instance;
        public static Anu_Vendor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Vendor();
                return _instance;
            }
        }

        public string ven_Id;
        public Anu_Vendor()
        {
            InitializeComponent();
            Init();


        }
       
        public void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome Admin";
            timer1.Start();
            txtVendorId.Text = "";

            GridData();
            var vrdid = "";
            var IsHave = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true && a.Anu_Vendor_Id != null).Count();
            if (IsHave != 0)
            {
                long urn = 1;
                var MaxURN = (from a in _context.Anu_Vendor_Detail select a).AsEnumerable().Max(p => p.Anu_Vendor_Id.Split('-')[1]);
                if (MaxURN != null)
                {
                    urn = Convert.ToInt64(MaxURN) + 1;
                }
                vrdid = "AGPVRD" + "-" + urn.ToString("0000");
            }
            else
            {
                long urn = 1;
                vrdid = "AGPVRD" + "-" + urn.ToString("0000");
            }

            txtVendorId.Text = vrdid;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        #region Validation
        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                e.Cancel = true;
                txtCompanyName.Focus();
                errorProvider1.SetError(txtCompanyName, "Company Name is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCompanyName, "");
            }
        }
        private void txtOwner_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOwner.Text.Trim()))
            {
                e.Cancel = true;
                txtOwner.Focus();
                errorProvider1.SetError(txtOwner, "Owner Name is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtOwner, "");
            }
        }
        private void txtPin_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPin.Text.Trim()))
            {
                e.Cancel = true;
                txtPin.Focus();
                errorProvider1.SetError(txtPin, "Pincode is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPin, "");
            }
        }
        private void txtMob_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMob.Text.Trim()))
            {
                e.Cancel = true;
                txtMob.Focus();
                errorProvider1.SetError(txtMob, "Mobile No is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMob, "");
            }
        }
        private void txtGst_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtGst.Text.Trim()))
            {
                e.Cancel = true;
                txtGst.Focus();
                errorProvider1.SetError(txtGst, "GST No is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtGst, "");
            }
        }

        #endregion
        #region GridData
        protected void GridData()
        {
            var grd = from a in _context.Anu_Vendor_Detail
                      where (a.Anu_Vendor_IsActive == true)
                      select new
                      {
                          Id= a.Anu_Vendor_Id,
                          Company = a.Anu_Vendor_Company_Name,
                          Owner = a.Anu_Vendor_Company_Owner,
                          Address  = a.Anu_Vendor_Company_Address1 + "," + a.Anu_Vendor_Company_Address2,
                          City = a.Anu_Vendor_Company_City,
                          State = a.Anu_Vendor_Company_State,
                          Pin = a.Anu_Vendor_Company_PinCode,
                          Land = a.Anu_Vendor_Company_Landline,
                          Mobile = a.Anu_Vendor_Company_MobileNo,
                          Email = a.Anu_Vendor_Company_Email,
                          GST = a.Anu_Vendor_Company_GST,
                          Bank = a.Anu_Vendor_Company_ACNO,
                          IFSC = a.Anu_Vendor_Company_IFSC
                      };

            vendorGrid.DataSource = grd.ToList();


            vendorGrid.Columns[0].Visible = false;

            vendorGrid.Columns[1].HeaderText = "VENDOR COMPANY";
            vendorGrid.Columns[1].Width = 800;
            vendorGrid.Columns[1].ToolTipText = "VENDOR COMPANY";
            vendorGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            vendorGrid.Columns[2].HeaderText = "VENDOR NAME";
            vendorGrid.Columns[2].Width = 800;
            vendorGrid.Columns[2].ToolTipText = "VENDOR NAME";
            vendorGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[3].HeaderText = "VENDOR ADDRESS";
            vendorGrid.Columns[3].Width = 800;
            vendorGrid.Columns[3].ToolTipText = "VENDOR ADDRESS";
            vendorGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;

            vendorGrid.Columns[4].HeaderText = "VENDOR CITY";
            vendorGrid.Columns[4].Width = 800;
            vendorGrid.Columns[4].ToolTipText = "VENDOR CITY";
            vendorGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[5].HeaderText = "VENDOR STATE";
            vendorGrid.Columns[5].Width = 800;
            vendorGrid.Columns[5].ToolTipText = "VENDOR STATE";
            vendorGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[6].HeaderText = "VENDOR PINCODE";
            vendorGrid.Columns[6].Width = 800;
            vendorGrid.Columns[6].ToolTipText = "VENDOR PINCODE";
            vendorGrid.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[6].SortMode = DataGridViewColumnSortMode.Automatic;



            vendorGrid.Columns[7].HeaderText = "VENDOR LANDLINE";
            vendorGrid.Columns[7].Width = 800;
            vendorGrid.Columns[7].ToolTipText = "VENDOR LANDLINE";
            vendorGrid.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[7].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[8].HeaderText = "VENDOR MOBILE";
            vendorGrid.Columns[8].Width = 800;
            vendorGrid.Columns[8].ToolTipText = "VENDOR MOBILE";
            vendorGrid.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[8].SortMode = DataGridViewColumnSortMode.Automatic;



            vendorGrid.Columns[9].HeaderText = "VENDOR EMAIL";
            vendorGrid.Columns[9].Width = 800;
            vendorGrid.Columns[9].ToolTipText = "VENDOR EMAIL";
            vendorGrid.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[9].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[10].HeaderText = "VENDOR GST";
            vendorGrid.Columns[10].Width = 800;
            vendorGrid.Columns[10].ToolTipText = "VENDOR GST";
            vendorGrid.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[10].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[11].HeaderText = "VENDOR BANK";
            vendorGrid.Columns[11].Width = 800;
            vendorGrid.Columns[11].ToolTipText = "VENDOR BANK";
            vendorGrid.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[11].SortMode = DataGridViewColumnSortMode.Automatic;


            vendorGrid.Columns[12].HeaderText = "VENDOR IFSC";
            vendorGrid.Columns[12].Width = 800;
            vendorGrid.Columns[12].ToolTipText = "VENDOR IFSC";
            vendorGrid.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            vendorGrid.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            vendorGrid.Columns[12].SortMode = DataGridViewColumnSortMode.Automatic;

        }
        private void vendorGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var vendorGrid = (DataGridView)sender;
                ven_Id = vendorGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtsrc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsrc.Text.Trim()))
            {
                var grd = from a in _context.Anu_Vendor_Detail
                          where (a.Anu_Vendor_Id.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_Name.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_Owner.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_City.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_MobileNo.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_GST.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true || a.Anu_Vendor_Company_ACNO.Contains(txtsrc.Text.Trim()) && a.Anu_Vendor_IsActive == true)
                          select new
                          {
                              Id = a.Anu_Vendor_Id,
                              Company = a.Anu_Vendor_Company_Name,
                              Owner = a.Anu_Vendor_Company_Owner,
                              Address = a.Anu_Vendor_Company_Address1 + "," + a.Anu_Vendor_Company_Address2,
                              City = a.Anu_Vendor_Company_City,
                              State = a.Anu_Vendor_Company_State,
                              Pin = a.Anu_Vendor_Company_PinCode,
                              Land = a.Anu_Vendor_Company_Landline,
                              Mobile = a.Anu_Vendor_Company_MobileNo,
                              Email = a.Anu_Vendor_Company_Email,
                              GST = a.Anu_Vendor_Company_GST,
                              Bank = a.Anu_Vendor_Company_ACNO,
                              IFSC = a.Anu_Vendor_Company_IFSC,
                              
                          };

                vendorGrid.DataSource = grd.ToList();
            }
            else
            {
                var grd = from a in _context.Anu_Vendor_Detail
                          where (a.Anu_Vendor_IsActive == true)
                          select new
                          {
                              Id = a.Anu_Vendor_Id,
                              Company = a.Anu_Vendor_Company_Name,
                              Owner = a.Anu_Vendor_Company_Owner,
                              Address = a.Anu_Vendor_Company_Address1 + "," + a.Anu_Vendor_Company_Address2,
                              City = a.Anu_Vendor_Company_City,
                              State = a.Anu_Vendor_Company_State,
                              Pin = a.Anu_Vendor_Company_PinCode,
                              Land = a.Anu_Vendor_Company_Landline,
                              Mobile = a.Anu_Vendor_Company_MobileNo,
                              Email = a.Anu_Vendor_Company_Email,
                              GST = a.Anu_Vendor_Company_GST,
                              Bank = a.Anu_Vendor_Company_ACNO,
                              IFSC = a.Anu_Vendor_Company_IFSC
                          };

                vendorGrid.DataSource = grd.ToList();
            }
        }
        #endregion
        #region Action
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()) && string.IsNullOrEmpty(txtOwner.Text.Trim()) && string.IsNullOrEmpty(txtCity.Text.Trim()) && string.IsNullOrEmpty(txtMob.Text.Trim()) && string.IsNullOrEmpty(txtGst.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                {
                    errorProvider1.SetError(txtCompanyName, "Company Name is Emoty");
                    txtCompanyName.Focus();
                }
                else if (string.IsNullOrEmpty(txtOwner.Text.Trim()))
                {
                    errorProvider1.SetError(txtOwner, "Owner Name is Emoty");
                    txtCompanyName.Focus();
                }
                else if (string.IsNullOrEmpty(txtCity.Text.Trim()))
                {
                    errorProvider1.SetError(txtCity, "City is Emoty");
                    txtCity.Focus();
                }
                else if (string.IsNullOrEmpty(txtMob.Text.Trim()))
                {
                    errorProvider1.SetError(txtMob, "Mobile is Emoty");
                    txtMob.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtGst, "GST No is Emoty");
                    txtMob.Focus();
                }
            }
            else
            {
                try
                {
                    var IsHave = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true && a.Anu_Vendor_Id.Contains(txtVendorId.Text.Trim())).Count(); 
                    if(IsHave == 0)
                    {
                        Anu_Vendor_Detail vend = new Anu_Vendor_Detail();
                        vend.Anu_Vendor_Id = txtVendorId.Text.Trim();
                        vend.Anu_Vendor_Company_Name = txtCompanyName.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_Owner = txtOwner.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_Address1 = txtAdd1.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_Address2 = txtAdd2.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_City = txtCity.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_State = txtState.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_PinCode = txtPin.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_MobileNo = txtMob.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_Landline = txtLand.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_Email = txtEmail.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_GST = txtGst.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_ACNO = txtAC.Text.Trim().ToUpper();
                        vend.Anu_Vendor_Company_IFSC = txtIfsc.Text.Trim().ToUpper();
                        vend.Anu_Vendor_IsActive = true;
                        vend.Anu_Vendor_CreatedBy = "Admin";
                        vend.Anu_Vendor_CreatedDate = DateTime.Now;
                        _context.Anu_Vendor_Detail.Add(vend);
                        _context.SaveChanges();
                    }
                    if(IsHave != 0)
                    {
                        var cmd = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true && a.Anu_Vendor_Id.Contains(txtVendorId.Text.Trim())).SingleOrDefault();
                        cmd.Anu_Vendor_Id = txtVendorId.Text.Trim();
                        cmd.Anu_Vendor_Company_Name = txtCompanyName.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_Owner = txtOwner.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_Address1 = txtAdd1.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_Address2 = txtAdd2.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_City = txtCity.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_State = txtState.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_PinCode = txtPin.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_MobileNo = txtMob.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_Landline = txtLand.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_Email = txtEmail.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_GST = txtGst.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_ACNO = txtAC.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_Company_IFSC = txtIfsc.Text.Trim().ToUpper();
                        cmd.Anu_Vendor_IsActive = true;
                        cmd.Anu_Vendor_ModifiedBy = "Admin";
                        cmd.Anu_Vendor_ModifiedDate = DateTime.Now;
                        _context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Init();
            ClearData();
        }
        private void ClearData()
        {
            txtCompanyName.Text = "";
            txtOwner.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPin.Text = "";
            txtMob.Text = "";
            txtLand.Text = "";
            txtEmail.Text = "";
            txtGst.Text = "";
            txtAC.Text = "";
            txtIfsc.Text = "";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit(ven_Id);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        protected void Edit(string id)
        {
            try
            {
                if(id != null)
                {
                    var cmd = _context.Anu_Vendor_Detail.Where(a => a.Anu_Vendor_IsActive == true && a.Anu_Vendor_Id.Contains(id)).SingleOrDefault();
                    txtVendorId.Text = cmd.Anu_Vendor_Id.ToString();
                    txtCompanyName.Text = cmd.Anu_Vendor_Company_Name.ToString();
                    txtOwner.Text = cmd.Anu_Vendor_Company_Owner.ToString();
                    txtAdd1.Text = cmd.Anu_Vendor_Company_Address1.ToString();
                    txtAdd2.Text = cmd.Anu_Vendor_Company_Address2.ToString();
                    txtCity.Text = cmd.Anu_Vendor_Company_City.ToString();
                    txtState.Text = cmd.Anu_Vendor_Company_State.ToString();
                    txtPin.Text = cmd.Anu_Vendor_Company_PinCode.ToString();
                    txtLand.Text = cmd.Anu_Vendor_Company_Landline.ToString();
                    txtMob.Text = cmd.Anu_Vendor_Company_MobileNo.ToString();
                    txtEmail.Text = cmd.Anu_Vendor_Company_Email.ToString();
                    txtGst.Text = cmd.Anu_Vendor_Company_GST.ToString();
                    txtAC.Text = cmd.Anu_Vendor_Company_ACNO.ToString();
                    txtIfsc.Text = cmd.Anu_Vendor_Company_IFSC.ToString();
                }
                else
                {
                    MessageBox.Show("Please select data from grid");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }


        #endregion

       
    }
}
