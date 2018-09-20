﻿using System;
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
            this.Hide();
            Master master = new Master();
            master.Show();
        }
    }
}
