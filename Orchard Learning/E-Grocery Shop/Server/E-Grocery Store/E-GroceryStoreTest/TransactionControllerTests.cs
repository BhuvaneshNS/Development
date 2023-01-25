using AutoFixture;
using E_Grocery_Store.Common.CustomException;
using E_Grocery_Store.Controllers;
using E_Grocery_Store.Models;
using E_Grocery_Store.Repository.TransactionManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_GroceryStoreTest
{
    [TestClass]
    public class TransactionControllerTests
    {
        private Mock<ITransactionRepo> txnRepoMock;
        private Mock<ILogger<TransactionController>> loggerMock;
        private Fixture fixture;
        private TransactionController txnController;
        public TransactionControllerTests()
        {
            fixture = new Fixture();
            txnRepoMock = new Mock<ITransactionRepo>();
            loggerMock = new Mock<ILogger<TransactionController>>();
        }
        [TestMethod]
        public async Task AddToCart_ReturnsOk()
        {
            //Arrange
            var cartItem = fixture.Create<Cart>();
            txnRepoMock.Setup(repo => repo.AddToCart(It.IsAny<Cart>()));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.AddToCart(cartItem);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task AddToCart_ThrowsRequestException_BadRequest()
        {
            //Arrange
            var cartItem = fixture.Create<Cart>();
            txnRepoMock.Setup(repo => repo.AddToCart(It.IsAny<Cart>())).Throws(new RequestException("No data"));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.AddToCart(cartItem);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task CheckoutCart_ReturnsOk()
        {
            //Arrange
            var transaction = fixture.Create<Transaction>();
            txnRepoMock.Setup(repo => repo.CheckoutCart(It.IsAny<Transaction>()));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.CheckoutCart(transaction);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public async Task CheckoutCart_ThrowsError_BadRequest()
        {
            //Arrange
            Transaction transaction = null;
            txnRepoMock.Setup(repo => repo.CheckoutCart(It.IsAny<Transaction>())).Throws(new RequestException("No data"));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.CheckoutCart(transaction);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }


        [TestMethod]
        public async Task UpdateCartItem_ReturnsOk()
        {
            //Arrange
            var cartItem = fixture.Create<Cart>();
            txnRepoMock.Setup(repo => repo.UpdateCartItem(It.IsAny<Cart>()));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.UpdateCartItem(cartItem);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateCartItem_ThrowsRequestException_BadRequest()
        {
            //Arrange
            var cartItem = fixture.Create<Cart>();
            txnRepoMock.Setup(repo => repo.UpdateCartItem(It.IsAny<Cart>())).Throws(new RequestException("No data"));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.UpdateCartItem(cartItem);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }


        [TestMethod]
        public async Task GetCartItems_ReturnsOk()
        {
            //Arrange
            var items = fixture.CreateMany<Cart>(5).ToList();
            txnRepoMock.Setup(repo => repo.GetCartItems(It.IsAny<int>())).ReturnsAsync(items);
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.GetCartItems(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task GetCartItems_ThrowsException()
        {
            //Arrange
            var items = fixture.CreateMany<Cart>(5).ToList();
            txnRepoMock.Setup(repo => repo.GetCartItems(It.IsAny<int>())).Throws(new Exception());
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.GetCartItems(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }


        [TestMethod]
        public async Task DeleteCartItem_ReturnsOk()
        {
            //Arrange
            txnRepoMock.Setup(repo => repo.DeleteCartItem(It.IsAny<int>()));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.DeleteCartItem(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }


        [TestMethod]
        public async Task DeleteCartItem_ThrowsException_BadRequest()
        {
            //Arrange
            txnRepoMock.Setup(repo => repo.DeleteCartItem(It.IsAny<int>())).Throws(new RequestException("No request data"));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.DeleteCartItem(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task DeleteCartItem_ThrowsException_InternalServerError()
        {
            //Arrange
            txnRepoMock.Setup(repo => repo.DeleteCartItem(It.IsAny<int>())).Throws(new Exception("No request data"));
            txnController = new TransactionController(txnRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await txnController.DeleteCartItem(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
