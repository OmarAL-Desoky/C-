using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RPNRechner;

namespace RpnCalculator.Test
{
    [TestClass]
    public class NumberStackTest
    {
        [TestMethod]
        public void TestEmptyStackIsEmpty()
        {
            NumberStack stack = new NumberStack();

            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void TestEmptyStackPeekThrowsException()
        {
            NumberStack stack = new NumberStack();

            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Peek();
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);
        }

        [TestMethod]
        public void TestEmptyStackPopThrowsException()
        {
            NumberStack stack = new NumberStack();

            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
                    {
                        double number = stack.Pop();
                    });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);
        }

        [TestMethod]
        public void TestPushPopOneNumber()
        {
            NumberStack stack = new NumberStack();

            Assert.AreEqual(true, stack.IsEmpty);

            stack.Push(19.74);

            Assert.AreEqual(false, stack.IsEmpty);

            double number = stack.Pop();

            Assert.AreEqual(19.74, number, 0.001);

            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void TestPushPeekOneNumber()
        {
            NumberStack stack = new NumberStack();

            Assert.AreEqual(true, stack.IsEmpty);

            stack.Push(19.74);

            Assert.AreEqual(false, stack.IsEmpty);

            double number = stack.Peek();

            Assert.AreEqual(19.74, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);
        }

        [TestMethod]
        public void TestPushPopPushPop()
        {
            NumberStack stack = new NumberStack();

            Assert.AreEqual(true, stack.IsEmpty);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(false, stack.IsEmpty);

            Assert.AreEqual(3, stack.Pop());

            stack.Push(4);

            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
             
            stack.Push(5);

            Assert.AreEqual(5, stack.Pop());

            stack.Push(6);

            Assert.AreEqual(false, stack.IsEmpty);

            Assert.AreEqual(6, stack.Pop());
            Assert.AreEqual(1, stack.Pop());

            Assert.AreEqual(true, stack.IsEmpty);

            stack.Push(7);

            Assert.AreEqual(false, stack.IsEmpty);

            Assert.AreEqual(7, stack.Pop());

            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void TestPushPopManyNumbers()
        {
            NumberStack stack = new NumberStack();

            Assert.AreEqual(true, stack.IsEmpty);

            stack.Push(2.6);
            stack.Push(1.3);
            stack.Push(26.0);
            stack.Push(3.6);
            stack.Push(2.0);
            stack.Push(6.0);

            Assert.AreEqual(false, stack.IsEmpty);

            double number = stack.Pop();
            Assert.AreEqual(6.0, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);

            number = stack.Pop();
            Assert.AreEqual(2.0, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);

            number = stack.Pop();
            Assert.AreEqual(3.6, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);

            number = stack.Pop();
            Assert.AreEqual(26.0, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);

            number = stack.Pop();
            Assert.AreEqual(1.3, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);

            number = stack.Pop();
            Assert.AreEqual(2.6, number, 0.001);

            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void TestPushPeekPopManyNumbers()
        {
            NumberStack stack = new NumberStack();

            stack.Push(2.6);
            stack.Push(1.3);
            stack.Push(26.0);
            stack.Push(3.6);
            stack.Push(2.0);
            stack.Push(6.0);

            double number = stack.Peek();
            Assert.AreEqual(6.0, number, 0.001);
            number = stack.Peek();
            Assert.AreEqual(6.0, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(6.0, number, 0.001);

            number = stack.Pop();
            Assert.AreEqual(2.0, number, 0.001);

            number = stack.Peek();
            Assert.AreEqual(3.6, number, 0.001);
            stack.Pop();
            Assert.AreEqual(3.6, number, 0.001);

            number = stack.Peek();
            Assert.AreEqual(26.0, number, 0.001);
            stack.Peek();
            Assert.AreEqual(26.0, number, 0.001);
            stack.Peek();
            Assert.AreEqual(26.0, number, 0.001);
            stack.Pop();
            Assert.AreEqual(26.0, number, 0.001);

            number = stack.Pop();
            Assert.AreEqual(1.3, number, 0.001);

            number = stack.Peek();
            Assert.AreEqual(2.6, number, 0.001);
            stack.Peek();
            Assert.AreEqual(2.6, number, 0.001);

            Assert.AreEqual(false, stack.IsEmpty);
        }

        [TestMethod]
        public void TestPopTooManyThrowsException()
        {
            NumberStack stack = new NumberStack();

            stack.Push(5.7);
            stack.Push(1.8);
            stack.Push(4.5);
            stack.Push(4.7);
            stack.Push(5);
            stack.Push(7);

            double number = stack.Pop();
            Assert.AreEqual(7, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(5, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(4.7, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(4.5, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(1.8, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(5.7, number, 0.001);

            Assert.AreEqual(true, stack.IsEmpty);

            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Pop();
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);
        }

        [TestMethod]
        public void TestPeekTooManyThrowsException()
        {
            NumberStack stack = new NumberStack();

            stack.Push(5.7);
            stack.Push(1.8);
            stack.Push(4.5);
            stack.Push(4.7);
            stack.Push(5);
            stack.Push(7);

            double number = stack.Pop();
            Assert.AreEqual(7, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(5, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(4.7, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(4.5, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(1.8, number, 0.001);
            number = stack.Pop();
            Assert.AreEqual(5.7, number, 0.001);

            Assert.AreEqual(true, stack.IsEmpty);

            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Peek();
            });

            Assert.AreEqual("There are no elements in the stack!", ex.Message);
        }
    }
}
