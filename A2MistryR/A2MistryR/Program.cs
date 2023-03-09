/*Title: Rutvi Mistry Assignment2
 * Name of Project: Monthly subscription charges
 * Purpose: To calculate monthly subscription based on age, month of starting, refferanl and applicable taxes.
 * Revision History: Rutvi Mistry, 2023.02.18, Created
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A2MistryR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            string month, refferal;
            double ageFee, startMonthAdjustment, refferalDiscount, subTotal, hst, cityTaxes, finalFee;
            hst = 0.00;
            cityTaxes = 0.00;
            subTotal = 0.00;
            double hstValue = 0.13;
            double cityTaxValue = 0.09;

            //1. Ask user to input the age and define age fee
            Console.Write("Please enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());
            ageFee = 0.00;

            if (age <= 13)
            {
                Console.WriteLine("Sorry Applicant can't register");
            }
            else
            {
                if (age <= 19)
                {
                    ageFee = 10.00;
                }
                else if (age <= 29)
                {
                    ageFee = 35.50;
                }
                else if (age <= 64)
                {
                    ageFee = 70.50;
                }
                else
                {
                    ageFee = 0.00;
                }

                //2. Ask user for starting month of the subscription and get input, and define start month adjustment
                Console.Write("Enter the start month of subscription: ");
                month = Convert.ToString(Console.ReadLine());
                month = month.ToLower();
                startMonthAdjustment = 0.00;
                    switch (month)
                {
                    case "january":
                    case "february":
                        startMonthAdjustment = -10.00;                      
                        break;
                    case "march":
                        startMonthAdjustment = ageFee * (-0.10);                        
                        break;
                    case "april":
                    case "may":
                        startMonthAdjustment = 20.00;                       
                        break;
                    default:
                        Console.WriteLine("There is no adjustment made");
                        break;
                }
                subTotal = ageFee + startMonthAdjustment;


                //3. Ask user if they are reffered by an existing client and take input; and calculate based on the input
                Console.Write("Are you reffered by existing client: ");
                refferal = Convert.ToString(Console.ReadLine());
                refferal = refferal.ToLower();
                Console.Clear();

                

                if (refferal == "yes")
                {
                    refferalDiscount = 0.00;
                    refferalDiscount = -25.00;
                    subTotal = ageFee + startMonthAdjustment + refferalDiscount;
                }
                else
                {
                    refferalDiscount = 0.00;
                    subTotal = ageFee + startMonthAdjustment - refferalDiscount;
                }

                //4. Calculate Subtotal icluding hst and city taxes

                if (subTotal >= 0)
                {
                    Console.WriteLine($"\nYour Age: {age}");
                    Console.WriteLine($"Your Registration Month: {month}");
                    Console.WriteLine($"\nMonthly subscription based on age:    {ageFee.ToString("C")}");
                    Console.WriteLine($"Start Month adjustment:               {startMonthAdjustment.ToString("C")}");
                    Console.WriteLine($"Client referral discount:             {refferalDiscount.ToString("C")}");
                    Console.WriteLine($"\nSubtotal:                             {subTotal.ToString("C")}\n\n");
                    hst = subTotal * hstValue;
                    cityTaxes = subTotal * cityTaxValue;
                }
                else if (subTotal <= 0)
                {
                    subTotal = 0.00;
                    hst = 0.00;
                    cityTaxes = 0.00;
                    Console.WriteLine($"\nYour Age: {age}");
                    Console.WriteLine($"Your Registration Month: {month}");
                    Console.WriteLine($"\nMonthly subscription based on age:    {ageFee.ToString("C")}");
                    Console.WriteLine($"Start Month adjustment:               {startMonthAdjustment.ToString("C")}");
                    Console.WriteLine($"Client referral discount:             {refferalDiscount.ToString("C")}");
                    Console.WriteLine($"\nSubtotal:                             {subTotal.ToString("C")}\n\n");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }

                //5. Calculate final fee and display output
                finalFee = subTotal + hst + cityTaxes;
                Console.WriteLine($"HST:                                  {hst.ToString("C")}");
                Console.WriteLine($"City service Tax:                     {cityTaxes.ToString("C")}");
                Console.WriteLine($"\n\nFinal Monthly Subscription Total:     {finalFee.ToString("C")}");
            
            }
            Console.ReadKey();
        }
    }
}
