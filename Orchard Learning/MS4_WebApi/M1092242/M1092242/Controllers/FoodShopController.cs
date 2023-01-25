using M1092242.Common.CustomException;
using M1092242.Models;
using M1092242.Repository.FoodShop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodShopController : ControllerBase
    {
        private readonly IFoodShopRepository foodShopRepository;
        private readonly ILogger<FoodShopController> logger;

        public FoodShopController(IFoodShopRepository foodShopRepository, ILogger<FoodShopController> logger)
        {
            this.foodShopRepository = foodShopRepository;
            this.logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult<FastFoodShopModel>> CreateShop(FastFoodShopModel newShop)
        {
            try
            {
                var shop = await foodShopRepository.AddShop(newShop);
                return Ok(new { Message = "Added shop successfully...", ShopDetails = shop });

            }//Custom exception for empty requests
            catch (RequestEmptyException rex)
            {
                //Logging the error
                logger.LogError(rex.Message);
                return BadRequest(rex.Message);
            }//Custom exception for database insert exception
            catch (DbInsertException dix)
            {
                //Logging the error
                logger.LogError(dix.Message);
                return BadRequest(dix.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }

        [HttpGet("log")]
        public ActionResult Log()
        {
            logger.LogError("Logged Successfully");
            return Ok("Logged Successfully");
        }


        [HttpGet]
        public async Task<ActionResult<List<FastFoodShopModel>>> GetFoodShops()
        {
            try
            {
                return Ok(await foodShopRepository.GetFoodShops());
            }
            catch (NoResultException nrx)
            {
                //Logging the error
                logger.LogError(nrx.Message);
                return NotFound(nrx.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FastFoodShopModel>> GetFoodShop(int id)
        {
            try
            {
                return Ok(await foodShopRepository.GetFoodShop(id));
            }
            catch (NoResultException nrx)
            {
                //Logging the error
                logger.LogError(nrx.Message);
                return NotFound(nrx.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }
        [HttpPut]
        public async Task<ActionResult<FastFoodShopModel>> UpdateFoodShop(FastFoodShopModel updatedShop)
        {
            try
            {
                return Ok(await foodShopRepository.UpdateShop(updatedShop));
            }
            catch (NoResultException nrx)
            {
                //Logging the error
                logger.LogError(nrx.Message);
                return NotFound(nrx.Message);
            }
            catch (RequestEmptyException rex)
            {
                //Logging the error
                logger.LogError(rex.Message);
                return NotFound(rex.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFoodShop(int id)
        {
            try
            {
                await foodShopRepository.DeleteShop(id);
                return Ok(new { Message = "Food Shop Deleted Successfully" });
            }
            catch (NoResultException nrx)
            {
                //Logging the error
                logger.LogError(nrx.Message);
                return NotFound(nrx.Message);
            }
            catch (RequestEmptyException rex)
            {
                //Logging the error
                logger.LogError(rex.Message);
                return NotFound(rex.Message);
            }
            catch (Exception ex)
            {
                //Logging the error
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong at server end. Sorry for the inconvenience...");
            }
        }
    }
}
