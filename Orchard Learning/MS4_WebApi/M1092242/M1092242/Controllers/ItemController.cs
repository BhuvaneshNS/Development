using M1092242.Common.CustomException;
using M1092242.Models;
using M1092242.Repository.Item;
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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;
        private readonly ILogger<FoodShopController> logger;

        public ItemController(IItemRepository itemRepository, ILogger<FoodShopController> logger)
        {
            this.itemRepository = itemRepository;
            this.logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemModel>> CreateItem(ItemModel newItem)
        {
            try
            {
                var item = await itemRepository.AddItem(newItem);
                return Ok(new { Message = "Added Item successfully...", ItemDetails = item });

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
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ItemModel>>> GetItems()
        {
            try
            {

                var items = await itemRepository.GetItems();
                return Ok(new { Message = "Here is the available items", ItemDetails = items });

            }
            //Custom exception for no result
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


        [HttpGet("{itemType}")]
        [Authorize]
        public async Task<ActionResult<List<ItemModel>>> GetItemsByType(string itemType)
        {
            try
            {
                var items = await itemRepository.GetItemsByType(itemType);
                return Ok(new { Message = $"Here is the {itemType} items", ItemDetails = items });
            }
            //Custom exception for no result
            catch (NoResultException nrx)
            {
                //Logging the error
                logger.LogError(nrx.Message);
                return NotFound(nrx.Message);
            }
            //Custom exception for invalid type request
            catch (InvalidCredentialException nrx)
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

        [HttpGet("{shopId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ItemModel>>> UpdatePrice(int shopId)
        {
            try
            {
                var items = await itemRepository.UpdatePrice(shopId);
                return Ok(new { Message = $"Here is the updated price list", ItemDetails = items });
            }
            //Custom exception for no result
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
    }
}
