/*Wendy Faulk
 * 6/7/2021
 * Exercise 7-2 Enhance the Future Value application
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {   //declare and initialize variables
            int years = 0;
            decimal yearlyInterestRate = 0;
            decimal monthlyInvestment = 0;

            try
            {
                monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                years = Convert.ToInt32(txtYears.Text);

                int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
                decimal futureValue = this.CalculateFutureValue(
                    monthlyInvestment, monthlyInterestRate, months);
                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();

                //STEP 7
                //if (isValidData())
                //{
                //  
                //}
            }
            catch (FormatException)  //a specific exception
            {       //this error's message box w/ error type
                MessageBox.Show("a format exception has occured. please check your entries", "entry error");
            }

            catch (OverflowException)   //another specific exception
            {       //this error's message box w/ error type
                MessageBox.Show("an overflow exception has occured. Please enter smaller values", "overflow error");
            }
            catch (Exception ex)    //other exceptions
            {
                MessageBox.Show(ex.Message + ex.GetType().ToString() + ex.StackTrace, "Error");
            }
            //int months = years * 12;
            //decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            //decimal futureValue = this.CalculateFutureValue(
            //    monthlyInvestment, monthlyInterestRate, months);
            //txtFutureValue.Text = futureValue.ToString("c");
            //txtMonthlyInvestment.Focus();

        }


        //STEP 6: isvaliddata method calls 3 generic methods. Each text box--test for 2 types of invalid data: format & range.

        public bool isValidData()
        {
            return
                isPresent(txtMonthlyInvestment, "Monthly investment") &&
                isPresent(txtInterestRate, "Yearly interest rate") &&
                isPresent(txtYears, "Number of years");
        }
        //This isn't in the instructions?
        /*Verify that fields aren't empty*/
        public bool isPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        //STEP 5: 3 generic valid methods decimal, int32, withinrange
        //fill in code from textbook
        /* ensure values are decimals*/
        private string isDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a vaild decimal value.\n";
            }
            return msg;
        }

        /* ensure values are integers*/
        private string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg += name + " must be a vaild integer value.\n";
            }
            return msg;
        }

        /* ensure values are in range*/
        private string IsWithinRange(string value, string name, decimal min, decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                    msg += name + " must be between " + min + " and " + max + ".\n";

            }
            return msg;
        }

        //public bool IsInt32(TextBox textBox, string name)
        //{
        //    /*fill in code from textbook*/



        //    return true;
        //}

        //public bool IsWithinRange(TextBox textBox, string name, )
        //{
        //    /*fill in code from textbook*/
        //    if ))
        //    {
        //        MessageBox.Show(name + " must be a valid decimal value.");
        //        textBox.Focus();
        //        return false;
        //    }
        //    return true;
        //}


        //note to self: done with this section
        private decimal CalculateFutureValue(decimal monthlyInvestment,
            decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            ////create throw statement that throws a new exception of the Exception class regardless of the results of the calculation//
            //if (monthlyInvestment >= 0)
            //{   //Indicate unknown error
            //    throw new Exception("Unknown Error.");
            //}
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
