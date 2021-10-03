using Calculator.Controllers;
using Calculator.InterfaceSpecifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class ArrayCalcControllerTests
    {
        private Mock<ILogger<ArrayCalcController>> _logger;
        private Mock<IArrayService> _arrayService;

        [TestInitialize]
        public void Setup()
        {
            _logger = new Mock<ILogger<ArrayCalcController>>();
            _arrayService = new Mock<IArrayService>();
        }

        #region Reverse Tests

        [TestMethod]
        public void TestReverse1()
        {
            _arrayService.Setup(x => x.Reverse<int>(It.IsAny<int[]>())).Throws(new ArgumentException("invalid"));

            var controller = new ArrayCalcController(_arrayService.Object, _logger.Object);
            var result = controller.Reverse(null);
            Assert.IsTrue(result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [TestMethod]
        public void TestReverse2()
        {
            var arr = new int[] { 5, 4, 3, 2, 1 };
            _arrayService.Setup(x => x.Reverse<int>(It.IsAny<int[]>())).Returns(arr);

            var controller = new ArrayCalcController(_arrayService.Object, _logger.Object);
            var result = controller.Reverse(new int[] { 1, 2, 3 });
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result).Value, arr);
        }

        #endregion // DeletePart Tests

        #region Reverse Tests

        [TestMethod]
        public void TestDeletePart1()
        {
            _arrayService.Setup(x => x.DeletePart<int>(It.IsAny<int[]>(), It.IsAny<int>())).Throws(new ArgumentException("invalid"));

            var controller = new ArrayCalcController(_arrayService.Object, _logger.Object);
            var result = controller.DeletePart(null, 0);
            Assert.IsTrue(result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [TestMethod]
        public void TestDeletePart2()
        {
            var arr = new int[] { 5, 4, 2, 1 };
            _arrayService.Setup(x => x.DeletePart<int>(It.IsAny<int[]>(), It.IsAny<int>())).Returns(arr);

            var controller = new ArrayCalcController(_arrayService.Object, _logger.Object);
            var result = controller.DeletePart(new int[] { 1, 2, 3 }, 2);
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result).Value, arr);
        }

        #endregion // DeletePart Tests
    }
}
