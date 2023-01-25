using E_Grocery_Store.Common.CustomException;
using E_Grocery_Store.DataAccess;
using E_Grocery_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Repository.TransactionManagement
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly AppDbContext appDbContext;

        public TransactionRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddToCart(Cart item)
        {
            try
            {
                if (item == null)
                {
                    throw new RequestException("Request contain no data");
                }
                item.Grocery = null;
                await appDbContext.Cart.AddAsync(item);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CheckoutCart(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                {
                    throw new RequestException("Request contain no data");
                }

                await appDbContext.Transactions.AddAsync(transaction);
                var cartItems = await appDbContext.Cart.Where(c => c.CartId == transaction.CartId && c.Status == 1).ToListAsync();
                cartItems.ForEach(i => i.Status = 0);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCartItem(int itemId)
        {
            try
            {
                var item = await appDbContext.Cart.FirstOrDefaultAsync(i => i.ItemId == itemId);

                if (item == null)
                {
                    throw new RequestException($"No Item with id:{itemId} present");
                }
                appDbContext.Cart.Remove(item);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Cart>> GetCartItems(int userId)
        {
            try
            {
                var result = await appDbContext.Cart.Include(i => i.Grocery).Where(c => c.CartId == userId && c.Status == 1).ToListAsync();
                if (result.Count == 0)
                {
                    throw new ResponseException("Cart is empty");
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCartItem(Cart updatedItem)
        {
            try
            {
                if (updatedItem == null)
                {
                    throw new RequestException("Request body is empty");
                }

                var item = await appDbContext.Cart.FirstOrDefaultAsync(i => i.ItemId == updatedItem.ItemId);

                if (item == null)
                {
                    throw new RequestException($"No item with id:{updatedItem.ItemId} present");
                }
                item.Quantity = updatedItem.Quantity;
                item.Amount = updatedItem.Amount;

                await appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
