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
                if (isValidData())
                {
                    monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    years = Convert.ToInt32(txtYears.Text);
                }
            }
            catch (FormatException)  //a specific exception
            {       //this error's message box w/ error type
                MessageBox.Show("a format exception has occured. please check your entries", "entry error");
            }

            catch (OverflowException)   //another specific exception
            {       //this error's message box w/ error type
                MessageBox.Show("an overflow exception has occured. please enter smaller values", "overflow error");
            }
            catch (Exception ex)    //other exceptions
            {
                MessageBox.Show(ex.Message + ex.GetType().ToString() + ex.StackTrace, "Error");
            }
            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
            decimal futureValue = this.CalculateFutureValue(
                monthlyInvestment, monthlyInterestRate, months);
            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();

        }

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

        public bool isValidData()
        {
            return
                isPresent(txtMonthlyInvestment, "Monthly investment") &&
                isPresent(txtInterestRate, "Yearly interest rate") &&
                isPresent(txtYears, "Number of years");
        }

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

        public bool isDecimal(string value, string name)
        {
            /*fill in code from textbook*/
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a vaild decimal value.";
                return false;
            }
            return true;
        }

        //public bool IsInt32(TextBox textBox, string name)
        //{
        //    /*fill in code from textbook*/



        //    return true;
        //}

        //public bool (TextBox textBox, string name)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
