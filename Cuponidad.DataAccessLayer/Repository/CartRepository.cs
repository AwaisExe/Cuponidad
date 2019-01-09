using Cuponidad.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cuponidad.DataAccessLayer.Repository
{
    public class CartRepository
    {
        static CuponContext context = new CuponContext();
        public static void Insert(Cart cart)        
        {
            //cart.Quantity = 1;
            context.Carts.Add(cart);
            context.SaveChanges();
        }
        public static void Delete(int cartID)
        {
            Cart cart = new Cart();
            cart = context.Carts
                        .Where(a => a.CartID == cartID)
                        .FirstOrDefault();
            context.Remove(cart);
            context.SaveChanges();
        }
        public static void DeleteByUser(int userID)
        {
            List<Cart> carts = new List<Cart>();
            carts = context.Carts
                        .Where(a => a.UserID == userID)
                        .ToList();
            foreach(var item in carts)
            {
                context.Remove(item);
                context.SaveChanges();
            }
        }
        public static List<Cart> ListByUser(int userID)
        {
            List<Cart> carts = null;
            carts = context.Carts
                        .Include(a => a.Product)
                        .Include(a => a.Product.Company)
                        .Where(a => a.UserID == userID)
                        .ToList();
            UpdateTotalAmount(userID, carts);
            return carts;
        }

        public static void UpdateQuantityAndSubtotal(int cartID, int quantity, decimal subTotal)
        {
            Cart cart = new Cart();
            cart = context.Carts
                        .Where(a => a.CartID == cartID)
                        .FirstOrDefault();
            cart.Quantity = quantity;
            cart.Total = subTotal;
            context.SaveChanges();
        }
        public static void UpdateTotalAmount(int userID, List<Cart> carts)
        {
            decimal totalAmount = 0;
            foreach (var item in carts)
            {
                totalAmount = totalAmount + item.Total;
            }
            UserRepository.UpdateTotalAmount(userID, totalAmount);
        }
    }
}
