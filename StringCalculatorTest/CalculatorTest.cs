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
        public void Calculator_WithEmptyStringReturn0()
        {
            StringCalculator.Calculator _objCalculator = new StringCalculator.Calculator();
            var Result = _objCalculator.Add("");
            Assert.AreEqual(0, Result);
        }
    }
}
