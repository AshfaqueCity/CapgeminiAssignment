using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public sealed class Calculator
    {
        #region Class Instance Members(Singleton)
        private const int returnval = 0;
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
        #endregion

        #region Add Method
        public int Add(string inputNumbers)
        {
            try
            {
                if (inputNumbers == string.Empty)
                    return returnval;
                if (IsMultipleNumber(inputNumbers))
                    return convertMultiplenumbers(inputNumbers.Replace("\\n", "\n").Replace('\n', ','), ",");
                return Convert.ToInt32(inputNumbers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region Methods
        public bool IsMultipleNumber(string Number)
        {
            return Number.Contains(',') || Number.Contains('\n');
        }
        private int convertMultiplenumbers(string Numbers, string Delimeter)
        {
            try
            {
                return Numbers.Split(Delimeter.ToCharArray()[0]).Select(c => int.Parse(c)).Sum();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        #endregion
    }
}
