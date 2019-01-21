using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public sealed class Calculator
    {
        private static readonly Calculator CalculatorInstance = new Calculator();
        private Calculator()
        { 
        }
        public static Calculator _CalculatorInstance
        {
            get 
            {
                return CalculatorInstance;
            }
        }

        private const int returnval = 0;
        public int Add(string inputNumbers)
        {
            try
            {
                if (inputNumbers == string.Empty)
                    return returnval;
                return Convert.ToInt32(inputNumbers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
