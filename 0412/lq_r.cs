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
            // suppose single pay is $100/day
            //double singlePay = 100, 
            double singlePay = 0.01,
                   totalPay = 0;

            // counting days       
            int days = 1;

            Boolean keepWorking = true;

            while(keepWorking){
                // Added code here
                singlePay = 2 * singlePay;

                totalPay = totalPay + singlePay;

                days++;

                if(totalPay >＝ 1000000){
                    keepWorking = false;
                    MessageBox.Show("It takes" + days.ToString() + "days to accumlate 1 million dollars");
                }
            }
            
        }
    }

}