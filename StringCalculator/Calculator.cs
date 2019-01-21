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
        public int Add(string inputNumbers)
        {
            try
            {
                int returnval = 0;
                if (inputNumbers == string.Empty)
                    returnval = 0;
                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
