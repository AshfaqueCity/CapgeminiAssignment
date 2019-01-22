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
        private const char DefaultDelimeter = ',';
        private static readonly Calculator _CalculatorInstance = new Calculator();
        private Calculator()
        { 
        }
        public static Calculator CalculatorInstance
        {
            get 
            {
                return _CalculatorInstance;
            }
        }
        #endregion

        #region Add Method
        /// <summary>
        /// Calculator Add Method which will take numbers string input and will return sum of numbers
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <returns>sum of numbers</returns>
        public int Add(string inputNumbers)
        {
            try
            {
                if (inputNumbers == string.Empty)
                    return returnval;
                if (inputNumbers.Contains("-"))
                    throw new NotSupportedException(HandleNegativeNumbers(inputNumbers));
                if (IsDifferentDelimeter(inputNumbers) || IsMultipleNumber(inputNumbers))
                    return convertMultiplenumbers(inputNumbers);

                return Convert.ToInt32(inputNumbers);
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// This Method is to check weather string contain multiple numbers or not
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>boolean</returns>
        public bool IsMultipleNumber(string Number)
        {
            return Number.Contains(DefaultDelimeter) || Number.Contains('\n');
        }

        /// <summary>
        /// This Method will return sum of numbers passsed in the form of string
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns>int</returns>
        private int convertMultiplenumbers(string Numbers)
        {
            try
            {
                Numbers = ReplaceAllDelimeterswithDefaultDelimeter(Numbers);
                return Numbers.Split(DefaultDelimeter).Select(c => int.Parse(c)).Sum();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// Replace All Delimeters with Default Delimeter
        /// </summary>
        /// <param name="Numbers"></param>
        /// <returns>string numbers with default delimeters</returns>
        private static string ReplaceAllDelimeterswithDefaultDelimeter(string Numbers)
        {
            if (Numbers.Contains("//"))
                Numbers = Numbers.Replace("\\n", "\n").Substring(4).Replace('\n', DefaultDelimeter).Replace(Numbers.Substring(2, 1).ToCharArray()[0], DefaultDelimeter);
            else
                Numbers = Numbers.Replace("\\n", "\n").Replace('\n', DefaultDelimeter);
            return Numbers;
        }

        /// <summary>
        /// This Method is to check weather string containing different delimeters
        /// </summary>
        /// <param name="Number"></param>
        /// <returns>boolean</returns>
        public bool IsDifferentDelimeter(string Number)
        {
            return Number.StartsWith("//");
        }

        /// <summary>
        /// This method is used to message it find any negative numbers and give message of all negative numbers 
        /// if more than one negative numbers are available.
        /// </summary>
        /// <param name="InputString"></param>
        /// <returns>String message</returns>
        public static string HandleNegativeNumbers(string InputString)
        {
            try
            {
                string[] Numbers = InputString.Split('-');
                List<string> NegativeNumbers = new List<string>();
                if (Numbers.Count() > 2)
                {
                    if (InputString.Contains("\n") || InputString.Contains(",") || InputString.Contains("//"))
                    {
                        NegativeNumbers = ReplaceAllDelimeterswithDefaultDelimeter(InputString).Split(DefaultDelimeter).ToList<string>();
                    }
                    var Negatives = String.Join(",", NegativeNumbers.Where(x => Convert.ToInt32(x) < 0).ToList());
                    return string.Format("Can Not use negative numbers {0}", Negatives);
                }
                return "Can Not use negative numbers";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }
}
