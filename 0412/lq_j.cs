using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A6
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean  days,singlePay,totalPay;
                  
            singlePay = 0.01;
            
            for (int day = 1; day<= days; day++)
            {

                totalPay += singlePay;
                singlePay *= 2;

                if (totalPay = 1000000)
                {
                    MessageBox.Show("It taks" + days.ToString() + "days to accumlate 1 million");
                }
            }
            
        }
    }
    }
}