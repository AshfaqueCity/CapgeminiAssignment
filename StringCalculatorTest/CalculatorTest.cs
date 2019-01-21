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

        public void checkAssertCalculator(string inputstring, int expected)
        {
            var _objCalculator = StringCalculator.Calculator._CalculatorInstance; ;
            var Result = _objCalculator.Add(inputstring);
            Assert.AreEqual(expected, Result);
        }
    }
}
