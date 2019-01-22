using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var _objCalculator =  Calculator.CalculatorInstance;
                Loop:
                Console.WriteLine("Please Enter Any String Number To Get Sum");
                string InputString = Console.ReadLine();
                Console.WriteLine(_objCalculator.Add(InputString));
                Console.WriteLine("Please enter 1 to continue.Or type another keyword to exit");
                string choice = Console.ReadLine();
                if (choice == "1")
                    goto Loop;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
           
        }
    }
}
