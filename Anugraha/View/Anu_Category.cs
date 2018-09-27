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
    public partial class Anu_Category : UserControl
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        private static Anu_Category _instance;
        public static Anu_Category Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Category();
                return _instance;
            }
        }


        public Anu_Category()
        {
            InitializeComponent();
            Init();
            //


        }

        private void Init()
        {
            GridData();
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome"+ SessionMgr.UserId;
           

            var catcode = "";
            var catid = "";
            var IsHave = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true && a.Anu_Category_Id != null).Count();
            if (IsHave != 0)
            {
                long urn = 1;
                var MaxURN = (from a in _context.Anu_Category_Details  select a).AsEnumerable().Max(p => p.Anu_Category_Id.Split('-')[1]);
                if (MaxURN != null)
                {
                    urn = Convert.ToInt64(MaxURN) + 1;
                }
                catid = "AGPCAT" + "-" + urn.ToString("0000");
                catcode = "AGPCATCODE" + "-" + urn.ToString("0000");
            }
            else
            {
                long urn = 1;
                catid = "AGPCAT" + "-" + urn.ToString("0000");
                catcode = "AGPCATCODE" + "-" + urn.ToString("0000");
            }
            txtCateoryId.Text = catid;
            txtcatCode.Text = catcode;
            txtcatCode.Enabled = false;
            txtcatName.Text = "";

            

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        #region Validation

        private void txtcatName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtcatName.Text.Trim()))
            {
                e.Cancel = true;
                txtcatName.Focus();
                errorProvider1.SetError(txtcatName, "Category Name is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtcatName, "");
            }
        }
        #endregion
        #region GridView
        protected void GridData()
        {
            var grd = from a in _context.Anu_Category_Details
                      where (a.Anu_Category_IsActive == true)
                      select new
                      {
                          CategoryId = a.Anu_Category_Id,
                          CategoryName = a.Anu_Category_Name,
                          CategroyCode = a.Anu_Category_Code
                      };
            categoryGrid.DataSource = grd.ToList();

            categoryGrid.Columns[0].Visible = false;

            categoryGrid.Columns[1].HeaderText = "CATEGORY NAME";
            //categoryGrid.Columns[1].Width = 800;
            categoryGrid.Columns[1].ToolTipText = "CATEGORY NAME";
            categoryGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            categoryGrid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            categoryGrid.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            categoryGrid.Columns[2].HeaderText = "CATEGORY CODE";
            //categoryGrid.Columns[2].Width = 800;
            categoryGrid.Columns[2].ToolTipText = "CATEGORY CODE";
            categoryGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            categoryGrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            categoryGrid.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;

            //DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
            //EditColumn.Text = "EDIT";
            //EditColumn.Name = "EDIT";
            //EditColumn.HeaderText = "EDIT";
            //EditColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //EditColumn.DataPropertyName = "EDIT";
            //EditColumn.UseColumnTextForButtonValue = true;
            //EditColumn.DisplayIndex = 3;
            //categoryGrid.Columns.Add(EditColumn);

            //DataGridViewButtonColumn DeleteColumn = new DataGridViewButtonColumn();
            //DeleteColumn.Text = "DELETE";
            //DeleteColumn.Name = "DELETE";
            //DeleteColumn.HeaderText = "DELETE";
            //DeleteColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DeleteColumn.DataPropertyName = "DELETE";
            //DeleteColumn.UseColumnTextForButtonValue = true;
            //DeleteColumn.DisplayIndex = 4;
            //categoryGrid.Columns.Add(DeleteColumn);
        }
        private void categoryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var categoryGrid = (DataGridView)sender;
                if (categoryGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string code = categoryGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

                    DataGridViewButtonCell b = categoryGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
                    string edit = b.FormattedValue.ToString();
                    string delete = b.FormattedValue.ToString();
                    if (edit == "EDIT")
                    {
                        Edit(code);
                    }
                    if (delete == "DELETE")
                    {
                        Deletecode(code);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtsrcCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsrcCode.Text.Trim()))
            {
                // To check the characters into the current table for searching purpose
                //categoryGrid.DataSource = _context.Anu_Category_Details.Where(a => a.Anu_Category_Id.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Name.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Code.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true).ToList();
                var grd = from a in _context.Anu_Category_Details
                          where (a.Anu_Category_Id.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Code.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true || a.Anu_Category_Name.Contains(txtsrcCode.Text.Trim()) && a.Anu_Category_IsActive == true)
                          select new
                          {
                              CategoryId = a.Anu_Category_Id,
                              CategoryName = a.Anu_Category_Name,
                              CategroyCode = a.Anu_Category_Code
                          };
                categoryGrid.DataSource = grd.ToList();
            }
            else
            {
                // to be bind the non-searching data into the datagridview datasource
                var grd = from a in _context.Anu_Category_Details
                          where (a.Anu_Category_IsActive == true)
                          select new
                          {
                              CategoryId = a.Anu_Category_Id,
                              CategoryName = a.Anu_Category_Name,
                              CategroyCode = a.Anu_Category_Code
                          };
                categoryGrid.DataSource = grd.ToList();


            }
        }
        #endregion
        #region Action
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtcatName.Text.Trim()))
            {
                errorProvider1.SetError(txtcatName, "Category Name is Empty");
                txtcatName.Focus();
            }
            else
            {
                var categ = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true && a.Anu_Category_Id.Contains(txtCateoryId.Text.Trim())).Count();
                try
                {

                    var name = _context.Anu_Category_Details.Where(a => a.Anu_Category_Name.Contains(txtcatName.Text.Trim())).Count();
                    if(name != 0)
                    {
                        MessageBox.Show("Name Already registered!");
                        txtcatName.Text = "";
                        txtcatName.Focus();
                    }
                    else if(categ == 0)
                    {
                        Anu_Category_Detail cat = new Anu_Category_Detail();
                        cat.Anu_Category_Id = txtCateoryId.Text;
                        cat.Anu_Category_Code = txtcatCode.Text.Trim().ToUpper();
                        cat.Anu_Category_Name = txtcatName.Text.Trim().ToUpper();
                        cat.Anu_Category_IsActive = true;
                        cat.Anu_Category_CreatedBy = SessionMgr.UserId;
                        cat.Anu_Category_CreatedDate = DateTime.Now;
                        _context.Anu_Category_Details.Add(cat);
                        _context.SaveChanges();
                        Init();
                        GridData();

                    }
                    else
                    {
                        var cid = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true && a.Anu_Category_Id == txtCateoryId.Text.Trim()).SingleOrDefault();
                        cid.Anu_Category_Name = txtcatName.Text.Trim().ToUpper();
                        cid.Anu_Category_ModifiedBy = SessionMgr.UserId;
                        cid.Anu_Category_ModifiedDate = DateTime.Now;
                        _context.SaveChanges();
                        Init();
                        GridData();
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               
            }
          
        }
        private void Edit(string id)
        {
            try
            {
                var catcode = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true && a.Anu_Category_Name == id).SingleOrDefault();
                txtCateoryId.Text = catcode.Anu_Category_Id;
                txtcatCode.Text = catcode.Anu_Category_Code;
                txtcatName.Text = catcode.Anu_Category_Name;
                txtcatCode.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Deletecode(string code)
        {
            try
            {
                var catcode = _context.Anu_Category_Details.Where(a => a.Anu_Category_IsActive == true && a.Anu_Category_Name == code).SingleOrDefault();
                catcode.Anu_Category_IsActive = false;
                catcode.Anu_Category_ModifiedBy = "Admin";
                catcode.Anu_Category_ModifiedDate = DateTime.Now;
                _context.SaveChanges();
                Init();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       


        #endregion


    }
}
