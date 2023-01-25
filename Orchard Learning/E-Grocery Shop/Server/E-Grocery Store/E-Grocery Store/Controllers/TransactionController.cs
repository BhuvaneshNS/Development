using E_Grocery_Store.Common.CustomException;
using E_Grocery_Store.Models;
using E_Grocery_Store.Repository.TransactionManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepo cartRepo;
        private readonly ILogger<TransactionController> logger;

        public TransactionController(ITransactionRepo cartRepo, ILogger<TransactionController> logger)
        {
            this.cartRepo = cartRepo;
            this.logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<Response>> AddToCart(Cart item)
        {
            Response response;
            try
            {
                await cartRepo.AddToCart(item);
                response = new Response()
                {
                    IsSuccess = true,
                    Message = "Added successfully"
                };
                return Ok(response);
            }

            catch (RequestException rex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = rex.Message
                };
                logger.LogError(rex.Message);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<Response>> CheckoutCart(Transaction transaction)
        {
            Response response;
            try
            {
                await cartRepo.CheckoutCart(transaction);
                response = new Response()
                {
                    IsSuccess = true,
                    Message = "Order successfully placed"
                };
                return Ok(response);
            }

            catch (RequestException rex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = rex.Message
                };
                logger.LogError(rex.Message);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response>> UpdateCartItem(Cart updatedItem)
        {
            Response response;
            try
            {
                await cartRepo.UpdateCartItem(updatedItem);
                response = new Response()
                {
                    IsSuccess = true,
                    Message = "Cart updated successfully"
                };
                return Ok(response);
            }
            catch (RequestException rex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = rex.Message
                };
                logger.LogError(rex.Message);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cart>> GetCartItems(int id)
        {
            try
            {
                var cartItems = await cartRepo.GetCartItems(id);
                return Ok(cartItems);
            }
            catch (ResponseException ex)
            {
                logger.LogError(ex.Message);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response>> DeleteCartItem(int id)
        {
            Response response;
            try
            {
                await cartRepo.DeleteCartItem(id);
                response = new Response()
                {
                    IsSuccess = true,
                    Message = "Item removed from cart successfully"
                };
                return Ok(response);
            }
            catch (RequestException rex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = rex.Message
                };
                logger.LogError(rex.Message);
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response = new Response()
                {
                    IsSuccess = false,
                    Message = "Something went wrong"
                };
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
