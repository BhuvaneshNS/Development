using MedicalShopManagementSystem.Controllers;
using MedicalShopManagementSystem.DataAccess;
using MedicalShopManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class MedicalShopControllerTestClass
    {
        [TestMethod]
        public async Task GetMedicalShops_SuccessAsync()
        {
            //Arrange
            int successStatusCode = 200;
            AppDbContext dummy = null;
            IMedicalShopRepository medicalShopRepository = new MedicalShopRepository(dummy);
            var controller = new MedicalShopController(medicalShopRepository);

            //Act
            var actionResult = await controller.GetMedicalShops();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.AreEqual(successStatusCode, result.StatusCode);
        }
    }
}
