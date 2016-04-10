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
    Unfinished code by Jennifer
 */
namespace A6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Payment#";
            dataGridView1.Columns[1].HeaderText = "Monthly Payment";
            dataGridView1.Columns[2].HeaderText = "Amount to Interest";
            dataGridView1.Columns[3].HeaderText = "Amount to Principal";
            dataGridView1.Columns[0].HeaderText = "Remaining Balance";
            double cost, downPayment, months, rate,pv, monthlyPayment=0, amountToInterest=0, amountToPrincipal=0, remainingBalance=0;
            cost = double.Parse(textBox1.Text);
            downPayment = double.Parse(textBox2.Text);
            months = double.Parse(textBox3.Text);
            if (months < 6 || months > 48)

            {
                MessageBox.Show("The credit union does not finance a vehcle for less than 6 months or more than 48 months");
            }

            if (radioButton1.Checked)
            {
                rate = .069;
                textBox4.Text = rate.ToString("P");
            }
            else
            {
                rate = .085;
                textBox4.Text = rate.ToString("P");
            }
            pv = cost - downPayment;
            dataGridView1.Rows.Clear();
            for (int paymentNumber = 1; paymentNumber <= months; paymentNumber++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[paymentNumber - 1].Cells[0].Value = paymentNumber;
                monthlyPayment = Financial.Pmt(rate / 12, months, -pv);
                dataGridView1.Rows[paymentNumber - 1].Cells[1].Value = monthlyPayment.ToString("c");
                amountToInterest = Financial.IPmt(rate / 12, paymentNumber, months, -pv);
                dataGridView1.Rows[paymentNumber - 1].Cells[2].Value = amountToInterest.ToString("c");
                amountToPrincipal = Financial.PPmt(rate / 12, paymentNumber, months, -pv);
                dataGridView1.Rows[paymentNumber - 1].Cells[3].Value = amountToPrincipal.ToString("c");
                remainingBalance = pv - monthlyPayment;
                dataGridView1.Rows[paymentNumber - 1].Cells[4].Value = remainingBalance.ToString("c");
               if (paymentNumber % 2 == 0)
                    dataGridView1.Rows[paymentNumber - 1].DefaultCellStyle.BackColor = Color.AliceBlue;
                else
                    dataGridView1.Rows[paymentNumber - 1].DefaultCellStyle.BackColor = Color.Pink;



            }