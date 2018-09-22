using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anugraha.View
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Master_Load(object sender, EventArgs e)
        {
            ActiveForm.Text = "Anugraha Pazhamuthirsolai -" + " " + DateTime.Now.Year.ToString();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void CloseOpeningForms()
        {
            List<Form> lst = new List<Form>();
            try
            {
                for (int i1 = 0; i1 < Application.OpenForms.Count; i1++)
                {
                    Form f = Application.OpenForms[i1];
                    if (f.IsMdiChild)
                        lst.Add(f);
                }
            }
            catch (IndexOutOfRangeException)
            {
                //This can change if they close/open a form while code is running. Just throw it away
            }
            while (lst.Count > 0)
            {
                Form f = lst[0];
                f.Close();
                f.Dispose();
                lst.RemoveAt(0);
            }
        }

        private void CloseUserControl(UserControl root)
        {
            try
            {
                Control[] namesss = mainPanel.Controls.Find(root.Name, true);
                bool user = mainPanel.Controls.ContainsKey(namesss.FirstOrDefault().Name);
                if (user == true)
                {
                    foreach (Control item in mainPanel.Controls.OfType<Control>())
                    {
                        item.Controls.Clear();
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Company.Instance))
            {
                mainPanel.Controls.Add(Anu_Company.Instance);
                Anu_Company.Instance.Dock = DockStyle.Fill;
                Anu_Company.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Company.Instance);
                Anu_Company nt = new Anu_Company();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Category.Instance))
            {
                mainPanel.Controls.Add(Anu_Category.Instance);
                Anu_Category.Instance.Dock = DockStyle.Fill;
                Anu_Category.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Category.Instance);
                Anu_Category nt = new Anu_Category();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Product.Instance))
            {
                mainPanel.Controls.Add(Anu_Product.Instance);
                Anu_Product.Instance.Dock = DockStyle.Fill;
                Anu_Product.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Product.Instance);
                Anu_Product nt = new Anu_Product();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Vendor.Instance))
            {
                mainPanel.Controls.Add(Anu_Vendor.Instance);
                Anu_Vendor.Instance.Dock = DockStyle.Fill;
                Anu_Vendor.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Vendor.Instance);
                Anu_Vendor nt = new Anu_Vendor();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void purchaseItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Purchase_Entry.Instance))
            {
                mainPanel.Controls.Add(Anu_Purchase_Entry.Instance);
                Anu_Purchase_Entry.Instance.Dock = DockStyle.Fill;
                Anu_Purchase_Entry.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Purchase_Entry.Instance);
                Anu_Purchase_Entry nt = new Anu_Purchase_Entry();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Purchase_Return.Instance))
            {
                mainPanel.Controls.Add(Anu_Purchase_Return.Instance);
                Anu_Purchase_Return.Instance.Dock = DockStyle.Fill;
                Anu_Purchase_Return.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Purchase_Return.Instance);
                Anu_Purchase_Return nt = new Anu_Purchase_Return();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void saleEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Sales_Entry.Instance))
            {
                mainPanel.Controls.Add(Anu_Sales_Entry.Instance);
                Anu_Sales_Entry.Instance.Dock = DockStyle.Fill;
                Anu_Sales_Entry.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Sales_Entry.Instance);
                Anu_Sales_Entry nt = new Anu_Sales_Entry();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOpeningForms();
            if (!mainPanel.Controls.Contains(Anu_Sales_Return.Instance))
            {
                mainPanel.Controls.Add(Anu_Sales_Return.Instance);
                Anu_Sales_Return.Instance.Dock = DockStyle.Fill;
                Anu_Sales_Return.Instance.BringToFront();
            }
            else
            {
                CloseUserControl(Anu_Sales_Return.Instance);
                Anu_Sales_Return nt = new Anu_Sales_Return();
                mainPanel.Controls.Add(nt);
                nt.Dock = DockStyle.Fill;
                nt.BringToFront();
            }
        }
    }
}
