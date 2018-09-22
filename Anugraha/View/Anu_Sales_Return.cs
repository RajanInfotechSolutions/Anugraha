using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anugraha.View
{
    public partial class Anu_Sales_Return : UserControl
    {
        private static Anu_Sales_Return _instance;
        public static Anu_Sales_Return Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Anu_Sales_Return();
                return _instance;
            }
        }

        public Anu_Sales_Return()
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
