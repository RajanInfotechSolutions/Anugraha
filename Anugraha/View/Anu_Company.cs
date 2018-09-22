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
    public partial class Anu_Company : UserControl
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Company _instance;
        public static Anu_Company Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Company();
                return _instance;
            }
        }

        public Anu_Company()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            timer1.Start();
            btnSave.Visible = false;
            txtCompanyName.Focus();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome Admin";
            var comdetail = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true && a.Anu_Company_Id != 0).SingleOrDefault();
            if (comdetail != null)
            {
                int comp_id = comdetail.Anu_Company_Id;
                Edit(comp_id);
                LoadEntry();
            }
            else
            {
                txtCompanyId.Text = "0";
                LoadEntry();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();

        }
        #region Validation
        private void txtCompany_Validating(object sender, CancelEventArgs e)
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

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text.Trim()))
            {
                e.Cancel = true;
                txtCity.Focus();
                errorProvider1.SetError(txtCity, "Owner Name is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCity, "");
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
                errorProvider1.SetError(txtMob, "Owner Name is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMob, "");
            }
        }
        #endregion
        #region KeyDown
        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtOwner.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtOwner.Focus();
            }
        }
        private void txtOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtAdd1.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtCompanyName.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtAdd1.Focus();
            }
        }

        private void txtAdd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtAdd2.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtAdd1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtAdd2.Focus();
            }
        }

        private void txtAdd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtCity.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtAdd2.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtCity.Focus();
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtState.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtCity.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtState.Focus();
            }
        }

        private void txtState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtPin.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtState.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtPin.Focus();
            }

        }

        private void txtPin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtLand.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtState.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtLand.Focus();
            }
        }

        private void txtLand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtMob.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtPin.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtMob.Focus();
            }
        }

        private void txtMob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtEmail.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtLand.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnSave.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtMob.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }
        #endregion
        #region Action
        private void LoadEntry()
        {
            txtCompanyName.Enabled = false;
            txtOwner.Enabled = false;
            txtAdd1.Enabled = false;
            txtAdd2.Enabled = false;
            txtCity.Enabled = false;
            txtState.Enabled = false;
            txtPin.Enabled = false;
            txtMob.Enabled = false;
            txtLand.Enabled = false;
            txtEmail.Enabled = false;

            var comdetail = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true && a.Anu_Company_Id != 0).SingleOrDefault();
            if (comdetail != null)
            {
                btnEdit.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = true;
            txtOwner.Enabled = true;
            txtAdd1.Enabled = true;
            txtAdd2.Enabled = true;
            txtCity.Enabled = true;
            txtState.Enabled = true;
            txtPin.Enabled = true;
            txtMob.Enabled = true;
            txtLand.Enabled = true;
            txtEmail.Enabled = true;

            txtCompanyName.Focus();
            btnNew.Visible = false;
            btnSave.Enabled = true;
            btnSave.Visible = true;
            btnEdit.Visible = true;
            btnEdit.Enabled = true;
        }
        private void Edit(int id)
        {
            var comdetail = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true && a.Anu_Company_Id == id).SingleOrDefault();
            if (comdetail != null)
            {
                txtCompanyId.Text = comdetail.Anu_Company_Id.ToString();
                txtCompanyName.Text = comdetail.Anu_Company_Name.ToString();
                txtOwner.Text = comdetail.Anu_Company_Owner.ToString();
                txtAdd1.Text = comdetail.Anu_Company_Address1.ToString();
                txtAdd2.Text = comdetail.Anu_Company_Address2.ToString();
                txtCity.Text = comdetail.Anu_Company_City.ToString();
                txtState.Text = comdetail.Anu_Company_State.ToString();
                txtPin.Text = comdetail.Anu_Company_PinCode.ToString();
                txtLand.Text = comdetail.Anu_Company_Landline.ToString();
                txtMob.Text = comdetail.Anu_Company_MobileNo.ToString();
                txtEmail.Text = comdetail.Anu_Company_Email.ToString();

                txtCompanyName.Focus();

                btnNew.Visible = false;
                btnSave.Enabled = true;
               
            }
            else
            {
                LoadEntry();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()) && string.IsNullOrEmpty(txtOwner.Text.Trim()) && string.IsNullOrEmpty(txtCity.Text.Trim()) && string.IsNullOrEmpty(txtMob.Text.Trim()))
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
                else
                {
                    errorProvider1.SetError(txtMob, "Mobile is Emoty");
                    txtMob.Focus();
                }
            }
            else
            {
                int comid = Convert.ToInt32(txtCompanyId.Text.Trim());
                if (comid == 0)
                {
                    try
                    {


                        var IsHave = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true && a.Anu_Company_Id != 0).Count();

                        //int companyId;
                        //if (IsHave != 0)
                        //{
                        //    long urn = 1;
                        //    var MaxURN = (from a in _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true) select a).AsEnumerable().Max(p => p.Anu_Company_Id);
                        //    if (MaxURN != 0)
                        //    {
                        //        urn = Convert.ToInt64(MaxURN) + 1;
                        //    }
                        //    companyId = Convert.ToInt32(urn.ToString("0000"));
                        //}
                        //else
                        //{
                        //    long urn = 1;
                        //    companyId = Convert.ToInt32(urn.ToString("0000"));
                        //}

                        Anu_Company_Detail comp = new Anu_Company_Detail();
                        //comp.Anu_Company_Id = companyId;
                        comp.Anu_Company_Name = txtCompanyName.Text.Trim().ToUpper();
                        comp.Anu_Company_Owner = txtOwner.Text.Trim().ToUpper();
                        comp.Anu_Company_Address1 = txtAdd1.Text.Trim().ToUpper();
                        comp.Anu_Company_Address2 = txtAdd2.Text.Trim().ToUpper();
                        comp.Anu_Company_City = txtCity.Text.Trim().ToUpper();
                        comp.Anu_Company_State = txtState.Text.Trim().ToUpper();
                        comp.Anu_Company_PinCode = txtPin.Text.Trim().ToUpper();
                        comp.Anu_Company_MobileNo = txtMob.Text.Trim().ToUpper();
                        comp.Anu_Company_Landline = txtLand.Text.Trim().ToUpper();
                        comp.Anu_Company_Email = txtEmail.Text.Trim().ToUpper();
                        comp.Anu_Company_IsActive = true;
                        comp.Anu_Company_CreatedBy = "Admin";
                        comp.Anu_Company_CreatedDate = DateTime.Now;
                        _context.Anu_Company_Details.Add(comp);
                        _context.SaveChanges();
                        ClearData();

                        btnNew.Visible = false;
                        btnSave.Enabled = false;
                        LoadEntry();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        var comdetail = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true && a.Anu_Company_Id == comid).SingleOrDefault();
                        comdetail.Anu_Company_Name = txtCompanyName.Text.Trim().ToUpper();
                        comdetail.Anu_Company_Owner = txtOwner.Text.Trim().ToUpper();
                        comdetail.Anu_Company_Address1 = txtAdd1.Text.Trim().ToUpper();
                        comdetail.Anu_Company_Address2 = txtAdd2.Text.Trim().ToUpper();
                        comdetail.Anu_Company_City = txtCity.Text.Trim().ToUpper();
                        comdetail.Anu_Company_State = txtState.Text.Trim().ToUpper();
                        comdetail.Anu_Company_PinCode = txtPin.Text.Trim().ToUpper();
                        comdetail.Anu_Company_MobileNo = txtMob.Text.Trim().ToUpper();
                        comdetail.Anu_Company_Landline = txtLand.Text.Trim().ToUpper();
                        comdetail.Anu_Company_Email = txtEmail.Text.Trim().ToUpper();
                        comdetail.Anu_Company_IsActive = true;
                        comdetail.Anu_Company_ModifiedBy = "Admin";
                        comdetail.Anu_Company_ModifiedDate = DateTime.Now;
                        _context.SaveChanges();
                        Init();
                        btnNew.Visible = false;
                        btnSave.Enabled = false;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var comdetail = _context.Anu_Company_Details.Where(a => a.Anu_Company_IsActive == true).SingleOrDefault();
                if (comdetail != null)
                {

                    Edit(comdetail.Anu_Company_Id);
                    btnSave.Enabled = true;
                    btnSave.Visible = true;
                }
                else
                {
                    int id = Convert.ToInt32(txtCompanyId.Text.Trim());
                    Edit(id);
                    btnSave.Enabled = true;
                    btnSave.Visible = true;
                }
                txtCompanyName.Enabled = true;
                txtOwner.Enabled = true;
                txtAdd1.Enabled = true;
                txtAdd2.Enabled = true;
                txtCity.Enabled = true;
                txtState.Enabled = true;
                txtPin.Enabled = true;
                txtMob.Enabled = true;
                txtLand.Enabled = true;
                txtEmail.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            txtCompanyId.Text = "0";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        #endregion

       
    }
}
