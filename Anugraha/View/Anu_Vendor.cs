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



        public Anu_Vendor()
        {
            InitializeComponent();
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblUserName.Text = "Welcome Admin";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToLongTimeString();

        }
    }
}
