using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_5
{
    public partial class Form1 : Form
    {

        
        double accountBalance;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox1.Text) < 0) throw new NegativeDepositException("Cannot Deposit a Negative number");

                if (double.Parse(textBox1.Text) > 999.99) throw new TooLargeException("Cannot deposit 1000$ dollars or more at a time");

                accountBalance = accountBalance + double.Parse(textBox1.Text);

                textBox1.Text = "Your current balance is " + accountBalance.ToString("$0.00");

                MessageBox.Show("You deposited", textBox1.Text);

                textBox1.Clear();
            }
            catch (NegativeDepositException ne)
            {
                MessageBox.Show(ne.Message);
                textBox1.Clear();
            }
            catch(TooLargeException to)
            {
                MessageBox.Show(to.Message);
                textBox1.Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = accountBalance.ToString("$0.00");
            
            MessageBox.Show("Your account balance is ", accountBalance.ToString("0.00$"));
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox1.Text) > 999.99) throw new TooLargeException("Cannot withdrawl 1000$ or more at a time");

                if (accountBalance - double.Parse(textBox1.Text) < 0) throw new NegativeBalanceException("Cannot have a negative balance in your account");

                accountBalance = accountBalance - double.Parse(textBox1.Text);
                textBox1.Text = "Your current balance is " + accountBalance.ToString("$0.00");
                MessageBox.Show("You withdrew ", textBox1.Text);
                textBox1.Clear();
            }
            catch(TooLargeException to)
            {
                MessageBox.Show(to.Message);
                textBox1.Clear();
            }
            catch(NegativeBalanceException ne)
            {
                MessageBox.Show(ne.Message);
                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }

    public class NegativeBalanceException: Exception
    {
        public NegativeBalanceException(String message) : base(message)
        {

        }

    }

    public class NegativeDepositException: Exception
    {
        public NegativeDepositException(String message) : base(message)
        {

        }
    }

    public class TooLargeException: Exception
    {
        public TooLargeException (String message) : base(message)
        {

        }
    }
}
