using AutoFixture;
using E_Grocery_Store.Common.CustomException;
using E_Grocery_Store.Controllers;
using E_Grocery_Store.Models;
using E_Grocery_Store.Repository.AccountManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace E_GroceryStoreTest
{
    [TestClass]
    public class AccountControllerTests
    {
        private Mock<IAccountRepo> accountRepoMock;
        private Mock<ILogger<AccountController>> loggerMock;
        private Fixture fixture;
        private AccountController accountController;
        public AccountControllerTests()
        {
            fixture = new Fixture();
            accountRepoMock = new Mock<IAccountRepo>();
            loggerMock = new Mock<ILogger<AccountController>>();
        }
        [TestMethod]
        public async Task SignUp_ReturnsOk()
        {
            //Arrange
            var user = fixture.Create<User>();
            accountRepoMock.Setup(repo => repo.SignUp(It.IsAny<User>()));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignUp(user);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task SignUp_ThrowsException_BadRequest()
        {
            //Arrange
            var user = fixture.Create<User>();
            accountRepoMock.Setup(repo => repo.SignUp(It.IsAny<User>())).Throws(new RequestException("No request data"));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignUp(user);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task SignUp_ThrowsException_InternalServerError()
        {
            //Arrange
            var user = fixture.Create<User>();
            accountRepoMock.Setup(repo => repo.SignUp(It.IsAny<User>())).Throws(new Exception("Something went wrong"));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignUp(user);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }


        [TestMethod]
        public async Task SignIn_ReturnsOk()
        {
            //Arrange
            var credential = fixture.Create<SignInRequest>();
            accountRepoMock.Setup(repo => repo.SignIn(It.IsAny<SignInRequest>()));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignIn(credential);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public async Task SignIn_ThrowsERequestException_BadRequest()
        {
            //Arrange
            var credential = fixture.Create<SignInRequest>();
            accountRepoMock.Setup(repo => repo.SignIn(It.IsAny<SignInRequest>())).Throws(new RequestException("No request data"));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignIn(credential);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task SignIn_ThrowsInvalidCredentialException_BadRequest()
        {
            //Arrange
            var credential = fixture.Create<SignInRequest>();
            accountRepoMock.Setup(repo => repo.SignIn(It.IsAny<SignInRequest>())).Throws(new InvalidCredentialException("Invalid Credentials"));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignIn(credential);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task InternalServerError()
        {
            //Arrange
            var credential = fixture.Create<SignInRequest>();
            accountRepoMock.Setup(repo => repo.SignIn(It.IsAny<SignInRequest>())).Throws(new Exception("Invalid Credentials"));
            accountController = new AccountController(accountRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await accountController.SignIn(credential);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
