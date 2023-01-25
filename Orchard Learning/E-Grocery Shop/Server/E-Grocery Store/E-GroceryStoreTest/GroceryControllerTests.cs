using AutoFixture;
using E_Grocery_Store.Common.CustomException;
using E_Grocery_Store.Controllers;
using E_Grocery_Store.Models;
using E_Grocery_Store.Repository.GroceryManagement;
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
    public class GroceryControllerTests
    {
        private Mock<IGroceryRepo> groceryRepoMock;
        private Mock<ILogger<GroceryController>> loggerMock;
        private Fixture fixture;
        private GroceryController groceryController;
        public GroceryControllerTests()
        {
            fixture = new Fixture();
            groceryRepoMock = new Mock<IGroceryRepo>();
            loggerMock = new Mock<ILogger<GroceryController>>();
        }

        [TestMethod]
        public async Task AddGrocery_ReturnsOk()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.AddGrocery(It.IsAny<Grocery>()));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.AddGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public async Task AddGrocery_ThrowsRequestExceprion_BadRequest()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.AddGrocery(It.IsAny<Grocery>())).Throws(new RequestException(" no data"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.AddGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task AddGrocery_ThrowsExceprion_BadRequest()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.AddGrocery(It.IsAny<Grocery>())).Throws(new Exception(" Wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.AddGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }
        [TestMethod]
        public async Task UpdateGrocery_ReturnsOk()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.UpdateGrocery(It.IsAny<Grocery>()));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.UpdateGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateGrocery_ThrowsRequestExceprion_BadRequest()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.UpdateGrocery(It.IsAny<Grocery>())).Throws(new RequestException(" no data"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.UpdateGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task UpdateGrocery_ThrowsExceprion_BadRequest()
        {
            //Arrange
            var grocery = fixture.Create<Grocery>();
            groceryRepoMock.Setup(repo => repo.UpdateGrocery(It.IsAny<Grocery>())).Throws(new Exception(" Wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);

            //Act
            var actionResult = await groceryController.UpdateGrocery(grocery);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [TestMethod]
        public async Task GetGroceries_ReturnsOk()
        {
            //Arrange
            var groceryList = fixture.CreateMany<Grocery>(5).ToList();
            groceryRepoMock.Setup(repo => repo.GetGroceries()).ReturnsAsync(groceryList);
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.GetGroceries();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        //[TestMethod]
        //public async Task GetGroceries_ThrowsResponseException_NoContent()
        //{
        //    //Arrange
        //    var groceryList = fixture.CreateMany<Grocery>(5).ToList();
        //    groceryRepoMock.Setup(repo => repo.GetGroceries()).Throws(new ResponseException("No content"));
        //    groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
        //    //Act
        //    var actionResult = await groceryController.GetGroceries();
        //    var result = actionResult.Result as ObjectResult;
        //    //Assert
        //    Assert.AreEqual(204, result.StatusCode);
        //}

        [TestMethod]
        public async Task GetGroceries_ThrowsException_InternalServerError()
        {
            //Arrange
            var groceryList = fixture.CreateMany<Grocery>(5).ToList();
            groceryRepoMock.Setup(repo => repo.GetGroceries()).Throws(new Exception("wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.GetGroceries();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [TestMethod]
        public async Task GetGroceryCategory_ReturnsOk()
        {
            //Arrange
            var categories = fixture.CreateMany<GroceryCategory>(5).ToList();
            groceryRepoMock.Setup(repo => repo.GetGroceryCategories()).ReturnsAsync(categories);
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.GetGroceryCategories();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task GetGroceryCategory_ThrowsException()
        {
            //Arrange
            var categories = fixture.CreateMany<GroceryCategory>(5).ToList();
            groceryRepoMock.Setup(repo => repo.GetGroceryCategories()).Throws(new Exception("Wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.GetGroceryCategories();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

        [TestMethod]
        public async Task DeleteGrocery_ReturnsOk()
        {
            //Arrange
            groceryRepoMock.Setup(repo => repo.DeleteGrocery(It.IsAny<int>()));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.DeleteGrocery(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public async Task DeleteGrocery_ThrowsException()
        {
            //Arrange
            groceryRepoMock.Setup(repo => repo.DeleteGrocery(It.IsAny<int>())).Throws(new Exception("Wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.DeleteGrocery(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }


        [TestMethod]
        public async Task AdminRejectGrocery_ReturnsOk()
        {
            //Arrange
            groceryRepoMock.Setup(repo => repo.AdminRejectGrocery(It.IsAny<int>()));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.AdminRejectGrocery(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task AdminRejectGrocery_ThrowsException()
        {
            //Arrange
            groceryRepoMock.Setup(repo => repo.AdminRejectGrocery(It.IsAny<int>())).Throws(new Exception("Wrong"));
            groceryController = new GroceryController(groceryRepoMock.Object, loggerMock.Object);
            //Act
            var actionResult = await groceryController.AdminRejectGrocery(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(500, result.StatusCode);
        }

    }
}
