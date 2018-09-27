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
    public partial class SignUp : Form
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public SignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text.Trim() != txtcon.Text.Trim())
                {
                    MessageBox.Show("Password & Confirm Password Does not Match");
                    txtcon.Text = "";
                    txtPass.Text = "";
                    txtUserName.Text = "";
                }
                else
                {
                    //string mac = GetMacAddress();
                    Anu_User userdetail = new Anu_User();

                    userdetail.Anu_USERNAME = txtUserName.Text.Trim();
                    userdetail.Anu_PASSWORD = txtPass.Text.Trim();
                    userdetail.Anu_CONFIRM_PASSWORD = txtcon.Text.Trim();
                    userdetail.Anu_ISACTIVE = true;
                    //userdetail.Anu_MAC_ADDRESS = mac;
                    _context.Anu_Users.Add(userdetail);
                    _context.SaveChanges();

                    txtcon.Text = "";
                    txtPass.Text = "";
                    txtUserName.Text = "";
                    lbUn.Text = "";
                    lbPass.Text = "";
                    lbcpass.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var userName = _context.Anu_Users.Where(a => a.Anu_ISACTIVE == true && a.Anu_USERNAME.Contains(txtUserName.Text.Trim())).SingleOrDefault();
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "User Name is Empty");
                    txtUserName.Focus();
                    lbUn.Text = "User Name is Empty";
                    lbUn.ForeColor = Color.Red;
                }
                else if (userName != null)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "User Name is Already Registered");
                    txtUserName.Focus();
                    lbUn.Text = "User Name is Already Registered";
                    lbUn.ForeColor = Color.Red;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtUserName, "");
                    lbUn.Text = "User Name is Valid";
                    lbUn.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var userName = _context.Anu_Users.Where(a => a.Anu_ISACTIVE == true && a.Anu_PASSWORD.Contains(txtPass.Text.Trim())).SingleOrDefault();
                if (string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPass, "Password is Empty");
                    txtPass.Focus();
                    lbPass.Text = "Password is Empty";
                    lbPass.ForeColor = Color.Red;
                }
                else if (userName != null)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPass, "Password is Already Registered");
                    txtPass.Focus();
                    lbPass.Text = "Password is Already Registered";
                    lbPass.ForeColor = Color.Red;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtPass, "");
                    lbPass.Text = "Password is Valid";
                    lbPass.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcon_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var userName = _context.Anu_Users.Where(a => a.Anu_ISACTIVE == true && a.Anu_CONFIRM_PASSWORD.Contains(txtcon.Text.Trim())).SingleOrDefault();
                if (string.IsNullOrEmpty(txtcon.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtcon, "Confirm Password is Empty");
                    txtcon.Focus();
                    lbcpass.Text = "Confirm Password is Empty";
                    lbcpass.ForeColor = Color.Red;
                }
                else if (userName != null)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtcon, "Confirm Password is Already Registered");
                    txtcon.Focus();
                    lbcpass.Text = "Confirm Password is Already Registered";
                    lbcpass.ForeColor = Color.Red;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtcon, "");
                    lbcpass.Text = "Confirm Password is Valid";
                    lbcpass.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
