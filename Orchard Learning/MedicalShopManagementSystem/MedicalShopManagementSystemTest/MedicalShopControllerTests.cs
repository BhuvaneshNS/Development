using AutoFixture;
using MedicalShopManagementSystem.Common.CustomException;
using MedicalShopManagementSystem.Controllers;
using MedicalShopManagementSystem.Models;
using MedicalShopManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShopManagementSystemTest
{
    [TestClass]
    public class MedicalShopControllerTests
    {
        private Mock<IMedicalShopRepository> medicalshopRepoMock;
        private Fixture fixture;
        private MedicalShopController medicalShopController;
        public MedicalShopControllerTests()
        {
            fixture = new Fixture();
            medicalshopRepoMock = new Mock<IMedicalShopRepository>();
        }

        //Method to test action method which return all employees with status code 200
        [TestMethod]
        public async Task GetMedicalShops_ReturnsOk()
        {
            //Arrange
            var medicalShopList = fixture.CreateMany<MedicalShopModel>(5).ToList();
            medicalshopRepoMock.Setup(repo => repo.GetMedicalShops()).ReturnsAsync(medicalShopList);
            medicalShopController = new MedicalShopController(medicalshopRepoMock.Object);
            //Act
            var actionResult = await medicalShopController.GetMedicalShops();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        //Method to test action method which r status code 404 if no shops present
        [TestMethod]
        public async Task GetMedicalShops_ThrowException()
        {
            //Arrange
            medicalshopRepoMock.Setup(repo => repo.GetMedicalShops()).Throws(new EmptyException("No result"));
            medicalShopController = new MedicalShopController(medicalshopRepoMock.Object);
            //Act
            var actionResult = await medicalShopController.GetMedicalShops();
            var result = actionResult.Result as ObjectResult;
            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        //Method to test action method which return all employees with status code 200
        [TestMethod]
        public async Task AddMedicalShops_ReturnsOk()
        {
            //Arrange
            var medicalShop = fixture.Create<MedicalShopModel>();
            medicalshopRepoMock.Setup(repo => repo.AddMedicalShop(It.IsAny<MedicalShopModel>())).ReturnsAsync(medicalShop);
            medicalShopController = new MedicalShopController(medicalshopRepoMock.Object);

            //Act
            var actionResult = await medicalShopController.CreateMedicalShop(medicalShop);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateMedicalShops_ReturnsOk()
        {
            //Arrange
            var medicalShop = fixture.Create<MedicalShopModel>();
            medicalshopRepoMock.Setup(repo => repo.AddMedicalShop(It.IsAny<MedicalShopModel>())).ReturnsAsync(medicalShop);
            medicalShopController = new MedicalShopController(medicalshopRepoMock.Object);

            //Act
            var actionResult = await medicalShopController.CreateMedicalShop(medicalShop);
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);
        }


        [TestMethod]
        public async Task GetMedicalShop_ReturnOk()
        {
            //Arrange
            var medicalShop = fixture.Create<MedicalShopModel>();
            medicalshopRepoMock.Setup(repo => repo.GetMedicalShop(It.IsAny<int>())).ReturnsAsync(medicalShop);
            medicalShopController = new MedicalShopController(medicalshopRepoMock.Object);

            //Act
            var actionResult = await medicalShopController.GetMedicalShop(It.IsAny<int>());
            var result = actionResult.Result as ObjectResult;

            //Assert
            Assert.AreEqual(200, result.StatusCode);

        }


    }
}
