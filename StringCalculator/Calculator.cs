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
        private const string DefaultDelimeter = ",";
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        public bool IsMultipleNumber(string Number)
        {
            return Number.Contains(DefaultDelimeter) || Number.Contains('\n');
        }
        private int convertMultiplenumbers(string Numbers)
        {
            try
            {
                if (Numbers.Contains("//"))
                    Numbers = Numbers.Replace("\\n", "\n").Substring(4).Replace("\n", DefaultDelimeter).Replace(Numbers.Substring(2, 1), DefaultDelimeter);
                else
                    Numbers = Numbers.Replace("\\n", "\n").Replace("\n", DefaultDelimeter);
                return Numbers.Split(DefaultDelimeter.ToCharArray()[0]).Select(c => int.Parse(c)).Sum();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public bool IsDifferentDelimeter(string Number)
        {
            return Number.StartsWith("//");
        }
        public static string HandleNegativeNumbers(string InputString)
        {
            string[] Numbers = InputString.Split('-');
            List<string> NegativeNumbers=new List<string>();
            if (Numbers.Count() > 2)
            {
                
                string Negatives = "";
                if (InputString.Contains("\n") || InputString.Contains(","))
                {
                    NegativeNumbers = SplitNumbers(InputString.Replace("\\n", "\n").Replace('\n', ','), ",").ToList<string>();
                }
                if (InputString.Contains("//"))
                {
                    NegativeNumbers = SplitNumbers(InputString.Substring(4), InputString.Substring(2, 1)).ToList<string>();
                }
                Negatives = GetNegativeNumbers(NegativeNumbers);
                return string.Format("Can Not use negative numbers {0}", Negatives);
            }


            return "Can Not use negative numbers";
        }
        public static string[] SplitNumbers(string InputNumbers, string Delimeter)
        {
            return InputNumbers.Split(Delimeter.ToCharArray()[0]);
        }
        public static string GetNegativeNumbers(List<string> InputList)
        {
            string output = "";
            for (int i = 0; i < InputList.Count(); i++)
            {
                if (InputList[i].Contains('-'))
                    output += InputList[i] + ",";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        #endregion
    }
}
