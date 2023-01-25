using MedicalShopManagementSystem.Common.CustomException;
using MedicalShopManagementSystem.Models;
using MedicalShopManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicalShopManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class MedicalShopController : ControllerBase
    {
        private readonly IMedicalShopRepository medicalShopRepository;

        public MedicalShopController(IMedicalShopRepository medicalShopRepository)
        {
            this.medicalShopRepository = medicalShopRepository;
        }

        [HttpPost]
        public async Task<ActionResult<MedicalShopModel>> CreateMedicalShop(MedicalShopModel medicalShop)
        {
            try
            {
                if (medicalShop == null)
                {
                    return BadRequest();
                }
                var createdMedicalShop = await medicalShopRepository.AddMedicalShop(medicalShop);
                return Ok(new { Message = "Medical shop created successfully", ShopDetails = createdMedicalShop });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MedicalShopModel>> UpdateMedicalShop(MedicalShopModel medicalShop)
        {
            try
            {
                if (medicalShop == null)
                {
                    return BadRequest();
                }
                if (await medicalShopRepository.GetMedicalShop(medicalShop.Id) == null)
                {
                    return NotFound();
                }
                var updatedMedicalShop = await medicalShopRepository.UpdateMedicalShop(medicalShop);
                return Ok(updatedMedicalShop);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MedicalShopModel>> GetMedicalShop(int id)
        {
            try
            {
                var medicalShop = await medicalShopRepository.GetMedicalShop(id);
                if (medicalShop == null)
                {
                    return NotFound();
                }
                return Ok(medicalShop);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<MedicalShopModel>> GetMedicalShops()
        {
            try
            {
                var medicalShops = await medicalShopRepository.GetMedicalShops();
                if (medicalShops.Count == 0)
                {
                    return NotFound();
                }
                return Ok(medicalShops);
            }
            catch (EmptyException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var medicalShop = await medicalShopRepository.GetMedicalShop(id);
            if (medicalShop == null)
            {
                return NotFound($"Medical shop with id: {id} not found");
            }
            await medicalShopRepository.DeleteMedicalShop(id);
            return Ok($"Medical shop with id: {id} deleted");
        }
    }
}
