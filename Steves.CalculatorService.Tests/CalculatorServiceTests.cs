using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Steves.CalculatorService.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        #region Reverse Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),  "vals")]
        public void TestReverse1()
        {
            var service = new CalculatorService();

            var result = service.Reverse<int>(null);
        }

        [TestMethod]
        public void TestReverse2()
        {
            var testArray = new int[] { 23, 78, 4, 12, 7, -4 };
            var service = new CalculatorService();

            var result = service.Reverse<int>(testArray);

            Assert.AreEqual(testArray.Length, result.Length);
            for (var i = 0; i < testArray.Length; i++)
                Assert.AreEqual(testArray[i], result[testArray.Length - i - 1]);
        }

        [TestMethod]
        public void TestReverse3()
        {
            var testArray = new int[] { }; // Empty
            var service = new CalculatorService();

            var result = service.Reverse<int>(testArray);

            Assert.AreEqual(testArray.Length, result.Length);
            for (var i = 0; i < testArray.Length; i++)
                Assert.AreEqual(testArray[i], result[testArray.Length - i - 1]);
        }

        [TestMethod]
        public void TestReverse4()
        {
            var testArray = new int[] { 42 }; // Singl entry
            var service = new CalculatorService();

            var result = service.Reverse<int>(testArray);

            Assert.AreEqual(testArray.Length, result.Length);
            Assert.AreEqual(testArray[0], result[0]);
        }

        #endregion // Reverse Tests

        #region DeletePart Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "vals")]
        public void TestDeletePart1()
        {
            var service = new CalculatorService();

            var result = service.DeletePart<int>(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Outside of range of array supplied in vals parameter")]
        public void TestDeletePart2()
        {
            var testArray = new int[] { 454, 67, 12, 6, 9, -2, 4 };
            var service = new CalculatorService();

            var result = service.DeletePart<int>(testArray, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Outside of range of array supplied in vals parameter")]
        public void TestDeletePart3()
        {
            var testArray = new int[] { 454, 67, 12, 6, 9, -2, 4 };
            var service = new CalculatorService();

            var result = service.DeletePart<int>(testArray, testArray.Length + 1);
        }

        [TestMethod]
        public void TestDeletePart4()
        {
            var testArray = new int[] { 454, 67, 12, 6, 9, -2, 4 };
            var service = new CalculatorService();
            var position = 4;

            var result = service.DeletePart<int>(testArray, position);

            CheckDeletedPart(testArray, position, result);
        }

        [TestMethod]
        public void TestDeletePart5()
        {
            var testArray = new int[] { 454, 67, 12, 6, 9, -2, 4 };
            var service = new CalculatorService();
            var position = testArray.Length; // End

            var result = service.DeletePart<int>(testArray, position);

            CheckDeletedPart(testArray, position, result);
        }

        [TestMethod]
        public void TestDeletePart6()
        {
            var testArray = new int[] { 454, 67, 12, 6, 9, -2, 4 };
            var service = new CalculatorService();
            var position = 1; // Start

            var result = service.DeletePart<int>(testArray, position);

            CheckDeletedPart(testArray, position, result);
        }

        private static void CheckDeletedPart(int[] testArray, int position, int[] result)
        {
            Assert.AreNotEqual(testArray.Length, result.Length);
            for (var i = 0; i < testArray.Length; i++)
            {
                var y = (i + 1 >= position ? i - 1 : i);
                if (i != position - 1)
                    Assert.AreEqual(testArray[i], result[y]);
            }
        }

        #endregion // DeletePart Tests
    }
}
