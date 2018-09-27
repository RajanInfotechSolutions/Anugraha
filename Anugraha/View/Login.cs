using Anugraha.Data;
using Anugraha.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anugraha.View
{
    public partial class Login : Form
    {
        ApplicationDbContext _context = new ApplicationDbContext();
       
        public Login()
        {

            InitializeComponent();
            lblBilling.Text = "";
            lblDate.Text = DateTime.Now.ToShortDateString();

            //string mac = GetMacAddress();

            var user = _context.Anu_Users.Where(a => a.Anu_USERID != 0).Count();
            if(user != 0)
            {
                lnkbutton.Text = " ";
            }
            else
            {
                lnkbutton.Text = "Sign Up";
            }
        }

        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
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
                    var IsHave = _context.Anu_Users.Where(a => a.Anu_USERNAME == txtUserName.Text.Trim() && a.Anu_PASSWORD == txtPassword.Text.Trim()).SingleOrDefault();
                    if (IsHave != null)
                    {
                        this.Hide();

                        SessionMgr.UserId = IsHave.Anu_USERNAME;

                        Anu_Log_History history = new Anu_Log_History();
                        history.Anu_LAST_LOGGED_In = DateTime.Now;
                        history.CreatedBy = IsHave.Anu_USERNAME;
                        history.CreatedDate = DateTime.Now;
                        _context.Anu_Log_Histories.Add(history);
                        _context.SaveChanges();

                        IsHave.Anu_LogID = history.Anu_LogID;
                        _context.SaveChanges();

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
                //MessageBox.Show(ex.Message);
            }
           
        }

        private void lnkbutton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(lnkbutton.Text =="Sign Up")
            {
                SignUp sign = new SignUp();
                sign.ShowDialog();
            }
        }
    }
}
