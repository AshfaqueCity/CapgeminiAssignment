using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        /// <summary>
        /// Below Test is for Testing Empty string which should Add as return 0
        /// </summary>
        [TestMethod]
        [DataRow("", 0)]
        public void Calculator_WithEmptyStringReturn0(string inputstring, int expected)
        {
            checkAssertCalculator(inputstring, expected);
        }

        /// <summary>
        /// Below Test is for Testing Single number which return same number
        /// for DataRow, install the NuGet packages MSTest.TestFramework and MSTest.TestAdapter and
        /// Remove Microsoft.VisualStudio.QualityTools.UnitTestFramework from references of the project
        /// </summary>
        [TestMethod]
        [DataRow("5", 5)]
        [DataRow("10", 10)]
        public void Calculator_WithOneNumberReturnSameNumner(string inputstring, int expected)
        {
            checkAssertCalculator(inputstring, expected);
        }

        /// <summary>
        /// Below Test is for Testing multiple amount of numbers which return Sum of those numbers
        /// </summary>
        [TestMethod]
        [DataRow("5,6", 11)]
        [DataRow("10,1,5", 16)]
        public void Calculator_WithOneOrMoreNumbersReturnSumOfNumners(string inputstring, int expected)
        {
            checkAssertCalculator(inputstring, expected);
        }

        /// <summary>
        /// Below Test is for Testing new line between numbers which return Sum of numbers
        /// </summary>
        [TestMethod]
        [DataRow("5\n6", 11)]
        [DataRow("10\n1,5", 16)]
        //[DataRow("1,\n", 1)]
        public void Calculator_WithNewLineAndNumbersReturnSumOfNumners(string inputstring, int expected)
        {
            checkAssertCalculator(inputstring, expected);
        }

        /// <summary>
        /// Below Test is for Testing to Support Different Delimiter which return Sum of numbers
        /// </summary>
        [TestMethod]
        [DataRow("//;\n5;6", 11)]
        [DataRow("//@\n10@1@5", 16)]
        [DataRow("//#\n15#1#5\n58", 79)]
        public void Calculator_WithDifferentDelimiterAndNumbersReturnSumOfNumners(string inputstring, int expected)
        {
            checkAssertCalculator(inputstring, expected);
        }

       /// <summary>
        /// Below Test is to check Negative no and through exception
        /// </summary>
        [TestMethod]
        [DataRow("-5,7", "Can Not use negative numbers -5")]
        [DataRow("-6,-77,8", "Can Not use negative numbers -6,-77")]
        public void Calculator_CheckNegativeNumberAndThroughException(string inputstring, string expected)
        {
            try
            {
                var _objCalculator = StringCalculator.Calculator.CalculatorInstance;
                _objCalculator.Add(inputstring);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Equals(expected));
            }
        }

        public void checkAssertCalculator(string inputstring, int expected)
        {
            var _objCalculator = StringCalculator.Calculator.CalculatorInstance;
            var Result = _objCalculator.Add(inputstring);
            Assert.AreEqual(expected, Result);
        }
    }
}
