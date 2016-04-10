using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

/*
    Modified Code by Robin, need DEBUG
 */
namespace A6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // calculate button, calculate the table
        private void button1_Click(object sender, EventArgs e){

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Payment#";
            dataGridView1.Columns[1].HeaderText = "Monthly Payment";
            dataGridView1.Columns[2].HeaderText = "Amount to Interest";
            dataGridView1.Columns[3].HeaderText = "Amount to Principal";
            dataGridView1.Columns[4].HeaderText = "Remaining Balance";

            double cost, downPayment, months, rate, pv;
            double monthlyPayment    = 0, 
                   amountToInterest  = 0, 
                   amountToPrincipal = 0, 
                   remainingBalance  = 0;

            if(textBox1.Text && textBox2.Text && textBox3.Text){
                cost = double.Parse(textBox1.Text);
                downPayment = double.Parse(textBox2.Text);
                months = double.Parse(textBox3.Text);

                // start calculation
                if( months >= 6 && months <= 48 ){
                    // TO-DO: Please set a radioButton is Checked as intialization,
                    //        Change one of the radioButton's property.
                
                    // set rate as New
                    if (radioButton1.Checked){
                        rate = 0.069;
                    // set rate as Old
                    }else if(radioButton2.Checked){
                        rate = 0.085;
                    }
                    textBox4.Text = rate.ToString("P");

                    pv = cost - downPayment;
                    dataGridView1.Rows.Clear();
                    
                    for(int payNum = 1; payNum <=months; payNum++){
                        int index = payNum -1;
                        dataGridView1.Rows.Add();
                        // set background color for each row
                        if(index % 2 == 0){
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.AliceBlue;
                        }else{
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Pink;
                        }

                        // Cells[0]: Payment#
                        dataGridView1.Rows[index].Cells[0].Value = payNum;

                        // Cells[1]: Monthly Payment
                        monthlyPayment = Financial.Pmt(rate / 12, months, -pv);
                        dataGridView1.Rows[index].Cells[1].Value = monthlyPayment.ToString("c");

                        // Cells[2]: Amount to Interest
                        amountToInterest = Financial.IPmt(rate / 12, paymentNumber, months, -pv);
                        dataGridView1.Rows[index].Cells[2].Value = amountToInterest.ToString("c");

                        // Cells[3]: Amount to Principal
                        amountToPrincipal = Financial.PPmt(rate / 12, paymentNumber, months, -pv);
                        dataGridView1.Rows[index].Cells[3].Value = amountToPrincipal.ToString("c");

                        // Cells[4]: Remaining Balance
                        remainingBalance = pv - monthlyPayment;
                        if(remainingBalance == 0.0){
                            // set this cell's font color to RED
                            dataGridView1.Rows[index].Cells[4].style = new DataGridViewCellStyle { ForeColor = Color.Red };
                        }
                        dataGridView1.Rows[index].Cells[4].Value = remainingBalance.ToString("c");
                    }
                }else{
                    // message box
                    MessageBox.Show("The credit union does not finance a vehcle for less than 6 months or more than 48 months");
                }
            }else{
                MessageBox.Show("Please make sure the 3 inputbox has valid input");
            }
        }
        
        // reset button, clear all controls of the form
        private void button2_Click(object sender, EventArgs e){
            this.Controls.ClearControls();
        }    

        // exit button, cancel the Closing event from closing the form.
        private void button3_Click(object sender, EventArgs e){
            e.Cancel = true;
        } 
    }
}
