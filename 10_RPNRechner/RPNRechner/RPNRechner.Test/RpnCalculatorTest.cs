using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpnCalculator.Test
{
    [TestClass]
    public class RpnCalculatorTest
    {
        [TestMethod]
        public void TestValidNumberValidation()
        {
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("1.0"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("1.5"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("0.05"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("0.123"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("321.9999007"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("7"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("0123"));
            Assert.AreEqual(true, RpnCalculator.IsValidNumber("0"));
        }

        [TestMethod]
        public void TestInvalidNumberValidation()
        {
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("1,0"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("1/5"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("-0.05"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("0..05"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("321.999.9007"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("g9"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("vier"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("19.v97"));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber("."));
            Assert.AreEqual(false, RpnCalculator.IsValidNumber(".45"));
        }

        [TestMethod]
        public void TestValidOperatorValidation()
        {
            Assert.AreEqual(true, RpnCalculator.IsValidOperator("+"));
            Assert.AreEqual(true, RpnCalculator.IsValidOperator("-"));
            Assert.AreEqual(true, RpnCalculator.IsValidOperator("*"));
            Assert.AreEqual(true, RpnCalculator.IsValidOperator("/"));
        }

        [TestMethod]
        public void TestInvalidOperatorValidation()
        {
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("!"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("&"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("$"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("%"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("++"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("--"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("**"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("//"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator(""));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("haxi"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("V"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("5"));
            Assert.AreEqual(false, RpnCalculator.IsValidOperator("123"));
        }

        [TestMethod]
        public void TestEvaluateVeryShortExpression()
        {
            double result = RpnCalculator.EvaluateExpression("5");
            Assert.AreEqual(5.0, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateSimpleAddition()
        {
            double result = RpnCalculator.EvaluateExpression("5 7.0 +");
            Assert.AreEqual(12.0, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateSimpleSubtraction()
        {
            double result = RpnCalculator.EvaluateExpression("0.39 0.32 -");
            Assert.AreEqual(0.07, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateSimpleMultiplication()
        {
            double result = RpnCalculator.EvaluateExpression("8.5 5 *");
            Assert.AreEqual(42.5, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateSimpleDivision()
        {
            double result = RpnCalculator.EvaluateExpression("40 2.5 /");
            Assert.AreEqual(16.0, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateLongerExpressions()
        {
            double result = RpnCalculator.EvaluateExpression("1 2 + 3 4 + +");
            Assert.AreEqual(10.0, result, 0.001);

            result = RpnCalculator.EvaluateExpression("6 5 2 3 + 8 * + 3 + *");
            Assert.AreEqual(288.0, result, 0.001);

            result = RpnCalculator.EvaluateExpression("14 3.5 / 4 + 17.3 9.3 - * 2.5 /");
            Assert.AreEqual(25.6, result, 0.001);

            result = RpnCalculator.EvaluateExpression("10 9 12 / * 2.25 + 0.55 - 4.5 4 * + 1111 11 / *");
            Assert.AreEqual(2747.2, result, 0.001);
        }

        [TestMethod]
        public void TestEvaluateInvalidExpressions()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 + 3,0 4 * +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 ++ 3.0 4 * +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 + 3.0 haxi * +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 + 3.0 4 x +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 + 3.0 4 x +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1.0 2.5 + 3.0 . * +");
            });

            Assert.AreEqual("Expression must contain only numbers and valid operators!", ex.Message);
        }

        [TestMethod]
        public void TestEvaluateOperationsOnEmptyStacks()
        {
            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("*");
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1 +");
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1 2 + -");
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);

            ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double result = RpnCalculator.EvaluateExpression("1 2 + 3 - *");
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);
        }
    }
}
