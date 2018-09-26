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
    public partial class Login : Form
    {
        public Login()
        {

            InitializeComponent();
            lblBilling.Text = "";
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveForm.Text = "Anugraha Pazhamuthirsolai -" + " " + DateTime.Now.Year.ToString();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()) && string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                    {
                        errorProvider1.SetError(txtUserName, "User Name is Empty");
                        txtUserName.Focus();
                    }
                    if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                    {
                        errorProvider1.SetError(txtPassword, "User Name is Empty");
                        txtUserName.Focus();
                    }
                }
                else
                {
                    if(txtUserName.Text == "Admin" && txtPassword.Text =="Admin")
                    {
                        this.Hide();
                        Master master = new Master();
                        master.Show();
                    }
                    else
                    {
                        MessageBox.Show("Enter Correct Username  & Password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
