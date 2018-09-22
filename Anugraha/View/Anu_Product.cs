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
    public partial class Anu_Product : UserControl
    {

        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Product _instance;
        public static Anu_Product Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Product();
                return _instance;
            }
        }
        public Anu_Product()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome Admin";
            GridData();

            CategoryCombo.DataSource = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true).ToList();
            CategoryCombo.DisplayMember = "Anu_Category_Name";
            CategoryCombo.ValueMember = "Anu_Category_Id";


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

            var prdcode = "";
            var prdid = "";
            var IsHave = _context.Products.Where(a => a.Anu_Product_IsActive == true && a.Anu_Product_Id != null).Count();
            if (IsHave != 0)
            {
                long urn = 1;
                var MaxURN = (from a in _context.Products select a).AsEnumerable().Max(p => p.Anu_Product_Id.Split('-')[1]);
                if (MaxURN != null)
                {
                    urn = Convert.ToInt64(MaxURN) + 1;
                }
                prdid = "AGPPRD" + "-" + urn.ToString("0000");
                prdcode = "AGPPRDCODE" + "-" + urn.ToString("0000");
            }
            else
            {
                long urn = 1;
                prdid = "AGPPRD" + "-" + urn.ToString("0000");
                prdcode = "AGPPRDCODE" + "-" + urn.ToString("0000");
            }

            txtprdCode.Text = prdcode;
            txtProdId.Text = prdid;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        #region GridView
        protected void GridData()
        {
            var grd = from a in _context.Products.Include(b => b.detail)
                      where (a.Anu_Product_IsActive == true)
                      select new
                      {
                          Id = a.Anu_Product_Id,
                          Category = a.detail.Anu_Category_Name,
                          Code = a.Anu_Product_Code,
                          Name = a.Anu_Product_Name,
                          ProType = a.type.ToString(),
                          Rate = a.Anu_Product_Rate
                      };
            productGrid.DataSource = grd.ToList();

            productGrid.Columns[0].Visible = false;

            productGrid.Columns[1].HeaderText = "CATEGORY NAME";
            productGrid.Columns[1].Width = 800;
            productGrid.Columns[1].ToolTipText = "CATEGORY NAME";
            productGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            productGrid.Columns[2].HeaderText = "PRODUCT CODE";
            productGrid.Columns[2].Width = 800;
            productGrid.Columns[2].ToolTipText = "PRODUCT CODE";
            productGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;


            productGrid.Columns[3].HeaderText = "PRODUCT NAME";
            productGrid.Columns[3].Width = 800;
            productGrid.Columns[3].ToolTipText = "PRODUCT NAME";
            productGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.Columns[3].SortMode = DataGridViewColumnSortMode.Automatic;

            productGrid.Columns[4].HeaderText = "PRODUCT TYPE";
            productGrid.Columns[4].Width = 800;
            productGrid.Columns[4].ToolTipText = "PRODUCT TYPE";
            productGrid.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productGrid.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.Columns[4].SortMode = DataGridViewColumnSortMode.Automatic;


            productGrid.Columns[5].HeaderText = "PRODUCT RATE";
            productGrid.Columns[5].Width = 800;
            productGrid.Columns[5].ToolTipText = "PRODUCT RATE";
            productGrid.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            productGrid.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productGrid.Columns[5].SortMode = DataGridViewColumnSortMode.Automatic;


            //DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
            //EditColumn.Text = "EDIT";
            //EditColumn.Name = "EDIT";
            //EditColumn.HeaderText = "EDIT";
            //EditColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //EditColumn.DataPropertyName = "EDIT";
            //EditColumn.UseColumnTextForButtonValue = true;
            //EditColumn.DisplayIndex = 6;
            //productGrid.Columns.Add(EditColumn);

            //DataGridViewButtonColumn DeleteColumn = new DataGridViewButtonColumn();
            //DeleteColumn.Text = "DELETE";
            //DeleteColumn.Name = "DELETE";
            //DeleteColumn.HeaderText = "DELETE";
            //DeleteColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DeleteColumn.DataPropertyName = "DELETE";
            //DeleteColumn.UseColumnTextForButtonValue = true;
            //DeleteColumn.DisplayIndex =7;
            //productGrid.Columns.Add(DeleteColumn);
        }
        private void txtsrcCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsrcCode.Text.Trim()))
            {
                // To check the characters into the current table for searching purpose
                //categoryGrid.DataSource = _context.Anu_Category_Details.Where(a => a.Anu_Category_Id.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Name.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Code.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true).ToList();
                var grd = from a in _context.Products.Include(a => a.detail)
                          where (a.Anu_Product_Id.Contains(txtsrcCode.Text.Trim()) && a.Anu_Product_IsActive == true || a.Anu_Product_Code.Contains(txtsrcCode.Text.Trim()) && a.Anu_Product_IsActive == true || a.Anu_Product_Name.Contains(txtsrcCode.Text.Trim()) && a.Anu_Product_IsActive == true || a.detail.Anu_Category_Name.Contains(txtsrcCode.Text.Trim()) && a.Anu_Product_IsActive == true)
                          select new
                          {
                              Id = a.Anu_Product_Id,
                              Category = a.detail.Anu_Category_Name,
                              Code = a.Anu_Product_Code,
                              Name = a.Anu_Product_Name,
                              ProType = a.type.ToString(),
                              Rate = a.Anu_Product_Rate
                          };
                productGrid.DataSource = grd.ToList();
            }
            else
            {
                // to be bind the non-searching data into the datagridview datasource
                var grd = from a in _context.Products
                          where (a.Anu_Product_IsActive == true)
                          select new
                          {
                              Id = a.Anu_Product_Id,
                              Category = a.detail.Anu_Category_Name,
                              Code = a.Anu_Product_Code,
                              Name = a.Anu_Product_Name,
                              ProType = a.type.ToString(),
                              Rate = a.Anu_Product_Rate
                          };
                productGrid.DataSource = grd.ToList();


            }

        }
        #endregion

        #region Validation
        private void txtprdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtprdName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtprdName, "Product Name is Empty");
                txtprdName.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtprdName, "");
            }
        }
        private void txtprdRate_KeyPress(object sender, KeyPressEventArgs e)
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


        #endregion

        #region Action
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtprdName.Text.Trim()) && string.IsNullOrEmpty(txtprdRate.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtprdName.Text.Trim()))
                {
                    errorProvider1.SetError(txtprdName, "Product Name is Empty");
                    txtprdName.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtprdName, "");
                }
                if (string.IsNullOrEmpty(txtprdRate.Text.Trim()))
                {
                    errorProvider1.SetError(txtprdName, "Product Name is Empty");
                    txtprdName.Focus();
                }
                else
                {
                    errorProvider1.SetError(txtprdName, "");
                }
            }
            else
            {
                try
                {
                    var IsHave = _context.Products.Include(a => a.detail).Where(a => a.Anu_Product_IsActive == true && a.Anu_Product_Id.Contains(txtProdId.Text.Trim())).Count();
                    if (IsHave == 0)
                    {
                        var pro = _context.Products.Include(a => a.detail).Where(a => a.Anu_Product_IsActive == true && a.Anu_Product_Name.Contains(txtprdName.Text.Trim())).Count();
                        if (pro != 0)
                        {
                            MessageBox.Show("Product Name is Already Registered");
                            txtprdName.Text = "";
                            txtprdRate.Text = "";
                            CategoryCombo.SelectedIndex = 0;
                            TypeCombo.SelectedIndex = 0;
                        }

                        Product prd = new Product();
                        prd.Anu_Product_Id = txtProdId.Text.Trim().ToUpper();
                        prd.Anu_Product_Name = txtprdName.Text.Trim().ToUpper();
                        prd.Anu_Product_Code = txtprdCode.Text.Trim().ToUpper();
                        prd.Anu_Category_Id = CategoryCombo.SelectedValue.ToString().ToUpper();
                        prd.Anu_Product_Rate = Convert.ToDecimal(txtprdRate.Text.Trim());

                        if (TypeCombo.SelectedValue.ToString() == "0")
                        {
                            prd.type = Model.Type.SP;
                        }
                        else if (TypeCombo.SelectedValue.ToString() == "1")
                        {
                            prd.type = Model.Type.GM;
                        }
                        else if (TypeCombo.SelectedValue.ToString() == "2")
                        {
                            prd.type = Model.Type.KG;
                        }
                        else
                        {
                            prd.type = Model.Type.LR;
                        }
                        prd.Anu_Product_IsActive = true;
                        prd.Anu_Product_CreatedBy = "Admin";
                        prd.Anu_Product_CreatedDate = DateTime.Now;
                        _context.Products.Add(prd);
                        _context.SaveChanges();
                        Init();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        #endregion


    }
}
