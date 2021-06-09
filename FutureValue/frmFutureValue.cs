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
        {
            try
            {   //STEP 7: use IsValidData() method
                //Wendy! You did a great job!
                if (IsValidData())
                {
                    decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(txtYears.Text);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;
                    decimal futureValue = this.CalculateFutureValue(
                        monthlyInvestment, monthlyInterestRate, months);

                    txtFutureValue.Text = futureValue.ToString("c");
                    txtMonthlyInvestment.Focus();
                }
            }
           //catch (FormatException)  //a specific exception
           // {       //this error's message box w/ error type
           //     MessageBox.Show("a format exception has occured. please check your entries", "entry error");
           // }

           // catch (OverflowException)   //another specific exception
           // {       //this error's message box w/ error type
           //     MessageBox.Show("an overflow exception has occured. Please enter smaller values", "overflow error");
           // }
            catch (Exception ex)    //other exceptions
            {
                MessageBox.Show(ex.Message + ex.GetType().ToString() + ex.StackTrace, "Exception");
            }
        }


        //STEP 6: isvaliddata method calls 3 generic methods. Each text box--test for 2 types of invalid data: format & range.

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";

            errorMessage += IsPresent(txtMonthlyInvestment.Text, txtMonthlyInvestment.Tag.ToString());
            errorMessage += IsDecimal(txtMonthlyInvestment.Text, txtMonthlyInvestment.Tag.ToString());
            errorMessage += IsWithinRange(txtMonthlyInvestment.Text, txtMonthlyInvestment.Tag.ToString(), 1, 1000);

            errorMessage += IsPresent(txtInterestRate.Text, txtInterestRate.Tag.ToString());
            errorMessage += IsDecimal(txtInterestRate.Text, txtInterestRate.Tag.ToString());
            errorMessage += IsWithinRange(txtInterestRate.Text, txtInterestRate.Tag.ToString(), 1, 20);

            errorMessage += IsPresent(txtYears.Text, txtYears.Tag.ToString());
            errorMessage += IsInt32(txtYears.Text, txtYears.Tag.ToString());
            errorMessage += IsWithinRange(txtYears.Text, txtYears.Tag.ToString(), 1, 40);

            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }

        //this isn't in the instructions?
        /*verify that fields aren't empty*/
        private string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg = name + " is a required field.\n";
            }
            return msg;
        }

        //STEP 5: 3 generic valid methods decimal, int32, withinrange
        //fill in code from textbook
        /* ensure values are decimals*/
        private string IsDecimal(string value, string name)
        {      //declaring variable for message
            string msg = "";
            if (!Decimal.TryParse(value, out decimal number))
            {
                msg += name + " must be a vaild decimal value.\n";
            }
            return msg;
        }

        /* ensure values are integers*/
        private string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out int number))
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
