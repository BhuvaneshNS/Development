using E_Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Repository.TransactionManagement
{
    public interface ITransactionRepo
    {
        public Task AddToCart(Cart item);
        public Task<List<Cart>> GetCartItems(int userId);
        public Task UpdateCartItem(Cart updatedItem);
        public Task DeleteCartItem(int itemId);
        public Task CheckoutCart(Transaction transaction);
    }
}
